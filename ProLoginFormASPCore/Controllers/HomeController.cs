using Microsoft.AspNetCore.Mvc;
using ProLoginFormASPCore.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ProLoginFormASPCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyTestDatabaseContext context;

        public HomeController(MyTestDatabaseContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)//this will redirect to Dashboard if your login
            {
               return RedirectToAction("Dashboard"); 
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(TblUser user)
        {
            var myUser = context.TblUsers.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);  //session 
                return Redirect("Dashboard");
            }
            else
            {
                ViewBag.Message = " Login Failed";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
              ViewBag.MySession =  HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
