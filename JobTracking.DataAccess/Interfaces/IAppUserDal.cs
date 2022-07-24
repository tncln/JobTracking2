using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetNotAdmin();
        List<AppUser> GetNotAdmin(out int toplamSayfa,string aranacakKelime, int aktifSayfa = 1);
    }
}
