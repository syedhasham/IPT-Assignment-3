using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepsitoryPattern.Data;
using RepsitoryPattern.Models;

namespace RepsitoryPattern.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext Context)
        {
            context = Context;
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            var books = from projects in context.Projects join supervisors in context.Supervisor
                         on projects.SupervisorId equals supervisors.SupervisorId
                        join employee in context.Employee on projects.EmployeeId equals employee.Id  select projects;

            foreach (var item in books)
            {
                ProductViewModel model = new ProductViewModel()
                {
                    ProjectName = item.ProjectName,
                    EmployeeName = item.Employee.EmployeeName,
                    SupervisorName = item.Supervisor.SupervisorName,
                };
            }
            
            return View(books);
        }

        public IActionResult AddProduct([FromBody] ProductViewModel product)

        {
            
                var admin = new Supervisor()
                {
                    SupervisorName = product.SupervisorName
                };
            context.Add(admin);
            context.SaveChanges();
                Projects book1 = new Projects
                {
                    SupervisorId = admin.SupervisorId,
                    ProjectName = product.ProjectName,
                    Category = product.Categroy
                };
            context.Add(book1);
            context.SaveChanges();


            return View();
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
