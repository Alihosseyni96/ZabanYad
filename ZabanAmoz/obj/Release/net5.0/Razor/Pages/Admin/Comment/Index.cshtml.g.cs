#pragma checksum "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5f24c5ec0cffdd40caada4e178fe7c0fe23874e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_Comment_Index), @"mvc.1.0.razor-page", @"/Pages/Admin/Comment/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\_ViewImports.cshtml"
using ZabanAmoz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\_ViewImports.cshtml"
using Core.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\_ViewImports.cshtml"
using ZabanAmoz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\_ViewImports.cshtml"
using Domain.Models.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\_ViewImports.cshtml"
using Core.Convertors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\_ViewImports.cshtml"
using Core.Convertors.Core.Convertors;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5f24c5ec0cffdd40caada4e178fe7c0fe23874e", @"/Pages/Admin/Comment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dff40b8c6627c2981ada0d443aa105489a2b5732", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Admin_Comment_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control col-md-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("?????????? ???? ????????(??????-?????? ????????)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
  
    int currentComment = Model.Comments.Item1.Count();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""mainElement"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item"">
            <a href=""#"">?????? ????????????</a>
        </li>
        <li class=""breadcrumb-item active"">  ????????????   ?????? ???? ?? ???????? ???????? ???? </li>
    </ol>


    <div class=""box_general padding_bottom"">
        <div class=""header_box version_2"">
            <h2><i class=""fa fa-user""></i>  ????????????   ?????? ???? ?? ???????? ???????? ????  </h2>
        </div>
        <div>


            <br />
            <hr />
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5f24c5ec0cffdd40caada4e178fe7c0fe23874e6892", async() => {
                WriteLiteral("\r\n                <button class=\"btn btn-primary me-1\" type=\"submit\">??????????</button>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a5f24c5ec0cffdd40caada4e178fe7c0fe23874e7255", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                                                WriteLiteral(ViewData["SearchKey"]);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 26 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.SearchBox);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>

        <br />
        <br />
        <div class=""table-responsive"">
            <table class=""table  table-bordered"">
                <thead>
                    <tr>
                        <th scope=""col""> ?????? ??????  </th>
                        <th scope=""col""> ???????? ????????    </th>
                        <th scope=""col"">?????????? ?????????? </th>
                        <th scope=""col"">?????????? ??????????  </th>
                        <th scope=""col"">?????????? ???????? ???? </th>
                        <th scope=""col"">??????????????   </th>

                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 46 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                     foreach (var comment in Model.Comments.Item1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 49 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                           Write(comment.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 50 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                           Write(comment.CourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 51 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                           Write(comment.CreateDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td><i");
            BeginWriteAttribute("class", " class=\"", 1918, "\"", 1983, 1);
#nullable restore
#line 52 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 1926, (comment.Show)?"icon-ok-circled":"icon-cancel-circled", 1926, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i></td>\r\n                            <td>");
#nullable restore
#line 53 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                           Write(comment.Replyies);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2120, "\"", 2182, 2);
            WriteAttributeValue("", 2127, "/Admin/Comment/CommentBody?commentId=", 2127, 37, true);
#nullable restore
#line 55 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2164, comment.CommentId, 2164, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">?????????? ?????? ?? ???????? ????    </a>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2271, "\"", 2389, 6);
            WriteAttributeValue("", 2278, "/Admin/Comment/DeleteComment?commentId=", 2278, 39, true);
#nullable restore
#line 56 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2317, comment.CommentId, 2317, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2335, "&take=", 2335, 6, true);
#nullable restore
#line 56 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2341, currentComment, 2341, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2356, "&searchKey=", 2356, 11, true);
#nullable restore
#line 56 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2367, ViewData["SearchKey"], 2367, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">??????   </a>\r\n");
#nullable restore
#line 57 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                                 if (comment.Show)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2551, "\"", 2669, 6);
            WriteAttributeValue("", 2558, "/Admin/Comment/NoShowComment?commentId=", 2558, 39, true);
#nullable restore
#line 59 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2597, comment.CommentId, 2597, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2615, "&take=", 2615, 6, true);
#nullable restore
#line 59 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2621, currentComment, 2621, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2636, "&searchKey=", 2636, 11, true);
#nullable restore
#line 59 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2647, ViewData["SearchKey"], 2647, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">?????? ??????????   </a>\r\n");
#nullable restore
#line 60 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"

                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2858, "\"", 2974, 6);
            WriteAttributeValue("", 2865, "/Admin/Comment/ShowComment?commentId=", 2865, 37, true);
#nullable restore
#line 64 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2902, comment.CommentId, 2902, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2920, "&take=", 2920, 6, true);
#nullable restore
#line 64 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2926, currentComment, 2926, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2941, "&searchKey=", 2941, 11, true);
#nullable restore
#line 64 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 2952, ViewData["SearchKey"], 2952, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">??????????   </a>\r\n");
#nullable restore
#line 65 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 68 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n\r\n\r\n");
#nullable restore
#line 75 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
      
        int take = Model.Comments.Item1.Count() + 5;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
     if (Model.Comments.Item1.Count() < Model.Comments.Item2)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"text-center add_top_60\"><a");
            BeginWriteAttribute("href", " href=\"", 3400, "\"", 3471, 4);
            WriteAttributeValue("", 3407, "/Admin/Comment/Index?take=", 3407, 26, true);
#nullable restore
#line 81 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 3433, take, 3433, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3438, "&searchKey=", 3438, 11, true);
#nullable restore
#line 81 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"
WriteAttributeValue("", 3449, ViewData["SearchKey"], 3449, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn_1 rounded\">???????????????? ??????????</a></p>\r\n");
#nullable restore
#line 82 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Comment\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZabanAmoz.Pages.Admin.Comment.IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZabanAmoz.Pages.Admin.Comment.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZabanAmoz.Pages.Admin.Comment.IndexModel>)PageContext?.ViewData;
        public ZabanAmoz.Pages.Admin.Comment.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
