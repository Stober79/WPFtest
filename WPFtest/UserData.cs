using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtest
{
    public class UserData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100,MinimumLength =5)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
