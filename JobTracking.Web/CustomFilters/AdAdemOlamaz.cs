using JobTracking.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.Web.CustomFilters
{
    public class AdAdemOlamaz : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //model değeri action da tanımlanan modeli temsil eder. 
            var dictionaryGelen= context.ActionArguments.Where(x => x.Key == "model").FirstOrDefault();
            var model = (KullaniciKayitViewModal)dictionaryGelen.Value;

            if (model.Ad.ToLower() == "Adem")
            {
                context.Result = new RedirectResult("\\Home\\Error");
            }

            
        }
    }
}
