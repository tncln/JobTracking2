using JobTracking.Business.Interfaces;
using JobTracking.Entity.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.UI.TagHelpers
{
    //Nerede çalıştığı belirtilir
    [HtmlTargetElement("getirGorevAppUserId")]
    public class GorevAppUserIdTagHelper:TagHelper
    {
        private readonly IGorevService _gorevService;
        public GorevAppUserIdTagHelper(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }
        //Alınacak parametre
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Gorev> gorevler= _gorevService.GetirAppUserIdile(AppUserId);
            int tamamlananGorevSayisi= gorevler.Where(x => x.Durum).Count();
            int ustundeCalistigiGorevSayisi = gorevler.Where(x => !x.Durum).Count();
            string htmlString = $"<strong> Tamamladığı görev sayısı : </strong> {tamamlananGorevSayisi} <br> <strong> Üstünde çalıştığı görev sayısı: </strong> {ustundeCalistigiGorevSayisi}";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
