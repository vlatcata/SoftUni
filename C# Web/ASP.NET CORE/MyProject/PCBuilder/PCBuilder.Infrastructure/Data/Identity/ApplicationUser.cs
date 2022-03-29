using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCBuilder.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Computers = new List<Computer>();
        }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public List<Computer> Computers { get; set; }
    }
}
