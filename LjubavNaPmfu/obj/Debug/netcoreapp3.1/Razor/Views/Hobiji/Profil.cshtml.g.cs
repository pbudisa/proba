#pragma checksum "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32086c4b5bd5329e56bf8df0308a0e81c80dfdc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hobiji_Profil), @"mvc.1.0.view", @"/Views/Hobiji/Profil.cshtml")]
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
#line 1 "C:\Baza\upi\proba\LjubavNaPmfu\Views\_ViewImports.cshtml"
using LjubavNaPmfu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Baza\upi\proba\LjubavNaPmfu\Views\_ViewImports.cshtml"
using LjubavNaPmfu.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32086c4b5bd5329e56bf8df0308a0e81c80dfdc9", @"/Views/Hobiji/Profil.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"382f11ab03267aa79dabc7107bcf1640b27fd0ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Hobiji_Profil : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LjubavNaPmfu.Baza.KorisnikHobiji>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Lista", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
  
    ViewData["Title"] = "Profil";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32086c4b5bd5329e56bf8df0308a0e81c80dfdc93663", async() => {
                WriteLiteral("Natrag na popis");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h1>Moj Profil</h1>\r\n<hr />\r\n<h1>Ime: ");
#nullable restore
#line 10 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
    Write(ViewBag.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h2>Dob: ");
#nullable restore
#line 11 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
    Write(ViewBag.Dob);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>O meni: ");
#nullable restore
#line 12 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
       Write(ViewBag.Omeni);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>Studij: ");
#nullable restore
#line 13 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
       Write(ViewBag.Studij);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>Moje kategorije:</h3>\r\n<ul>\r\n");
#nullable restore
#line 16 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 18 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
       Write(Html.DisplayFor(modelItem => item.IdhNavigation.Naziv));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 19 "C:\Baza\upi\proba\LjubavNaPmfu\Views\Hobiji\Profil.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LjubavNaPmfu.Baza.KorisnikHobiji>> Html { get; private set; }
    }
}
#pragma warning restore 1591
