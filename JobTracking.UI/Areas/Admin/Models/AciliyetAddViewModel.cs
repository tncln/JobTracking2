using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Areas.Admin.Models
{
    public class AciliyetAddViewModel
    {
        [Display(Name="Tanım")]
        [Required(ErrorMessage ="Tanım Alanı Boş Geçilemez")]
        public string Tanim { get; set; }
    }
}
