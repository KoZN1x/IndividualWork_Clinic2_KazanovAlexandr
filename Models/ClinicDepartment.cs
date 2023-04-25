using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Clinic_IndividualWork_KazanovAlexandr.Models
{
    public class ClinicDepartment
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    }
}
