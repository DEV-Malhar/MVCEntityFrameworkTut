using System.Diagnostics;
using CodeFirstASPCore6.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstASPCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext stdDb;

        /*private readonly ILogger<HomeController> _logger;

public HomeController(ILogger<HomeController> logger)
{
_logger = logger;
}*/


        /*
         * 
         
        ->ctor create a HomeController Constructor 
         ->"Ctrl+." select secont option and Create this field "private readonly StudentDbContext stdDb;"
         
         */
        public HomeController(StudentDbContext StdDb)
        {
            stdDb = StdDb;
        }
/*
 
        -> Delete the old View.cshtml from views
        -> Select Index Right Click Create View ->Razor View-> input all Template,ModelClass,DbContext Class
        

 */
        public IActionResult Index()
        {
            var stdData = stdDb.Students.ToList(); //to access the data this Line is Written
            return View(stdData);
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


/*
 ******Appsetting.jsom*******
 
 / Configure the database (Code First)
var provider = builder.Services.BuildServiceProvider();

var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<StudentDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));
 
 
 
 
 */