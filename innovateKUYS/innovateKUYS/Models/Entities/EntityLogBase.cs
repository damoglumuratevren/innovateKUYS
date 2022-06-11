using System.ComponentModel.DataAnnotations;

namespace innovateKUYS.Models.Entities
{
    public class EntityLogBase
    {
        [Required, StringLength(40)]
        public string CreatedUser { get; set; }
        public DateTime CreatedDtm { get; set; }
        [StringLength(40)]
        public string? ModifiedUser { get; set; }
        public DateTime? ModifiedDtm { get; set; }
        public bool IsActive { get; set; }
    }
}
