#pragma checksum "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2af96737e7d3732e5f5439a0a1b4d6d01d448766"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
#line 1 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\_ViewImports.cshtml"
using Diploma.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\_ViewImports.cshtml"
using Diploma.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\_ViewImports.cshtml"
using Diploma.WebUI.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\_ViewImports.cshtml"
using Diploma.WebUI.Models.FormModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\_ViewImports.cshtml"
using Diploma.WebUI.Models.Entities.Membership;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\_ViewImports.cshtml"
using Diploma.WebUI.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2af96737e7d3732e5f5439a0a1b4d6d01d448766", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf07fe1e9be5bac76b1974758083a30d21862891", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Author>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-current", new global::Microsoft.AspNetCore.Html.HtmlString("page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/styles/style1.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<nav class=""navbar navbar-expand navbar-dark fixed-top border "" aria-label=""Offcanvas navbar large"">
    <div class=""container d-flex align-items-center"" style=""height: 60px;"">
        <a class=""navbar-brand "" href=""#""> <img src=""	https://www.freeiconspng.com/thumbs/graduation-cap/high-resolution-graduation-cap-png-icon-17.png"" alt=""Logo"" width=""50"" height=""44""></a>
        <button class=""navbar-toggler"" type=""button"" data-bs-toggle=""offcanvas"" data-bs-target=""#offcanvasNavbar2"" aria-controls=""offcanvasNavbar2"" aria-label=""Toggle navigation"">
            <span class=""navbar-toggler-icon""></span>
        </button>
        <div class=""offcanvas offcanvas-end "" style=""background-color: rgb(52,72,103);"" tabindex=""-1"" id=""offcanvasNavbar2"" aria-labelledby=""offcanvasNavbar2Label"">
            <div class=""offcanvas-header"">
                <h5 class=""offcanvas-title"" id=""offcanvasNavbar2Label"">Offcanvas</h5>
                <button type=""button"" class=""btn-close btn-close-white"" data-bs-dismiss=""offcanvas");
            WriteLiteral("\" aria-label=\"Close\"></button>\r\n            </div>\r\n            <div class=\"offcanvas-body\">\r\n                <ul class=\"navbar-nav justify-content-center flex-grow-1 pe-3\">\r\n                    <li class=\"nav-item\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2af96737e7d3732e5f5439a0a1b4d6d01d4487667649", async() => {
                WriteLiteral("Ana Səhifə");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</nav>\r\n<!-- /Breadcrumb -->\r\n<img id=\"backgr\" src=\"banner01.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 1591, "\"", 1597, 0);
            EndWriteAttribute();
            WriteLiteral(@">
<div class=""container "" style=""position: relative;"">
    <div class=""main-body "" style=""position: absolute; top: 100px ; width: 100%;"">
        <div class=""row gutters-sm mt-4  "">
            <div class=""col-md-4 mb-3"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""d-flex flex-column align-items-center text-center"">
                            <div class=""mt-3"">
                                <h4>");
#nullable restore
#line 37 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml"
                                Write(Model.Name + " " + Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            WriteLiteral(@"            </div>
            <div class=""col-md-8"">
                <div class=""col-md-12"">
                    <div class=""card mb-3"">

                        <div class=""card-body "">
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Ad və Soyadınız</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
#nullable restore
#line 77 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml"
                                Write(Model.Name + " " + Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Email Adresiniz</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
#nullable restore
#line 86 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml"
                               Write(Model.DiplomaUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Ata adı</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
#nullable restore
#line 95 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml"
                               Write(Model.FatherName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Bioqrafi</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
#nullable restore
#line 104 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml"
                               Write(Model.Biography);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                            <div class=""row"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Elmi Dərəcə</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    ");
#nullable restore
#line 113 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Account\Profile.cshtml"
                               Write(Model.AcademicDegree.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                            <hr>
                        </div>

                    </div>
                </div>
                <!--<div class=""col-md-12"">
                    <div class=""row"">
                        <div class=""col-md-4 text-center box col-sm-6"">-->
                            <!-- Select2 css -->
                            <!--<div class=""select"">
                                <select name=""format"" id=""format"">
                                    <option selected disabled>Tarix</option>
                                    <option value=""pdf"">2022</option>
                                    <option value=""txt"">2021</option>
                                    <option value=""epub"">2020</option>
                                    <option value=""fb2"">2019</option>
                                    <option value=""mobi"">2018</option>
                                </select>
                ");
            WriteLiteral(@"            </div>-->

                            <!-- Multiple Select -->

                        <!--</div>
                        <div class=""col-md-4 col-sm-6 text-center box"">
                            <div class=""select"">
                                <select name=""format"" id=""format"">
                                    <option selected disabled>İxtisas</option>
                                    <option value=""pdf"">PDF</option>
                                    <option value=""txt"">txt</option>
                                    <option value=""epub"">ePub</option>
                                    <option value=""fb2"">fb2</option>
                                    <option value=""mobi"">mobi</option>
                                </select>
                            </div>
                        </div>
                        <div class=""col-md-4 col-sm-6 m-auto text-center box"">
                            <div class=""select"">
                                <select n");
            WriteLiteral(@"ame=""format"" id=""format"">
                                    <option selected disabled>Kateqoriya</option>
                                    <option value=""pdf"">PDF</option>
                                    <option value=""txt"">txt</option>
                                    <option value=""epub"">ePub</option>
                                    <option value=""fb2"">fb2</option>
                                    <option value=""mobi"">mobi</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class=""col-md-12 mt-3"">
                        <table class=""table border"">
                            <thead>
                                <tr>
                                    <th scope=""col"">#</th>
                                    <th scope=""col"">Ad</th>
                                    <th scope=""col"">Soyad</th>
                                    <th scope=""col"">Dip");
            WriteLiteral(@"lom İşi</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope=""row"">1</th>
                                    <td>Mark</td>
                                    <td>Otto</td>
                                    <td>mdo</td>
                                </tr>
                                <tr>
                                    <th scope=""row"">2</th>
                                    <td>Jacob</td>
                                    <td>Thornton</td>
                                    <td>fat</td>
                                </tr>
                                <tr>
                                    <th scope=""row"">3</th>
                                    <td>Larry</td>
                                    <td>the Bird</td>
                                    <td>twitter</td>
                                </tr>
               ");
            WriteLiteral("             </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>-->\r\n\r\n\r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("css", async() => {
                WriteLiteral(" \r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2af96737e7d3732e5f5439a0a1b4d6d01d44876618636", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Author> Html { get; private set; }
    }
}
#pragma warning restore 1591
