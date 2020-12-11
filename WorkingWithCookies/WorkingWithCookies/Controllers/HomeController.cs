using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithCookies.Models;

namespace WorkingWithCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

       public IActionResult CreateCookies()
        {
            string key = "language";
            string value = "pt-br";
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Append(key, value, cookieOptions);
            return View("Index");
        }

        public IActionResult ReadCookies()
        {
            string key = "language";

            var cookieLanguage = Request.Cookies[key];
            
            if(cookieLanguage != null && cookieLanguage.ToString().Equals("pt-br1"))
            {
                return View("Index") ;
            }
            return View("Privacy");
        }

        public IActionResult RemoveCookies()
        {
            string key = "language";
            string value = "";
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append(key, value, cookieOptions);
            return View("Index");
        }
    }
}
