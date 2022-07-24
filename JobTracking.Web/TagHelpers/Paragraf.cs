using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracking.Web.TagHelpers
{
    [HtmlTargetElement("adem")]
    public class Paragraf:TagHelper
    {
        public string GelenData { get; set; } = "Adem Tunçalın";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //string data 
            //tagbuilder
            //stringbuilder

            #region TagBuilder ile Custom tag helper
            //output
            //<p> <b>Adem Tunçalın</b> </p>
            //var tagBuilder = new TagBuilder("p");
            //tagBuilder.InnerHtml.AppendHtml("<b>Adem Tunçalın</b>");
            //output.Content.SetHtmlContent(tagBuilder);

            #endregion

            #region string builder ile tag helper 
            //var stringBuilder = new StringBuilder();
            //stringBuilder.AppendFormat("<p><b> {0} </b></p>", "Adem Tunçalın");
            //output.Content.SetHtmlContent(stringBuilder.ToString());
            #endregion 
            string data = string.Empty;
            data="<p><b>"+GelenData+"</b></p>";
            output.Content.SetHtmlContent(data);
            base.Process(context, output);


        }
    }
}
