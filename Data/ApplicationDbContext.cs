using Clinic_IndividualWork_KazanovAlexandr.Models;
using Individualwork_Clinic2_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Individualwork_Clinic2_KazanovAlexandr.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        
        
        public DbSet<ClinicDepartment> ClinicDepartment { get; set; } = null!;
        public DbSet<Doctor> Doctor { get; set; } = null!;
        public DbSet<OutpatientCard> OutpatientCard { get; set; } = null!;
        public DbSet<Patient> Patient { get; set; } = null!;
        public DbSet<Position> Position { get; set; } = null!;
        public DbSet<OutpatientCardRequest> OutpatientCardRequests { get; set; } = null!;
    }
}