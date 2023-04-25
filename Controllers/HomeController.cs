using Clinic_IndividualWork_KazanovAlexandr.Models;
using Individualwork_Clinic2_KazanovAlexandr.Data;
using Individualwork_Clinic2_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Individualwork_Clinic2_KazanovAlexandr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextOptions<ApplicationDbContext> _context;

        public HomeController(ILogger<HomeController> logger, DbContextOptions<ApplicationDbContext> context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CreateCard(string complaints)
        {
            var outpatientCardRequest = new OutpatientCardRequest();
            outpatientCardRequest.Complaints = complaints;
            using (ApplicationDbContext db = new ApplicationDbContext(_context))
            {
                db.OutpatientCardRequests.Add(outpatientCardRequest);
                db.SaveChanges();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}