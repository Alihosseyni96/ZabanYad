#pragma checksum "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Message\AdminMessageBody.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e109e3a17f40853bd273cd91a15228556c6cff5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_Message_AdminMessageBody), @"mvc.1.0.razor-page", @"/Pages/Admin/Message/AdminMessageBody.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e109e3a17f40853bd273cd91a15228556c6cff5a", @"/Pages/Admin/Message/AdminMessageBody.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dff40b8c6627c2981ada0d443aa105489a2b5732", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Admin_Message_AdminMessageBody : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<ol class=""breadcrumb"">
    <li class=""breadcrumb-item"">
        <a href=""#"">?????? ????????????</a>
    </li>
    <li class=""breadcrumb-item active"">???????????? ????????    </li>
</ol>

<div class=""header_box col-md-8"">
    <h2 class=""d-inline-block"">???????????? ????????  </h2>
</div>



<div class=""col-md-8"">
    <li>
        <h4>????????  </h4>
        <ul class=""course_list"">
            <li><strong>?????????? ??????????:</strong> ");
#nullable restore
#line 22 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Message\AdminMessageBody.cshtml"
                                         Write(Model.AdminMessagebody.CreateDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n            <li><strong>??????????????: </strong>  ");
#nullable restore
#line 23 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Message\AdminMessageBody.cshtml"
                                       Write(Model.AdminMessagebody.SenderName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n        </ul>\r\n        <h6>??????????:");
#nullable restore
#line 25 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Message\AdminMessageBody.cshtml"
             Write(Model.AdminMessagebody.Messagetitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <hr />\r\n        <h6>?????? ????????:</h6>\r\n        <p> ");
#nullable restore
#line 28 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Pages\Admin\Message\AdminMessageBody.cshtml"
       Write(Html.Raw(Model.AdminMessagebody.MessageBody));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </li>\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZabanAmoz.Pages.Admin.Message.AdminMessageBodyModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZabanAmoz.Pages.Admin.Message.AdminMessageBodyModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZabanAmoz.Pages.Admin.Message.AdminMessageBodyModel>)PageContext?.ViewData;
        public ZabanAmoz.Pages.Admin.Message.AdminMessageBodyModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
