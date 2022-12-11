#pragma checksum "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71af5fe926ea5cf08eca76f53f389ae513a809d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserPanel_Views_Home_Index), @"mvc.1.0.view", @"/Areas/UserPanel/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\_ViewImports.cshtml"
using ZabanAmoz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\_ViewImports.cshtml"
using Core.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\_ViewImports.cshtml"
using ZabanAmoz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\_ViewImports.cshtml"
using Domain.Models.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\_ViewImports.cshtml"
using Core.Convertors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\_ViewImports.cshtml"
using Core.IServices;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71af5fe926ea5cf08eca76f53f389ae513a809d8", @"/Areas/UserPanel/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"709e829c7e13aeaac9264b6dfdda4562f83398f2", @"/Areas/UserPanel/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_UserPanel_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserPanelDetailsViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<link rel=""shortcut icon"" href=""/img/favicon.ico"" type=""image/x-icon"">
<link rel=""apple-touch-icon"" type=""image/x-icon"" href=""/img/apple-touch-icon-57x57-precomposed.png"">
<link rel=""apple-touch-icon"" type=""image/x-icon"" sizes=""72x72"" href=""/img/apple-touch-icon-72x72-precomposed.png"">
<link rel=""apple-touch-icon"" type=""image/x-icon"" sizes=""114x114"" href=""/img/apple-touch-icon-114x114-precomposed.png"">
<link rel=""apple-touch-icon"" type=""image/x-icon"" sizes=""144x144"" href=""/img/apple-touch-icon-144x144-precomposed.png"">


<ol class=""breadcrumb"">
    <li class=""breadcrumb-item"">
        <a href=""#"">داشبورد</a>
    </li>
    <li class=""breadcrumb-item active""> جزئیات پروفایل </li>
</ol>


<div class=""box_general padding_bottom"">
    <div class=""header_box version_2"">
        <h2><i class=""fa fa-user""></i>جزئیات پروفایل</h2>
    </div>

    <div class="" col-md-4"" style=""padding-top: 0px;margin-right:500px; padding-bottom: 1px; position: static; transform: none; left: 1251.5px; top: 0px;"">
 ");
            WriteLiteral("       <div class=\"profile\">\r\n            <figure style=\"margin-right:80px;margin-top:25px;padding-bottom:20px\"><img");
            BeginWriteAttribute("src", " src=\"", 1174, "\"", 1205, 2);
            WriteAttributeValue("", 1180, "/UserImg/", 1180, 9, true);
#nullable restore
#line 25 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\Home\Index.cshtml"
WriteAttributeValue("", 1189, Model.ImageName, 1189, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""max-width:250px"" alt=""Teacher"" class=""rounded-circle""></figure>
            <ul class=""social_teacher"">
                <li><a href=""#""><i class=""icon-facebook""></i></a></li>
                <li><a href=""#""><i class=""icon-twitter""></i></a></li>
                <li><a href=""#""><i class=""icon-linkedin""></i></a></li>
                <li><a href=""#""><i class=""icon-email""></i></a></li>
            </ul>
            <ul>
                <li>نام کاربری <span class=""float-right"">");
#nullable restore
#line 33 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\Home\Index.cshtml"
                                                    Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span> </li>\r\n                <li>ایمیل <span class=\"float-right\">");
#nullable restore
#line 34 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\Home\Index.cshtml"
                                               Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                <li>شماره تماس <span class=\"float-right\">");
#nullable restore
#line 35 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\Home\Index.cshtml"
                                                    Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                <li>نوع کاربر  <span class=\"float-right\">عادی</span></li>\r\n                <li> موجودی کیف پول  <span class=\"float-right\">");
#nullable restore
#line 37 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\Home\Index.cshtml"
                                                          Write(Model.WalletRest.ToString("#,0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span></li>\r\n                <li>تاریخ عضویت <span class=\"float-right\">");
#nullable restore
#line 38 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Areas\UserPanel\Views\Home\Index.cshtml"
                                                     Write(Model.RegisterDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></li>
            </ul>
        </div><div class=""resize-sensor"" style=""position: absolute; inset: 0px; overflow: hidden; z-index: -1; visibility: hidden;""><div class=""resize-sensor-expand"" style=""position: absolute; left: 0; top: 0; right: 0; bottom: 0; overflow: hidden; z-index: -1; visibility: hidden;""><div style=""position: absolute; left: 0px; top: 0px; transition: all 0s ease 0s; width: 295px; height: 1281px;""></div></div><div class=""resize-sensor-shrink"" style=""position: absolute; left: 0; top: 0; right: 0; bottom: 0; overflow: hidden; z-index: -1; visibility: hidden;""><div style=""position: absolute; left: 0; top: 0; transition: 0s; width: 200%; height: 200%""></div></div></div>
    </div>
</div>






");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"/js/jquery-2.2.4.min.js\"></script>\r\n    <script src=\"/js/common_scripts.js\"></script>\r\n    <script src=\"/js/main.js\"></script>\r\n    <script src=\"/assets/validate.js\"></script>\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserPanelDetailsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591