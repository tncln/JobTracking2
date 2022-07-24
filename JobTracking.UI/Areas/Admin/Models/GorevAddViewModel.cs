using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Areas.Admin.Models
{
    public class GorevAddViewModel
    {
        [Required( ErrorMessage ="Ad Alanı gereklidir.")]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Lütfen bir aciliyet durumu giriniz.")]
        public int AciliyetId { get; set; }

    }
}
