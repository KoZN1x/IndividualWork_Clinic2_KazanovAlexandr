using Individualwork_Clinic2_KazanovAlexandr.Models;

namespace Individualwork_Clinic2_KazanovAlexandr.Service
{
    public interface IStaffService
    {
        public IEnumerable<OutpatientCardRequest> GetAllOutpatientCardRequests();
        public void Delete(OutpatientCardRequest outpatientCardRequest);
    }
}
