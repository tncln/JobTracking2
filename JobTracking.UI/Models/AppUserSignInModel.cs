using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Models
{
    public class AppUserSignInModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Bırakılamaz")]
        [Display(Name ="Kullanıcı Adı:")]
        public string UserName { get; set; }

        [Display(Name = "Parola :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola Alanı Boş Geçilemez.")]
        public string Password { get; set; }

        [Display(Name ="Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
