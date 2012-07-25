using System.Text.RegularExpressions;

namespace EditPosts.PresentationServices.Utils.Extensions
{
    public static class StringExtension
    {
        public static string AsHtmlPreview(this string str, int maxLength)
        {
            const string pattern = "<[^>]*>";
            var regexp = new Regex(pattern);
            var fullPreview = regexp.Replace(str.Replace("\t", string.Empty).Replace("\r", string.Empty)
                .Replace("\n", string.Empty).Replace("&nbsp", string.Empty).Replace("&msdash", string.Empty), " ");
            return fullPreview.Length > maxLength ? fullPreview.Substring(0, maxLength) : fullPreview;
        }
    }
}