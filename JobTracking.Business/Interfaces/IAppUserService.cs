using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.Business.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNotAdmin();
        List<AppUser> GetNotAdmin(out int toplamSayfa, string aranacakKelime, int aktifSayfa = 1);
    }
}
