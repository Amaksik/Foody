using Foody.IdentityAccessLayer.Record;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using Foody.Web.Models.Requests.Account;
using Foody.Domain.Entities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Foody.BLL.Models;
using Microsoft.VisualBasic;
using System.Net;

namespace Foody.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUserRecord> _signInManager;
        private readonly UserManager<ApplicationUserRecord> _userManager;
        private readonly IUserEmailStore<ApplicationUserRecord> _emailStore;
        private readonly IConfiguration _configuration;
        //private readonly IEmailSender _emailSender;

        public AccountController(SignInManager<ApplicationUserRecord> signInManager,
            UserManager<ApplicationUserRecord> userManager,
            IUserStore<ApplicationUserRecord> userStore, /*, IEmailSender emailSender*/
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailStore = GetEmailStore(userStore);
            _configuration = configuration;
            //_emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserReq request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var email = request.Email;
            if (string.IsNullOrEmpty(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return ValidationProblem(new ValidationProblemDetails
                {
                    Detail = _userManager.ErrorDescriber.InvalidEmail(email).Description
                });
            }

            var user = new ApplicationUserRecord();
            user.Email = request.Email;
            user.FullName = request.Name.Trim() + " " + request.Surname.Trim();
            user.UserName = request.Email;
            user.CreationDate = DateTime.UtcNow;


            //await _userManager.SetUserNameAsync(user, email);
            //await _emailStore.SetEmailAsync(user, email);


            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return ValidationProblem(CreateValidationProblem(result));
            }

            var createdUser = await _userManager.FindByEmailAsync(user.Email);

            await _userManager.AddToRolesAsync(createdUser, new[] { nameof(Roles.Client) });

            await SendConfirmationEmailAsync(user, email);

            return Ok();
        }

        private async Task SendConfirmationEmailAsync(ApplicationUserRecord user, string email)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var userId = await _userManager.GetUserIdAsync(user);

            var confirmUrl = Url.Action("ConfirmEmail", "Account", new { userId, code = encodedToken }, Request.Scheme);
            //await _emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by clicking this link: {HtmlEncoder.Default.Encode(confirmUrl)}");
        }

        private IUserEmailStore<ApplicationUserRecord> GetEmailStore(IUserStore<ApplicationUserRecord> userStore)
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("User store with email support is required.");
            }
            return (IUserEmailStore<ApplicationUserRecord>)userStore;
        }

        private ValidationProblemDetails CreateValidationProblem(IdentityResult result)
        {
            var problemDetails = new ValidationProblemDetails();
            foreach (var error in result.Errors)
            {
                problemDetails.Errors.Add(error.Code, new[] { error.Description });
            }
            return problemDetails;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies)
        {

            var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
            var isPersistent = (useCookies == true) && (useSessionCookies != true);

            // Set the authentication scheme (cookie or bearer)
            _signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

            // Perform the password sign-in
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent, lockoutOnFailure: false);

            if (result.RequiresTwoFactor)
            {
                // Handle two-factor authentication
                if (!string.IsNullOrEmpty(login.TwoFactorCode))
                {
                    result = await _signInManager.TwoFactorAuthenticatorSignInAsync(login.TwoFactorCode, isPersistent, rememberClient: isPersistent);
                }
                else if (!string.IsNullOrEmpty(login.TwoFactorRecoveryCode))
                {
                    result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(login.TwoFactorRecoveryCode);
                }
            }
            if (!result.Succeeded)
            {
                return Unauthorized(new ProblemDetails
                {
                    Title = "Login failed",
                    Detail = result.ToString(),
                    Status = StatusCodes.Status401Unauthorized
                });
            }
            // Retrieve the user
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return Unauthorized(new ProblemDetails
                {
                    Title = "User not found",
                    Status = StatusCodes.Status401Unauthorized
                });
            }

            // Generate the JWT token
            var token = GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                Message = "Login successful"
            });

        }

        [HttpPost("login2")]
        public async Task<IActionResult> Login2([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies)

        {

            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                var isActivated = await _userManager.IsEmailConfirmedAsync(user);

                if (!isActivated)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, "AccountNotActivated");
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.Forbidden,"AccountBlocked OR InvalidLogin");
                }
            }
            var token = GenerateJwtToken(user);

            return Ok(new
            {
                Token = token,
                Message = "Login successful"
            });


        }

        private string GenerateJwtToken(ApplicationUserRecord user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            // Add any additional claims here
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
