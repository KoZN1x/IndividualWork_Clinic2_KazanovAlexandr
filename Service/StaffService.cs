using Clinic_IndividualWork_KazanovAlexandr.Models;
using Individualwork_Clinic2_KazanovAlexandr.Data;
using Individualwork_Clinic2_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Individualwork_Clinic2_KazanovAlexandr.Service
{
    public class StaffService : IStaffService
    {
        private readonly ApplicationDbContext? _context;
        public StaffService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(OutpatientCardRequest outpatientCardRequest)
        {
            if (outpatientCardRequest != null)
            {
                _context!.OutpatientCardRequests.Remove(outpatientCardRequest);
                _context!.SaveChangesAsync();
            }
        }

        public IEnumerable<OutpatientCardRequest> GetAllOutpatientCardRequests()
        {
            
            return _context!.OutpatientCardRequests.ToList<OutpatientCardRequest>();
           
        }
        private bool UserExists(int id)
        {
            return (_context!.OutpatientCardRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
