using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.DataAccess.Interfaces
{
    public interface IBildirimDal:IGenericDal<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int AppUserId); 
    }
}
