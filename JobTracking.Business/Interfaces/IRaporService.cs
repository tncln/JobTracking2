using JobTracking.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTracking.Business.Interfaces
{
    public interface IRaporService:IGenericService<Rapor>
    {
        Rapor GetirGorevileId(int id);
    }
}
