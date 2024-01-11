using hshmedstats.Application.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace hshmedstats.Web.Models.User
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            
        }

        public UserViewModel(UserDto user)
        {
            Id = user.Id;
            Username = user.Username;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Role = user.Role;
        }

        public int? Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
