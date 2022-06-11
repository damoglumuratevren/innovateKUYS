using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace innovateKUYS.Models.Entities
{
    [Table("CourseStudents")]
    public class CourseStudent : EntityLogBase
    {

        [Key, Display(Name = "Ögrenci Dersleri Id")]
        public int Id { get; set; }

        [Required, Display(Name = "Ögrenci Ders Ortalaması")]
        public decimal GradeAverage { get; set; } = 0;

        [Display(Name = "Dersi Gectimi")]
        public bool IsPassed { get; set; }


        [Display(Name = "Dersi Id")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        
        [Display(Name = "Ögrenci Id")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        //public virtual List<Course> Courses { get; set; }
    }
}
