using JobTracking.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using JobTracking.DataAccess.Interfaces;
using JobTracking.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JobTracking.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGorevRepository : GenericRepository<Gorev>, IGorevDal
    {
        public Gorev GetirAciliyetIdile(int id)
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet).FirstOrDefault(y => !y.Durum && y.Id == id);
        }
        public Gorev GetirRaporlarileId(int id)
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Raporlar).Include(x=>x.AppUser).Where(x => x.Id == id).FirstOrDefault() ;
        }

        public List<Gorev> GetirAciliyetIleTamamlanmayan()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet)
                .Where(x => !x.Durum).OrderByDescending(x => x.OlusturulmaTarihi).ToList();
        } 
        public List<Gorev> GetirAppUserIdile(int appUserId)
        {
            using var context = new TodoContext();
            return context.Gorevler.Where(x => x.AppUserId == appUserId).ToList();
        }

        public List<Gorev> GetirTumTablolarla()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser)
                .Where(x => !x.Durum).OrderByDescending(x => x.OlusturulmaTarihi).ToList();
        }

        public List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter)
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(x => x.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser)
                .Where(filter).OrderByDescending(x => x.OlusturulmaTarihi).ToList();
        }

        public List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId,int aktifSayfa=1)
        {
            using var context = new TodoContext();
            var returnValue = context.Gorevler.Include(x => x.Aciliyet).Include(I => I.Raporlar).Include(I => I.AppUser)
               .Where(x => x.AppUserId == userId && x.Durum).OrderByDescending(x => x.OlusturulmaTarihi);
            toplamSayfa =(int) Math.Ceiling((double)returnValue.Count() / 3);
            return returnValue.Skip((aktifSayfa - 1) * 3).Take(3).ToList();
        }
    }
}
