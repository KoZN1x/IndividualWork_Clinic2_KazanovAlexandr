using Clinic_IndividualWork_KazanovAlexandr.Models;
using Individualwork_Clinic2_KazanovAlexandr.Data;
using Individualwork_Clinic2_KazanovAlexandr.Models;
using Individualwork_Clinic2_KazanovAlexandr.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Individualwork_Clinic2_KazanovAlexandr.Controllers
{
    [Authorize(Roles = "STAFF")]
    public class StaffController : Controller
    {
        private readonly IStaffService _service;
        private readonly ApplicationDbContext _context;
        public StaffController(IStaffService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        public IActionResult Index()
        {
            var listOfOutpatientCardRequests = _service.GetAllOutpatientCardRequests();
            return View(listOfOutpatientCardRequests);
        }

        public IActionResult Approve(int? id)
        {
            var outpatientCardRequests = new List<OutpatientCardRequest>(_service.GetAllOutpatientCardRequests());
            if (id == null || outpatientCardRequests == null)
            {
                return NotFound();
            }
            var outpatientCardRequest = outpatientCardRequests.Find(x => x.Id == id);
            if (outpatientCardRequest == null)
            {
                return NotFound();
            }
            return View(outpatientCardRequest);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, [Bind("TreatmentPlan,DoctorID,PatientID")] OutpatientCardRequest outpatientCardRequest, string treatmentPlan, int doctorId, int patientId)
        {
            if (id != outpatientCardRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
            
                var outpatientCard = new OutpatientCard()
                {
                    Complaints = outpatientCardRequest.Complaints,
                    TreatmentPlan = treatmentPlan,
                    DoctorId = doctorId,
                    PatientId = patientId
                };
                _context.OutpatientCard.Add(outpatientCard);
                await _context.SaveChangesAsync();
                _service.Delete(outpatientCardRequest);
                return RedirectToAction("Index");
            }
            return View(outpatientCardRequest);
        }
    }
}
