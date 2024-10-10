﻿using System.ComponentModel.DataAnnotations;

namespace Foody.Web.Models.Requests.Account
{
    public class RegisterUserReq
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
