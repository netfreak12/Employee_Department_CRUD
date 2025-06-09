using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MVC_CRUD_APP.DataContext;


namespace MVC_CRUD_APP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVC_CRUD_APP.DataContext.MVC_CRUD_APP_DbContext _context; // Injecting the DbContext to access the database

        public EmployeeController(MVC_CRUD_APP.DataContext.MVC_CRUD_APP_DbContext context) // Constructor to initialize the DbContext
        {
            _context = context;
        }
        

        public async Task<IActionResult> Index() 
        {
            var empList = await _context.Employees.Include(e => e.Department).ToListAsync(); // Fetching the list of employees along with their associated departments from the database
            return View(empList);
        }
    }
}
