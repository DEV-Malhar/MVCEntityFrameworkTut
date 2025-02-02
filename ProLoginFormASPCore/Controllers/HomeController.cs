using Microsoft.AspNetCore.Mvc;
using ProLoginFormASPCore.Models;
using System.Diagnostics;

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

        #region Login & Logout
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
            var myUser = context.TblUsers.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();//Conditon for Password and Email
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Name);  //session will pass value of User name into Dashboard
                return Redirect("Dashboard");                               //will Redirect to Dashboard Page
            }
            else
            {
                ViewBag.Message = " Login Failed";
            }
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
        #endregion

        #region Dashboard
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
              ViewBag.MySession =  HttpContext.Session.GetString("UserSession").ToString();//Here Usersession i.e Name is passed to dashboard and saved in ViewBag.MySession
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }
        #endregion

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(TblUser user)
        {
            if (ModelState.IsValid)
            {
                await context.TblUsers.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login");

            }
            return View();
        }

        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
