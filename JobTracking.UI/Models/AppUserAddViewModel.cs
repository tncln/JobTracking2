using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Models
{
    public class AppUserAddViewModel
    {
        [Required( ErrorMessage ="Kullanıcı Adı Alanı Boş Geçilemez.")]
        [Display(Name ="Kullanıcı Adı: ")]
        public string UserName { get; set; }

        [Display(Name ="Parola :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola Alanı Boş Geçilemez.")]
        public string Password { get; set; }

        [Display(Name ="Parolanızı Tekrar Girin")]
        [Compare("Password",ErrorMessage = "Parola Alanı Eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name="Email")]
        [EmailAddress(ErrorMessage ="Geçersiz Email")]
        [Required(ErrorMessage = "Email Alanı Boş Geçilemez.")]
        public string Email { get; set; }

        [Display( Name ="Adınız : ")]
        [Required(ErrorMessage = "Name Alanı Boş Geçilemez.")]
        public string Name { get; set; }

        [Display( Name ="Soyadınız: ")]
        [Required(ErrorMessage = "Surname Alanı Boş Geçilemez.")]
        public string Surname { get; set; }
    }
}
