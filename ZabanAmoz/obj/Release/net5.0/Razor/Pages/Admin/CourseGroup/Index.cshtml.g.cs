#pragma checksum "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdaf36dddbd6a8947e7f7c624c39b9cb435a571b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_CourseGroup_Index), @"mvc.1.0.razor-page", @"/Pages/Admin/CourseGroup/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdaf36dddbd6a8947e7f7c624c39b9cb435a571b", @"/Pages/Admin/CourseGroup/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dff40b8c6627c2981ada0d443aa105489a2b5732", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Admin_CourseGroup_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<ol class=""breadcrumb"">
    <li class=""breadcrumb-item"">
        <a href=""#"">پنل مدیریت</a>
    </li>
    <li class=""breadcrumb-item active"">  مدیریت گروه ها </li>
</ol>


<div class=""box_general padding_bottom"">
    <div class=""header_box version_2"">
        <h2><i class=""fa fa-user""></i>مدیریت گروه ها </h2>
    </div>

    <a href=""/Admin/CourseGroup/CreateGroup"" class=""btn btn-secondary""> افزودن گروه جدید</a>
    <br />
    <br />
    <div class=""table-responsive"">
        <table class=""table table-striped table-bordered"">
            <thead>
                <tr>
                    <th scope=""col"">تصویر گروه </th>
                    <th scope=""col"">نام گروه</th>
                    <th scope=""col"">زیر گروه ها</th>
                    <th scope=""col"">دستورات</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 33 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
                 foreach (var mainGroup in Model.CourseGroups.Where(g => g.ParentId == null))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td style=\"width:300px\"><img");
            BeginWriteAttribute("src", " src=\"", 1129, "\"", 1190, 2);
            WriteAttributeValue("", 1135, "/MainGroupImg/fingerImage/", 1135, 26, true);
#nullable restore
#line 36 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
WriteAttributeValue("", 1161, mainGroup.MainGroupImageName, 1161, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1191, "\"", 1199, 0);
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
                       Write(mainGroup.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 39 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
                             if (Model.CourseGroups.Any(g => g.ParentId == mainGroup.GroupId))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <ul>\r\n");
#nullable restore
#line 42 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
                                     foreach (var subGroup in Model.CourseGroups.Where(g => g.ParentId == mainGroup.GroupId))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li>");
#nullable restore
#line 44 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
                                       Write(subGroup.GroupTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 45 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </ul>\r\n");
#nullable restore
#line 47 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1900, "\"", 1972, 2);
            WriteAttributeValue("", 1907, "/Admin/CourseGroup/EditCourseGroup?mainGroupId=", 1907, 47, true);
#nullable restore
#line 51 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
WriteAttributeValue("", 1954, mainGroup.GroupId, 1954, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">تغییرات در گروه و زیرگروه ها </a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 54 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\CourseGroup\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZabanAmoz.Pages.Admin.CourseGroup.IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZabanAmoz.Pages.Admin.CourseGroup.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZabanAmoz.Pages.Admin.CourseGroup.IndexModel>)PageContext?.ViewData;
        public ZabanAmoz.Pages.Admin.CourseGroup.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
