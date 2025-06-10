using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_APP.DataContext;
using MVC_CRUD_APP.Models;

namespace MVC_CRUD_APP.Controllers
{
    public class DepartmentController : Controller
    {
        // Database context to interact with the database
        private readonly MVC_CRUD_APP_DbContext db;

        // Logger to log errors and information
        private readonly ILogger<DepartmentController> _logger;

        // Constructor to inject the DbContext using Dependency Injection
        public DepartmentController(MVC_CRUD_APP_DbContext dbContext, ILogger<DepartmentController> logger)
        {
            this.db = dbContext;
            this._logger = logger;
        }

        // GET: /Department/Index
        // Displays list of all departments
        public async Task<IActionResult> Index()
        {
            try
            {
                var deptList = await db.Departments.ToListAsync();
                return View(deptList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching department list");
                return View("Error");
            }
        }

        // GET: /Department/Index
        // Displays list of all departments
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // POST: /Department/Create
        // Handles form submission to create a new department

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await db.Departments.AddAsync(department);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(department);
            }
            catch (Exception ex)
            {
                // Fix for CS1503: Argument 1: cannot convert from 'System.Exception' to 'string'
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
                _logger.LogError(ex, "Error occurred while creating a department");
                return View(department);
            }
        }


    }
}
