using DropDownPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProDropDownDB.Models;
using System.Diagnostics;

namespace DropDownPro.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly MytestDatabaseContext context;

        public HomeController(MytestDatabaseContext context)
        {
            this.context = context;
        }
        private StudentModels StDDL()//This Method is written so there is less repeatation of Code
        {
            StudentModels stdModel = new StudentModels();
            stdModel.studList = new List<SelectListItem>();
            var data = context.Students.ToList();
            stdModel.studList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = " ",
            });
            foreach (var item in data)
            {
                stdModel.studList.Add(new SelectListItem
                {
                    Text = item.StudentName,
                    Value = item.StdId.ToString(),
                });
            }
            return stdModel;

        }
        public IActionResult Index()
        {
            var std = StDDL();//here the Method is called where it is passed and for View
            return View(std);
        }
        [HttpPost]
        public IActionResult Index(StudentModels std)
        {
           var student = context.Students.Where(x => x.StdId == std.studId).FirstOrDefault();
            if (student != null)
            {
                ViewBag.selectedValue = student.StudentName;//here name is passed to be view in Webpage 
            }
            var myStd = StDDL();
            return View(myStd);
        }

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
