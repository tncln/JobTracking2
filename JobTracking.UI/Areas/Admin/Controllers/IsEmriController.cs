using JobTracking.Business.Interfaces;
using JobTracking.Entity.Concrete;
using JobTracking.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class IsEmriController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IGorevService _gorevService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDosyaService _dosyaService;
        private readonly IBildirimService _bildirimService;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService, UserManager<AppUser> userManager, IDosyaService dosyaService, IBildirimService bildirimService)
        {
            _appUserService = appUserService;
            _gorevService = gorevService;
            _userManager = userManager;
            _dosyaService = dosyaService;
            _bildirimService = bildirimService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "isemri";
            //var model = _appUserService.GetNotAdmin();
            List<Gorev> gorevler= _gorevService.GetirTumTablolarla();
            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            foreach (var item in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Id = item.Id;
                model.Aciklama = item.Aciklama;
                model.Aciliyet = item.Aciliyet;
                model.Ad = item.Ad;
                model.AppUser = item.AppUser;
                model.OlusturmaTarihi = item.OlusturulmaTarihi;
                model.Raporlar = item.Raporlar;
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult Detaylandir(int id)
        {
            TempData["Active"] = "isemri"; 
            var gorev= _gorevService.GetirRaporlarileId(id);
            GorevListAllViewModel model = new GorevListAllViewModel();
            model.Id = gorev.Id; 
            model.Raporlar = gorev.Raporlar; 
            model.Ad = gorev.Ad;
            model.Aciklama = gorev.Aciklama;
            model.AppUser = gorev.AppUser;
            return View(model);
        }
        public IActionResult AtaPersonel(int id,string s,int sayfa=1)
        {
            TempData["Active"] = "isemri";
            ViewBag.AktifSayfa = sayfa;
            //ViewBag.ToplamSayfa = (int)Math.Ceiling((double)_appUserService.GetNotAdmin().Count / 3);
            ViewBag.Aranan = s;

            int toplamSaya;

            var gorev = _gorevService.GetirAciliyetIdile(id);
                      

            var personeller = _appUserService.GetNotAdmin(out toplamSaya, s,sayfa);

            ViewBag.ToplamSayfa = toplamSaya;

            List<AppUserListViewModel> appUserListModel = new List<AppUserListViewModel>();
            foreach (var item in personeller)
            {
                AppUserListViewModel model = new AppUserListViewModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.SurName = item.Surname;
                model.Email = item.Email;
                model.Picture = item.Picture;
                appUserListModel.Add(model);
            }

            ViewBag.Personeller = personeller;

            GorevListViewModel gorevModel = new GorevListViewModel();
            gorevModel.Id = gorev.Id;
            gorevModel.Ad = gorev.Ad;
            gorevModel.Aciklama = gorev.Aciklama;
            gorevModel.Aciliyet = gorev.Aciliyet;
            gorevModel.OlusturmaTarihi = gorev.OlusturulmaTarihi;
            return View(gorevModel);
        }
        public IActionResult GetirExcel(int id)
        { 
            return File(_dosyaService.AktarExcel(_gorevService.GetirRaporlarileId(id).Raporlar),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",Guid.NewGuid()+".xlsx");
        }
        public IActionResult GetirPdf(int id)
        {
            var path = _dosyaService.AktarPdf(_gorevService.GetirRaporlarileId(id).Raporlar);
            return File(path,"application/pdf",Guid.NewGuid()+".pdf");
        }
        //bildirim gönderilecek
        [HttpPost]
        public IActionResult AtaPersonel(PersonelGorevlendirViewModel model)
        {
            var guncellenecekGorev= _gorevService.GetirIdile(model.GorevId);
            guncellenecekGorev.AppUserId = model.PersonelId;

            _gorevService.Guncelle(guncellenecekGorev);

            _bildirimService.Kaydet(new Bildirim
            {
                AppUserId = model.PersonelId,
                Aciklama= $"{guncellenecekGorev.Ad} adlı iş için görevlendirildiniz."
            });
            return RedirectToAction("Index");
        }
        public IActionResult GorevlendirPersonel(PersonelGorevlendirViewModel model)
        {
            TempData["Active"] = "isemri";
            var user= _userManager.Users.FirstOrDefault(x => x.Id == model.PersonelId);
            var gorev = _gorevService.GetirAciliyetIdile(model.GorevId);
            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Picture = user.Picture;
            userModel.SurName = user.Surname;
            userModel.Email = user.Email;

            GorevListViewModel gorevModel = new GorevListViewModel();
            gorevModel.Id = gorev.Id;
            gorevModel.Aciklama = gorev.Aciklama;
            gorevModel.Aciliyet = gorev.Aciliyet;
            gorevModel.Ad = gorev.Ad;

            PersonelGorevlendirListViewModel personelGorevlendirModel = new PersonelGorevlendirListViewModel();
            personelGorevlendirModel.AppUser = userModel;
            personelGorevlendirModel.Gorev = gorevModel;
            return View(personelGorevlendirModel);
        }
    }
}
