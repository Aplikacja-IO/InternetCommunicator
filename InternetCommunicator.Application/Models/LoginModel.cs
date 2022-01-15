using InternetMessengerApp.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMessengerApp.Models
{
    public class LoginModel
    {
        public UserInfo User{ get; set; }
    }
}
