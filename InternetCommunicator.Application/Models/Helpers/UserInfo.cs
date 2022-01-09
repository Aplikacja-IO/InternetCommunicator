using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMessengerApp.Models.Helpers
{
    public class UserInfo
    {
        [Required(ErrorMessage = "Id is required")]
        public int userId { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
