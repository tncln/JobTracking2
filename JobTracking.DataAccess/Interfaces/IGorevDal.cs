using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JobTracking.DataAccess.Interfaces
{
    public interface IGorevDal:IGenericDal<Gorev>
    {
        List<Gorev> GetirAciliyetIleTamamlanmayan();
        List<Gorev> GetirTumTablolarla();
        List<Gorev> GetirTumTablolarla(Expression<Func<Gorev,bool>> filter);
        List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId,int aktifSayfa);
        Gorev GetirAciliyetIdile(int id);
        List<Gorev> GetirAppUserIdile(int appUserId);
        Gorev GetirRaporlarileId(int id);
    }
}
