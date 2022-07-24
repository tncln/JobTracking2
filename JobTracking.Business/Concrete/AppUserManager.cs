using JobTracking.Business.Interfaces;
using JobTracking.DataAccess.Interfaces;
using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<AppUser> GetNotAdmin()
        {
            return _userDal.GetNotAdmin();
        }

        public List<AppUser> GetNotAdmin(out int toplamSayfa,string aranacakKelime, int aktifSayfa)
        {
            return _userDal.GetNotAdmin(out toplamSayfa,aranacakKelime, aktifSayfa);
        }
    }
}
