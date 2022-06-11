using System.ComponentModel.DataAnnotations;

namespace innovateKUYS.Models.ViewsModels.StudentVM
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
        StringLength(40, MinimumLength = 3, ErrorMessage = "{0} alanı maksimum {1} minimum{2} karakter olabilir"), Display(Name = "Ad")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
        StringLength(40, MinimumLength = 3, ErrorMessage = "{0} alanı maksimum {1} minimum{2} karakter olabilir"), Display(Name = "Soyad")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
        StringLength(12, MinimumLength = 12, ErrorMessage = "{0} alanı maksimum {1} minimum{2} karakter olabilir"), Display(Name = "Ögrenci Kodu")]

        public string StudentCode { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(100, ErrorMessage = "{0} alanı maksimum {1} karakter olabilir"), EmailAddress(ErrorMessage = "{0} alanına geçerli bir e-posta giriniz"), Display(Name = "Ögrenci Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(10, MinimumLength = 10, ErrorMessage = "{0} alanı maksimum {1} minimum{2} karakter olabilir"), Display(Name = "Telefon numarası")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(16, MinimumLength = 6, ErrorMessage = "{0} alanı maksimum {1} minimum{2} karakter olabilir"),
            Display(Name = "Ögrenci Şifresi")]

        public string Password { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez"),
        StringLength(16, MinimumLength = 6, ErrorMessage = "{0} alanı maksimum {1} minimum{2} karakter olabilir"), Display(Name = "Ögrenci Şifresi(Tekrar)"), Compare(nameof(Password), ErrorMessage = "{0} alanı ile {1} alanı eşleşmiyor")]

        public string RePassword { get; set; }


        [Display(Name = "Ögrenci Kayıt Zamani"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public DateTime RegistrationTime { get; set; }
    }
}
