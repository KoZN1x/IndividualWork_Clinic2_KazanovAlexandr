using Individualwork_Clinic2_KazanovAlexandr.Models;
using Individualwork_Clinic2_KazanovAlexandr.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Individualwork_Clinic2_KazanovAlexandr.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }
            
        public IActionResult Index()
        {
            var listOfUsers = _service.GetAllUsers();
            return View(listOfUsers);
        }

        public IActionResult AddStaffRole([FromRoute]string? id)
        {
            var users = new List<IdentityUser>(_service.GetAllUsers());
            if (id == null || users == null)
            {
                return NotFound();
            }
            var user = users.Find(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _service.AddStaffRole(user);
            return RedirectToAction(nameof(Index));

        }
    }
}
