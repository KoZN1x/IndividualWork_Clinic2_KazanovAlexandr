using System.ComponentModel.DataAnnotations;

namespace Individualwork_Clinic2_KazanovAlexandr.Models
{
    public class OutpatientCardRequest
    {
        [Key]
        public int Id { get; set; }
        public string? Complaints { get; set; }
    }
}
