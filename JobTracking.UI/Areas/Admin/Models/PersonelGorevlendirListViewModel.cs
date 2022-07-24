using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Areas.Admin.Models
{
    public class PersonelGorevlendirListViewModel
    {
        public AppUserListViewModel  AppUser { get; set; }
        public GorevListViewModel Gorev { get; set; }
    }
}
