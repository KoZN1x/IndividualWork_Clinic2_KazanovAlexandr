using Individualwork_Clinic2_KazanovAlexandr.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Individualwork_Clinic2_KazanovAlexandr.Service
{
    public class AdminService : IAdminService
    {
        private readonly DbContextOptions<ApplicationDbContext>? _context;
        private readonly UserManager<IdentityUser>? _userManager;
        public AdminService() { }
        public AdminService(DbContextOptions<ApplicationDbContext> context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IEnumerable<IdentityUser> GetAllUsers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_context!))
            {
                return db.Users.ToList();
            }
        }
        public async Task AddStaffRole(IdentityUser user)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_context!))
            {
                await _userManager!.AddToRoleAsync(user, "staff");
                await db.SaveChangesAsync();
            }
        }
    }
}
