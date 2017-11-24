using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMorais.IgniteCaptcha;
using System.IO;

namespace IgniteCaptchaSample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string cptvalue = null;
            ViewData["captcha"] = IgniteCaptcha.GenCaptcha(Path.Combine(Directory.GetCurrentDirectory(), @"output"), 300, 150, out cptvalue);
            HttpContext.Session.SetString("CaptchaValue", cptvalue);
            return View();
        }
     }
}