using JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using JobTracking.DataAccess.Interfaces;
using JobTracking.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class GenericRepository<Tablo> : IGenericDal<Tablo> where Tablo : class, ITablo, new()
    {
        public List<Tablo> Getirhepsi()
        {
            using (var context = new TodoContext())
            {
                return context.Set<Tablo>().ToList();
            }
        }

        public Tablo GetirIdile(int id)
        {
            using (var context = new TodoContext())
            {
                return context.Set<Tablo>().Find(id);
            }
        }

        public void Guncelle(Tablo tablo)
        {
            using (var context = new TodoContext())
            {
                //Diğer yöntem sıkıntısı: tüm kolonları günceller. Gereksiz performans harcaması  
                //context.Calismalar.Update(tablo);
                context.Entry(tablo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Kaydet(Tablo tablo)
        {
            using (var context = new TodoContext())
            {
                context.Set<Tablo>().Add(tablo);
                context.SaveChanges();
            }
        }

        public void Sil(Tablo tablo)
        {
            using (var context = new TodoContext())
            {
                context.Set<Tablo>().Remove(tablo);
                context.SaveChanges();
            }
        }
    }
}
