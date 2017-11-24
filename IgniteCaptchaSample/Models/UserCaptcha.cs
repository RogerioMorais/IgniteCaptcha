using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IgniteCaptchaSample.Models
{
    public class UserCaptcha
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
    }
}
