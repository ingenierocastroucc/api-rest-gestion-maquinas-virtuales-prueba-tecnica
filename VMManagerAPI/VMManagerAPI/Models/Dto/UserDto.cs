using System.ComponentModel.DataAnnotations;

namespace VMManagerAPI.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }
    }
}