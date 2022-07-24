using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.Web.ViewComponents
{
    public class Urunler:ViewComponent
    {
        //Kendi kendine çalışan asenkron bir yapı
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
