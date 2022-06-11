using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace innovateKUYS.Models.Entities
{


    [Table("Students")]
    public class Student:EntityLogBase
    {
        [Key, Display(Name = "Ögrenci Id")]
        public int Id { get; set; } 

        [Required,StringLength(40), MinLength(3), Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required, StringLength(40), MinLength(3), Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required, StringLength(12), MinLength(12), Display(Name = "Ögrenci Kodu")]
        public string StudentCode { get; set; }

        [Required, StringLength(100) ,EmailAddress, Display(Name = "Ögrenci Email")]
        public string Email { get; set; }

        [Required, StringLength(10), MinLength(10), Display(Name = "Telefon numarası")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(200), Display(Name = "Ögrenci Şifresi")]
        public string Password { get; set; }


        [Display(Name = "Ögrenci Kayıt Zamani")]
        public DateTime RegistrationTime { get; set; }

        [Display(Name = "Ögrenci Mezuniyet Zamanı")]
        public DateTime? GraduationTime { get; set; }

        [Display(Name = "Ögrenci mezun oldu mu?")]
        public bool IsGraduate { get; set; }
    }
}
