using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using INTEX.Models.ViewModels;

namespace INTEX.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-blah")]
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically create the page links for us

        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        //Different than the view context
        public PageInfo PageBlah { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");


            //PAGE BUFFER DECLARING HERE
            int pagebuffer = 4;
            //1 Page Options
            if (PageBlah.TotalPages == 1)
            {
                for (int i = 1; i == 1; i++)
                {
                    TagBuilder tb = new TagBuilder("a");

                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.InnerHtml.Append(i.ToString());
                    if (PageBlah.CurrentPage == i)
                    {
                        tb.Attributes["class"] = "btn btn-primary";
                    }
                    else
                    {
                        tb.Attributes["class"] = "btn btn-secondary";
                    }

                    final.InnerHtml.AppendHtml(tb);
                }
            }
            //BEGINNING INSTANCE SO THAT YOU DON'T GET NEGATIVE PAGE NUMBERS
            else if (PageBlah.CurrentPage <= pagebuffer || (PageBlah.CurrentPage - pagebuffer) == 1)
            {
                for (int i = 1; i <= 1 + (pagebuffer * 2) && i < PageBlah.TotalPages; i++)
                {
                    TagBuilder tb = new TagBuilder("a");

                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.InnerHtml.Append(i.ToString());
                    if (PageBlah.CurrentPage == i)
                    {
                        tb.Attributes["class"] = "btn btn-primary";
                    }
                    else
                    {
                        tb.Attributes["class"] = "btn btn-secondary";
                    }

                    final.InnerHtml.AppendHtml(tb);
                }
                for (int i = 1; i == 1; i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = PageBlah.TotalPages });
                    tb.Attributes["class"] = "btn btn-secondary";
                    tb.InnerHtml.Append(("..." + PageBlah.TotalPages).ToString());
                    final.InnerHtml.AppendHtml(tb);
                }
            }

            //MIDDLE INSTANCE SO THAT THE PAGE NUMBER YOU HAVE SELECTED IS ALWAYS HIGHLIGHTED AND IT MOVES WITH YOU
            else if (PageBlah.CurrentPage - pagebuffer > 1 && PageBlah.CurrentPage + pagebuffer < PageBlah.TotalPages)
            {
                for (int i = 1; i == 1; i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = 1 });
                    tb.Attributes["class"] = "btn btn-secondary";
                    tb.InnerHtml.Append(("1...").ToString());
                    final.InnerHtml.AppendHtml(tb);
                }

                for (int i = (PageBlah.CurrentPage - pagebuffer); i < PageBlah.CurrentPage; i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.Attributes["class"] = "btn btn-secondary";
                    tb.InnerHtml.Append((i).ToString());
                    final.InnerHtml.AppendHtml(tb);
                }

                for (int i = (PageBlah.CurrentPage); i == PageBlah.CurrentPage; i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.Attributes["class"] = "btn btn-primary";
                    tb.InnerHtml.Append((i).ToString());
                    final.InnerHtml.AppendHtml(tb);
                }

                for (int i = (PageBlah.CurrentPage + 1); i <= (PageBlah.CurrentPage + pagebuffer); i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.Attributes["class"] = "btn btn-secondary";
                    tb.InnerHtml.Append((i).ToString());
                    final.InnerHtml.AppendHtml(tb);
                }
                for (int i = 1; i == 1; i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = PageBlah.TotalPages });
                    tb.Attributes["class"] = "btn btn-secondary";
                    tb.InnerHtml.Append(("..." + PageBlah.TotalPages).ToString());
                    final.InnerHtml.AppendHtml(tb);
                }
            }
            //END INSTANCE SO YOU DON'T GET MORE PAGE NUMBERS THAN ARE POSSIBLE
            else if ((PageBlah.TotalPages - PageBlah.CurrentPage) <= pagebuffer)
            {
                for (int i = 1; i == 1 && i < PageBlah.TotalPages; i++)
                {
                    TagBuilder tb = new TagBuilder("a");
                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = 1 });
                    tb.Attributes["class"] = "btn btn-secondary";
                    tb.InnerHtml.Append(("1...").ToString());
                    final.InnerHtml.AppendHtml(tb);
                }
                for (int i = PageBlah.CurrentPage - pagebuffer; i <= PageBlah.TotalPages; i++)
                {
                    TagBuilder tb = new TagBuilder("a");

                    tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                    tb.InnerHtml.Append(i.ToString());
                    if (PageBlah.CurrentPage == i)
                    {
                        tb.Attributes["class"] = "btn btn-primary";
                    }
                    else
                    {
                        tb.Attributes["class"] = "btn btn-secondary";
                    }

                    final.InnerHtml.AppendHtml(tb);
                }
            }
            tho.Content.AppendHtml(final.InnerHtml);




        }
    }
}
