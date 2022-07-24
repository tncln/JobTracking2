using JobTracking.Web.CustomExtensions;
using JobTracking.Web.CustomFilters;
using JobTracking.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KayitOl()
        {
            return View();
        }
        [AdAdemOlamaz]
        [HttpPost]
        public IActionResult KayitOl2(KullaniciKayitViewModal model)
        {
            return View();
        }
        public void SetCookie()
        {
            HttpContext.Response.Cookies.Append("kisi", "Adem", new Microsoft.AspNetCore.Http.CookieOptions() {
             Expires=DateTime.Now.AddDays(20),
             HttpOnly=true,//Javascript e karşı kapatmış oluruz XSS açıklarına karşı koruma
             SameSite=Microsoft.AspNetCore.Http.SameSiteMode.Strict //İlgili web sayfası görebilir  
            });
        }
        public string GetCookie()
        {
            return HttpContext.Request.Cookies["kisi"];
        }
        public void SetSession()
        {
            HttpContext.Session.SetObject("kisi", new KullaniciKayitViewModal() { Ad = "Adem", Soyad="Tunçalın" });
           // HttpContext.Session.SetString("kisi","adem");
        }
        public KullaniciKayitViewModal GetSession()
        {
            return HttpContext.Session.GetObject<KullaniciKayitViewModal>("kisi");
        }
        public IActionResult PageError(int code)
        {
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            CustomLogger.NLogLogger nloglogger= new  CustomLogger.NLogLogger();
            nloglogger.LogWithNLog($"Hatanın oluştuğu yer {exceptionHandlerPathFeature.Path} " +
                $"\n Hata Mesajı" +
                $" {exceptionHandlerPathFeature.Error.Message} \n" +
                $"stack trace {exceptionHandlerPathFeature.Error.StackTrace}");
            //Hatanın oluştuğu yer
            ViewBag.path= exceptionHandlerPathFeature.Path;
            ViewBag.message = exceptionHandlerPathFeature.Error.Message; 
            return View();
        }
        public IActionResult Hata()
        {
            throw new Exception("Hata Oluştu");
        }
    }
}
