using System.ComponentModel.DataAnnotations;

namespace ApplicationsAPI.Models
{
    public class EntryModel
    {
        [Required, Range(3, 128)]
        public string Company { get; set; }
        [Required]
        public StatusEnum StatusId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public decimal PayStart { get; set; }
        [Required]
        public decimal PayEnd { get; set; }
        public DateTime AppliedDate { get; set; }
        public string RoleDesc { get; set; }
    }
}
