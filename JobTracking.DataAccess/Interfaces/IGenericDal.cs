using JobTracking.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.DataAccess.Interfaces
{
    //ITablo amacı: Daha sonra kullanırken rasgele bir class verilmemesi için 
    //Class verirken ITablo ile işaretlenmiş olan class ları kullanabilmesi için
    public interface IGenericDal<Tablo> where Tablo:class,ITablo,new()
    {
        void Kaydet(Tablo tablo);
        void Sil(Tablo tablo);
        void Guncelle(Tablo tablo);
        Tablo GetirIdile(int id);
        List<Tablo> Getirhepsi();
    }
}
