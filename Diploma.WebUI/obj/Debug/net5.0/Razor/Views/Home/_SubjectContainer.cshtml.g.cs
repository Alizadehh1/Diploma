#pragma checksum "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0acf70e018c031477f14ae4bd5c1f1a1c1471a99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__SubjectContainer), @"mvc.1.0.view", @"/Views/Home/_SubjectContainer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0acf70e018c031477f14ae4bd5c1f1a1c1471a99", @"/Views/Home/_SubjectContainer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf07fe1e9be5bac76b1974758083a30d21862891", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__SubjectContainer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Subject>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml"
 foreach (var subject in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td id=\"subjectİd\" data-label=\"No:\">");
#nullable restore
#line 6 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml"
                                       Write(subject.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td id=\"subjectName\" data-label=\"Diplom işi\">");
#nullable restore
#line 7 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml"
                                                Write(subject.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td id=\"subjectAuthor\" data-label=\"Rəhbər\">");
#nullable restore
#line 8 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml"
                                               Write(subject.Author.Name + " " + subject.Author.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td class=\"bs-checkbox\" data-label=\"Seç\">\r\n            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 381, "\"", 439, 6);
            WriteAttributeValue("", 391, "selectEntity(event,", 391, 19, true);
#nullable restore
#line 10 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml"
WriteAttributeValue("", 410, subject.Id, 410, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 421, ",", 421, 1, true);
            WriteAttributeValue(" ", 422, "\'", 423, 2, true);
#nullable restore
#line 10 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml"
WriteAttributeValue("", 424, subject.Name, 424, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 437, "\')", 437, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <i class=\"fa-solid fa-check\" style=\"color: #00ff33;\"></i>\r\n            </a>\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 15 "C:\Users\gusta\OneDrive\Desktop\Diploma\Diploma.WebUI\Views\Home\_SubjectContainer.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Subject>> Html { get; private set; }
    }
}
#pragma warning restore 1591
