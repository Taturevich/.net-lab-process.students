using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCore.Extensions
{
    public static class HtmlExtensions
    {
        public static HtmlString ImageFor(this IHtmlHelper helper, string src, LocalizedHtmlString alt)
        {
            var tagBuilder = new TagBuilder("img");
            var path = "/" + src;
            tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
            tagBuilder.Attributes.Add("src", path);
            tagBuilder.Attributes.Add("alt", alt.Value);
            using var writer = new System.IO.StringWriter();
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
