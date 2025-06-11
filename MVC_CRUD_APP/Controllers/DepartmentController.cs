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

        // GET: /Department/Edit/
        // Shows edit form for an existing department
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
                return NotFound();

            try
            {
                var department = await db.Departments
                    .FirstOrDefaultAsync(d => d.DeptId == id);

                if (department == null)
                    return NotFound();

                return View(department);
            }
            catch (Exception ex)
            {
                // Log the exception (use ILogger if available)
                _logger.LogError(ex, "An error occurred while retrieving the department.");

                // Optionally use a generic error model/view
                return View("Error");
            }
        }

        // POST: /Department/Edit
        // Handles form submission to update an existing department
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            // Validate ID mismatch
            if (id != department.DeptId)
                return BadRequest("ID mismatch between route and model.");

            try
            {
                if (ModelState.IsValid)
                {
                    db.Departments.Update(department);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                // If ModelState is invalid, redisplay the form with validation errors
                return View(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflict
                if (!await DepartmentExists(department.DeptId)) // Check if the department exists
                    return NotFound();
                else
                    // Log and re-throw if it's an unexpected concurrency issue
                    // Consider logging ex here
                    throw;
            }
            catch (Exception ex)
            {
                // Log the exception (use ILogger if available)
                _logger.LogError(ex, "An error occurred while retrieving the department.");
                // Optional: Log the exception here
                return View(department);
            }
        }

        // Helper method to check if department exists or not
        private async Task<bool> DepartmentExists(int id)
        {
            return await db.Departments.AnyAsync(d => d.DeptId == id);
        }

        // GET: /Department/Details/
        // Displays details of a specific department
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            try
            {
                var department = await db.Departments
                    .FirstOrDefaultAsync(d => d.DeptId == id);

                if (department == null)
                {
                    return NotFound();
                }

                return View(department);
            }
            catch (Exception ex)
            {
                // Consider logging the exception here (e.g., using ILogger)
                _logger.LogError(ex, "An error occurred while fetching department details.");

                return View("Error");
            }
        }

        // GET: /Department/Delete/
        // Shows confirmation page before deleting a department
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            try
            {
                var department = await db.Departments
                    .FirstOrDefaultAsync(d => d.DeptId == id);

                if (department == null)
                {
                    return NotFound();
                }

                return View(department);
            }
            catch (Exception ex)
            {
                // Log exception (optional: use ILogger if available)
                _logger.LogError(ex, "An error occurred while fetching department for deletion.");

                return View("Error"); // Consider using a constant or nameof(Error)
            }
        }
    }
}
