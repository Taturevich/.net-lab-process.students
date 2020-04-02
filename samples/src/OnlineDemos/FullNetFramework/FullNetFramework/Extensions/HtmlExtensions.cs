using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullNetFramework.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlString ImageFor(this HtmlHelper htmlHelper, string src, string alternativeText)
        {
            var tagBuilder = new TagBuilder("img");
            var fullPath = "~/" + src;
            tagBuilder.Attributes.Add("src", fullPath);
            tagBuilder.Attributes.Add("alt", alternativeText);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
    }
}