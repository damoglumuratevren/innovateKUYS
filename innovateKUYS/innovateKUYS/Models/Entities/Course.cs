using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace innovateKUYS.Models.Entities
{


    [Table("Courses")]
    public class Course : EntityLogBase
    {
        [Key, Required, Display(Name = "Ders Id")]
        public int Id { get; set; }

        [Required, StringLength(20),  Display(Name = "Ders Kodu")]
        public string CourseCode { get; set; }

        [Required, StringLength(100), Display(Name = "Ders Adı")]
        public string CourseName { get; set; }

        [Required, StringLength(15), Display(Name = "Ders Dönemi")]
        public string CoursePeriyod { get; set; }//1. dönem 2. dönem 3.dönem vs

        [Required, StringLength(15), Display(Name = "Ders Fakultesi")]//zaman kalırsa ayrı obje yapılacak
        public string FacultyCode { get; set; }

        [Display(Name = "Ögretmen Id")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
