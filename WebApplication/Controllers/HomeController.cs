using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CompanyContext context;

        public HomeController(ILogger<HomeController> logger, CompanyContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var emp = context.Employees.Where(x => x.Id == 1).FirstOrDefault();
            emp.FirstName = "sdfsdfs";
            return View(emp);
        }

        public IActionResult Privacy(Employee employee)
        {
            context.Attach(employee);
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
