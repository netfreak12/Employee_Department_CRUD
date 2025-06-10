using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_APP.DataContext;

namespace MVC_CRUD_APP.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MVC_CRUD_APP_DbContext db;                     // Injecting the DbContext to access the database

        public DepartmentController(MVC_CRUD_APP_DbContext dbContext)   // Constructor to initialize the DbContext
        {
            this.db = dbContext;                                        // Assigning the injected DbContext to the local variable
        }

        // GET: /Department/Index
        public async Task<IActionResult> Index()                        // Action method to fetch and display the list of departments
        {
            try
            {
                var deptList = await db.Departments.ToListAsync();      // Fetching the list of departments from the database asynchronously
                return View(deptList);                                  // Returning the list to the view
            }
            catch (Exception ex)                                        // Catching any exceptions that may occur during the database operation
            {
                // Log exception here
                return View("Error"); // Custom error view
            }
        }

        // GET: /Department/Create
        [HttpGet]
        public IActionResult Create()                                   // Action method to return the view for creating a new department
        {
            return View();                                              // Returning the view for creating a new department
        }
        
    }
}
