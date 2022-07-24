using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.Web.CustomExtensions
{
    public static class SessionExtension
    {
        //session nesnesi geliştirilerek object destekler 
        public static void SetObject(this ISession session,string key, object deger)
        {
            string gelenData = JsonConvert.SerializeObject(deger);
            session.SetString(key, gelenData);
        }
        public static T GetObject<T>(this ISession session,string key)
            where T:class,new() ///Önemli return değeri dönerken null dediğimizde tanımlamaz isek hata verir 
                                //çünkü tipini bilmiyor  O yüzden tanımlıyoruz.
                                //Tipi class ve new lenebilir olduğunu burada belirtiyoruz ki hata olmasın 
        {
            var gelenData= session.GetString(key);
            if (gelenData != null)
            {
               return JsonConvert.DeserializeObject<T>(gelenData);
            }
            return null;
        }
    }
}
