using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EditPosts.Views.Views.Helpers
{
    public static  class TopMenuHelper
    {
        public static string TopMenuItem(this HtmlHelper helper, string title, string currentUrl, string url)
        {
            var aWithHref = new TagBuilder("a");
            aWithHref.SetInnerText(title);
            aWithHref.MergeAttribute("href", url);
            var li = new TagBuilder("li");
            li.InnerHtml = aWithHref.ToString();
            if (currentUrl.Equals(url))
                li.AddCssClass("active");
            return li.ToString(TagRenderMode.Normal);
        }
    }
}