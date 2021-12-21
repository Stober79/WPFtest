using System;
using System.ComponentModel.DataAnnotations;

namespace UserModel
{
    public class UserData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
