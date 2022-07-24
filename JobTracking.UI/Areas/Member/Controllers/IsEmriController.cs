﻿using JobTracking.Business.Interfaces;
using JobTracking.Entity.Concrete;
using JobTracking.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.Areas.Member.Controllers
{
    [Authorize("Member")]
    [Area("Member")]
    public class IsEmriController : Controller
    {
        private readonly IGorevService _gorevService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRaporService _raporService;
        private readonly IBildirimService _bildirimService;
        public IsEmriController(IGorevService gorevService, UserManager<AppUser> userManager, IRaporService raporService, IBildirimService bildirimService)
        {
            _gorevService = gorevService;
            _userManager = userManager;
            _raporService = raporService;
            _bildirimService = bildirimService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "isemri";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var gorevler = _gorevService.GetirTumTablolarla(I => I.AppUserId == user.Id && !I.Durum);
            List<GorevListAllViewModel> models = new List<GorevListAllViewModel>();

            foreach (var item in gorevler)
            {
                GorevListAllViewModel model = new GorevListAllViewModel();
                model.Id = item.Id;
                model.Aciklama = item.Aciklama;
                model.Aciliyet = item.Aciliyet;
                model.Ad = item.Ad;
                model.AppUser = item.AppUser;
                model.Raporlar = item.Raporlar;
                model.OlusturmaTarihi = item.OlusturulmaTarihi;
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult EkleRapor(int id)
        {
            TempData["Active"] = "isemri";
            var gorev = _gorevService.GetirAciliyetIdile(id);
            RaporAddViewModel model = new RaporAddViewModel();
            model.GorevId = id;
            model.Gorev = gorev;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EkleRapor(RaporAddViewModel model)
        {
            TempData["Active"] = "isemri";
            if (ModelState.IsValid)
            {
                _raporService.Kaydet(new Rapor()
                {
                    GorevId = model.GorevId,
                    Detay = model.Detay,
                    Tanim = model.Tanim
                });

                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
                var aktifKullanici = await _userManager.FindByNameAsync(User.Identity.Name);
                foreach (var admin in adminUserList)
                {
                    _bildirimService.Kaydet(new Bildirim
                    {
                        Aciklama = $"{aktifKullanici.Name} {aktifKullanici.Surname} yeni bir rapor yazdı ",
                        AppUserId=admin.Id,

                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult GuncelleRapor(int id)
        {
            TempData["Active"] = "isemri";
            var rapor = _raporService.GetirGorevileId(id);
            RaporUpdateViewModel model = new RaporUpdateViewModel();
            model.Id = rapor.Id;
            model.Tanim = rapor.Tanim;
            model.Detay = rapor.Detay;
            model.Gorev = rapor.Gorev;
            model.GorevId = rapor.GorevId;
            return View(model);
        }
        [HttpPost]
        public IActionResult GuncelleRapor(RaporUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekRapor = _raporService.GetirIdile(model.Id);
                guncellenecekRapor.Tanim = model.Tanim;
                guncellenecekRapor.Detay = model.Detay;

                _raporService.Guncelle(guncellenecekRapor);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> TamamlaGorev(int gorevId)
        {
            var guncellenecekGorev = _gorevService.GetirIdile(gorevId);
            guncellenecekGorev.Durum = true;
            _gorevService.Guncelle(guncellenecekGorev);

            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");
            var aktifKullanici = await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var admin in adminUserList)
            {
                _bildirimService.Kaydet(new Bildirim
                {
                    Aciklama = $"{aktifKullanici.Name} {aktifKullanici.Surname} vermiş olduğunuz görevi tamamladı ",
                    AppUserId = admin.Id,

                });
            }
            //güncel versiyon
            return Json(null);
        }
    }
}
