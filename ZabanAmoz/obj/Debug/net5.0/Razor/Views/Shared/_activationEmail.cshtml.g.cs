#pragma checksum "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_activationEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41ae4912ecf4d506392a2d85f00944c5075cc790"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__activationEmail), @"mvc.1.0.view", @"/Views/Shared/_activationEmail.cshtml")]
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
#line 1 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\_ViewImports.cshtml"
using ZabanAmoz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\_ViewImports.cshtml"
using Core.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\_ViewImports.cshtml"
using ZabanAmoz.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\_ViewImports.cshtml"
using Domain.Models.Users;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41ae4912ecf4d506392a2d85f00944c5075cc790", @"/Views/Shared/_activationEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5dc471e30a26884ecee2bf8a4c9a2e50ae9912b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__activationEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div style=\"direction:rtl;padding:20px;\">\r\n    <h3>");
#nullable restore
#line 3 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_activationEmail.cshtml"
   Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" عزیز </h3>\r\n    <p>با تشکر از ثبت نام شما جهت فعال سازی روی لینک زیر کلیک نمایید </p>\r\n    <p>\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 186, "\"", 259, 3);
            WriteAttributeValue(" ", 193, "https://localhost:44395/Account/ActiveAccount/", 194, 47, true);
#nullable restore
#line 6 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_activationEmail.cshtml"
WriteAttributeValue("", 240, Model.ActiveCode, 240, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("\r\n", 257, "", 259, 2, true);
            EndWriteAttribute();
            WriteLiteral("> لینک فعالسازی</a>\r\n    </p>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
