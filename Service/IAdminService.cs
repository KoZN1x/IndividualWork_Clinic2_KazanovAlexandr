using Microsoft.AspNetCore.Identity;

namespace Individualwork_Clinic2_KazanovAlexandr.Service
{
    public interface IAdminService
    {
        public Task AddStaffRole(IdentityUser user);
        public IEnumerable<IdentityUser> GetAllUsers();

    }
}
