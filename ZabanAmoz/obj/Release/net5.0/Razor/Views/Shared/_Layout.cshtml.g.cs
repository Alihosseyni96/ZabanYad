#pragma checksum "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5552040401b952b58a34ffec817a67c71aebf9f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
using Core.IServices;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5552040401b952b58a34ffec817a67c71aebf9f", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5dc471e30a26884ecee2bf8a4c9a2e50ae9912b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/stylesheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/pure_rte.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/CourseList/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pure_rte_lite.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
  
    bool showAdminButton = _indexService.ShowAdminButton();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!DOCTYPE html>
<!-- saved from url=(0040)http://www.ansonika.com/udema/index.html -->
<!-- Mirrored from mwhtml.ir/udema/html_menu_1/index.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 12 Sep 2022 19:39:54 GMT -->
<meta http-equiv=""X-UA-Compatible"" content=""IE=Edge"" />

<html lang=""en"">

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5552040401b952b58a34ffec817a67c71aebf9f7523", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
    <meta name=""description"" content=""Udema a modern educational site template"">
    <meta name=""author"" content=""Ansonika"">
    <title>ZabanYad | زبان یاد    </title>

    <!-- Favicons-->
    <link rel=""shortcut icon"" href=""/img/favicon.ico"" type=""image/x-icon"">
    <link rel=""apple-touch-icon"" type=""/image/x-icon"" href=""/img/apple-touch-icon-57x57-precomposed.png"">
    <link rel=""apple-touch-icon"" type=""/image/x-icon"" sizes=""72x72"" href=""/img/apple-touch-icon-72x72-precomposed.png"">
    <link rel=""apple-touch-icon"" type=""/image/x-icon"" sizes=""114x114"" href=""/img/apple-touch-icon-114x114-precomposed.png"">
    <link rel=""apple-touch-icon"" type=""/image/x-icon"" sizes=""144x144"" href=""/img/apple-touch-icon-144x144-precomposed.png"">

    <!-- BASE CSS -->
    <link href=""/css/bootstrap.min.css"" rel=""stylesheet"">
    <link ");
                WriteLiteral("href=\"/css/style.css\" rel=\"stylesheet\">\r\n    <link href=\"/css/vendors.css\" rel=\"stylesheet\">\r\n    <link href=\"/css/icon_fonts/css/all_icons.min.css\" rel=\"stylesheet\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5552040401b952b58a34ffec817a67c71aebf9f9085", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f5552040401b952b58a34ffec817a67c71aebf9f10263", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <!-- YOUR CUSTOM CSS -->\r\n    <link href=\"/css/custom.css\" rel=\"stylesheet\">\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5552040401b952b58a34ffec817a67c71aebf9f12248", async() => {
                WriteLiteral(@"

    <div id=""page"">

        <header class=""header menu_2"">
            <div id=""preloader""><div data-loader=""circle-side""></div></div><!-- /Preload -->
            <div id=""logo"">
                <a href=""/""><img src=""/img/logo.png"" width=""149"" height=""42"" data-retina=""true""");
                BeginWriteAttribute("alt", " alt=\"", 2136, "\"", 2142, 0);
                EndWriteAttribute();
                WriteLiteral("></a>\r\n            </div>\r\n            <ul id=\"top_menu\">\r\n");
#nullable restore
#line 51 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
                 if (User.Identity.IsAuthenticated)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <li class=""hidden_tablet"">
                        <a href=""/Account/Logout"" class=""btn_1 rounded  icon-logout-1 "">خروج</a>
                    </li>
                    <li class=""hidden_tablet"">
                        <a href=""/BuyCourse/ShowCart"" class=""btn_1 rounded  icon-cart "">سبد خرید</a>
                    </li>
");
#nullable restore
#line 59 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"

                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li class=\"hidden_tablet \"><a href=\"/Account/Login\" class=\"btn_1 rounded icon-login-1 \">ورود</a></li>\r\n                    <li class=\"hidden_tablet\"><a href=\"/Account/Register\" class=\"btn_1 rounded \">ثبت نام</a></li>\r\n");
#nullable restore
#line 65 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </ul>
            <!-- /top_menu -->
            <a href=""#menu"" class=""btn_mobile"">
                <div class=""hamburger hamburger--spin"" id=""hamburger"">
                    <div class=""hamburger-box"">
                        <div class=""hamburger-inner""></div>
                    </div>
                </div>
            </a>
            <nav id=""menu"" class=""main-menu  "">
                <ul>
                    <li class=""text-left""><span><a href=""/Home/Index"" target=""_parent"">  خانه   </a></span></li>
                    <li class=""text-left""><span><a href=""/CourseList/Index"" target=""_parent""> لیست تمامی دوره ها </a></span></li>
                    ");
#nullable restore
#line 80 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
               Write(await Component.InvokeAsync("MainSideBarGroupsComponent"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 81 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
                     if (showAdminButton)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"text-left\"><span><a href=\"/Admin/Dashboard/Index\" target=\"_parent\"> پنل مدیریت سایت </a></span></li>\r\n");
#nullable restore
#line 84 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
                     if (User.Identity.IsAuthenticated)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <li class=""text-left""><span><a href=""/UserPanel/Home/Index"" target=""_parent""> پنل کاربری شما  </a></span></li>
                        <li class=""text-left d-lg-none ""><span><a href=""/Account/Logout"" target=""_parent"">  خروج   </a></span></li>
");
#nullable restore
#line 90 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
                     if (!User.Identity.IsAuthenticated)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <li class=""text-left d-lg-none ""><span><a href=""/Account/Register"" target=""_parent"">  ثبت نام   </a></span></li>
                        <li class=""text-left d-lg-none ""><span><a href=""/Account/Login"" target=""_parent"">  ورود   </a></span></li>
");
#nullable restore
#line 96 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </ul>\r\n            </nav>\r\n            <!-- Search Menu -->\r\n            <div class=\"search-overlay-menu\">\r\n                <span class=\"search-overlay-close\"><span class=\"closebt\"><i class=\"ti-close\"></i></span></span>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5552040401b952b58a34ffec817a67c71aebf9f17726", async() => {
                    WriteLiteral("\r\n                    <input");
                    BeginWriteAttribute("value", " value=\"", 5028, "\"", 5036, 0);
                    EndWriteAttribute();
                    WriteLiteral(" name=\"searchKey\" type=\"search\" placeholder=\"جستجو...\" />\r\n                    <button type=\"submit\">\r\n                        <i class=\"icon_search\"></i>\r\n                    </button>\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div><!-- End Search Menu -->
        </header>
        <!-- /header -->

        <main>
            <section class=""hero_single version_2"">
                <div class=""wrapper"">
                    <div class=""container"">
                        ");
#nullable restore
#line 118 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
                   Write(RenderSection("Header",false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </section>\r\n            <!-- /hero_single -->\r\n            ");
#nullable restore
#line 123 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            <!--/call_section-->
        </main>
        <!-- /main -->

        <footer>
            <div class=""container margin_120_95"">
                <div class=""row"">
                    <div class=""col-lg-5 col-md-12 p-r-5"">
                        <p><img src=""/img/logo.png"" width=""149"" height=""42"" data-retina=""true""");
                BeginWriteAttribute("alt", " alt=\"", 6022, "\"", 6028, 0);
                EndWriteAttribute();
                WriteLiteral(@"></p>
                        <p> این سایت صرفا یک نمونه ازمایشی است با محتوای کپی برداری شده که با یک قالب آماده و تکنولوژی قدرتمتند .net نوشته شده است </p>
                    </div>
                    <div class=""col-lg-3 col-md-6 ml-lg-auto"">
                        <h5>لینک های مفید</h5>
                        <ul class=""links"">
                            <li><a href=""/Account/Register"">پذیرش</a></li>
                            <li><a href=""/Account/Login"">ورود</a></li>
                        </ul>
                    </div>
                    <div class=""col-lg-3 col-md-6"">
                        <h5>تماس با ما</h5>
                        <ul class=""contacts"">
                            <li><a");
                BeginWriteAttribute("href", " href=\"", 6759, "\"", 6766, 0);
                EndWriteAttribute();
                WriteLiteral("><i class=\"ti-mobile\"></i> 09386562888</a></li>\r\n                            <li><a");
                BeginWriteAttribute("href", " href=\"", 6850, "\"", 6857, 0);
                EndWriteAttribute();
                WriteLiteral(@"><i class=""ti-email""></i> seyedalilatifhosseyni@gmail.com</a></li>
                        </ul>
                        <div id=""newsletter"">
                        </div>
                    </div>
                </div>
                <!--/row-->
                <hr>
                <div class=""row"">
                    <div class=""col-md-8"">
                    </div>
                    <div class=""col-md-4"">
                        <div id=""copy"">  این سایت صرفا یک نمونه ازمایشی است با محتوای کپی برداری شده که با یک قالب آماده و تکنولوژی قدرتمتند .net نوشته شده است</div>
                    </div>
                </div>
            </div>
        </footer>
        <!--/footer-->
    </div>
    <!-- page -->
    <!-- COMMON SCRIPTS -->
    <script src=""/js/jquery-2.2.4.min.js""></script>
    <script src=""/js/common_scripts.js""></script>
    <script src=""/js/main.js""></script>
    <script src=""/assets/validate.js""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5552040401b952b58a34ffec817a67c71aebf9f23412", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js\"></script>\r\n\r\n    ");
#nullable restore
#line 174 "C:\Users\Microsoft\Desktop\ZabanAmoz\ZabanAmoz\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts",false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- Mirrored from mwhtml.ir/udema/html_menu_1/index.html by HTTrack Website Copier/3.x [XR&CO\'2014], Mon, 12 Sep 2022 19:40:51 GMT -->\r\n</html>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IIndexService _indexService { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
