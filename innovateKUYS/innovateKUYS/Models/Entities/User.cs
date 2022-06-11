using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace innovateKUYS.Models.Entities
{



    [Table("Users")]
    public class User : EntityLogBase
    {
        [Key, Required, Display(Name = "Kullanıcı Id")]
        public int Id { get; set; }

        [Required, Display(Name = "Kullanıcı Tipi")]// 0 admin 1 personel 2 ögretmen
        public int UserType { get; set; }


        [Required, StringLength(40), MinLength(3), Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required, StringLength(40), MinLength(3), Display(Name = "Soyad")]
        public string LastName { get; set; }
        

        [Required, StringLength(100), EmailAddress,MinLength(10),  Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(10), MinLength(10), Display(Name = "Telefon Numaraso")]
        public string PhoneNumber { get; set; }

        [Required, StringLength(200), Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
