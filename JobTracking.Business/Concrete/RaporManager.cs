using JobTracking.Business.Interfaces;
using JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using JobTracking.DataAccess.Interfaces;
using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.Business.Concrete
{
    public class RaporManager : IRaporService
    {
        private readonly IRaporDal _raporDal;
        public RaporManager(IRaporDal raporDal)
        {
            _raporDal = raporDal;
        }

        public Rapor GetirGorevileId(int id)
        {
            return _raporDal.GetirGorevileId(id);
        }

        public List<Rapor> Getirhepsi()
        {
            return _raporDal.Getirhepsi();
                
        }

        public Rapor GetirIdile(int id)
        {
            return _raporDal.GetirIdile(id);
        }

        public void Guncelle(Rapor tablo)
        {
            _raporDal.Guncelle(tablo);
        }

        public void Kaydet(Rapor tablo)
        {
            _raporDal.Kaydet(tablo);
        }

        public void Sil(Rapor tablo)
        {
            _raporDal.Sil(tablo);
        }
    }
}
