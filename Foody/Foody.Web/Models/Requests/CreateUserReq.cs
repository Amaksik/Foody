using System.ComponentModel.DataAnnotations;

namespace Foody.Web.Models.Requests
{
    public class CreateUserReq
    {
        [Required]
        public string Name { get; set; }

        public string? Surname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        [Required]
        public string ChatId { get; set; }
    }
}
