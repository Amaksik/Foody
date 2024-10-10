using Microsoft.AspNetCore.Identity;

namespace Foody.Domain.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }  // Primary key

        public string Role { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

    }
}