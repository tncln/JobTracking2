using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Areas.Admin.Models
{
    public class GorevListAllViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; } 
        public DateTime OlusturmaTarihi { get; set; }
         
        public Aciliyet Aciliyet { get; set; }
         
        public AppUser AppUser { get; set; }

        public List<Rapor> Raporlar { get; set; }
    }
}
