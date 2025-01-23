using System.Diagnostics;
using CodeFirstASPCore6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstASPCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext stDb;


        #region Contructors
        private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        /*         
         ->ctor create a HomeController Constructor 
         ->"Ctrl+." select secont option and Create this field "private readonly StudentDbContext stdDb;"
         */

        public HomeController(StudentDbContext StDb)
        {
            stDb = StDb;
        }
        /*
                -> Delete the old View.cshtml from views
                -> Select Index Right Click Create View ->Razor View-> input all Template,ModelClass,DbContext Class
          */

        #endregion

        #region Index   

        public async Task<IActionResult> Index()
        {
            var stdData = await stDb.Students.ToListAsync(); //to access the data this Line is Written
            return View(stdData);
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await stDb.Students.AddAsync(std);                     //This Will add data to Database
                await stDb.SaveChangesAsync();                         //This will save changes
                TempData["insert_success"] = "Insrted Successful...."; //This will Display Message after create 
                return RedirectToAction("Index");           //This will redirect to the Index page
            }
            return View(std);
        }
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Details
         public async Task<IActionResult> Details(int? id)
        {
            if (id == null || stDb.Students == null)
            {
                return NotFound();
            }
            var stdData = await stDb.Students.FirstOrDefaultAsync(x => x.StdId == id);
            if(stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        #endregion

        #region Edit

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || stDb.Students == null)
            {
                return NotFound();
            }
            var stdData = await stDb.Students.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id , Student std)
        {
            if(id != std.StdId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                stDb.Update(std);
                await stDb.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(std);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || stDb.Students == null)
            {
                return NotFound();
            }

            var stdData = await stDb.Students.FirstOrDefaultAsync(x => x.StdId == id);
           
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var stdData = await stDb.Students.FindAsync(id);
            if(stdData == null)
            {
                stDb.Remove(stdData);
            }
            await stDb.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
        #endregion

        #region Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}

#region Notes
/*
 ******Appsetting.jsom*******
 
 / Configure the database (Code First)
var provider = builder.Services.BuildServiceProvider();

var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<StudentDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));
 
 
 
 
 */
#endregion