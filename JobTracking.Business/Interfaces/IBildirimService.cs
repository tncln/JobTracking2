using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.Business.Interfaces
{
    public interface IBildirimService :IGenericService<Bildirim>
    { 
        List<Bildirim> GetirOkunmayanlar(int AppUserId);
    }
}
