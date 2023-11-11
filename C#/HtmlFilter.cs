using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Linq;

class HtmlFilter
{
    /*
    This class is for Filtering html string wiht helpf regex, HtmlAgilityPack;
    */
    public string Filter1(string body, string[] allowedTags)
    {
        /*
        body : its a string which contains html tags and ints contents.
        allowedTags : all the tags which has been allowed.
        return : string after filrter only with the allowed tags and its content.
        */
        string pattern = @"<((?!\/?(" + string.Join("|", allowedTags); +"))[^>]+)>(.*?)<\/\1>";
        return Regex.Replace(html, pattern, string.Empty);
    }
    public string Filter2(string body, string[] allowedTags)
    {
        /*
        body : its a string which contains html tags and ints contents.
        allowedTags : all the tags which has been allowed.
        return : string after filrter only with the allowed tags and its content.
        */
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        foreach (var node in doc.DocumentNode.Descendants().ToList())
        {
            if (!allowedTags.Contains(node.Name))
            {
                try
                {
                    node.ParentNode.ReplaceChild(HtmlNode.CreateNode(node.InnerHtml), node);
                }
                catch { }
            }
        }
        return doc.DocumentNode.OuterHtml;
    }
}