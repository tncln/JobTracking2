using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.DataAccess.Interfaces
{
    public interface IRaporDal:IGenericDal<Rapor>
    {
        Rapor GetirGorevileId(int id);
    }
}
