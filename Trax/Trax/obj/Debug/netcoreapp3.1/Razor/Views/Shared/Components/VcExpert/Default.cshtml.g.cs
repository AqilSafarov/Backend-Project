#pragma checksum "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "faa50b43a85a000974dd2cd53633bb6837b732a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_VcExpert_Default), @"mvc.1.0.view", @"/Views/Shared/Components/VcExpert/Default.cshtml")]
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
#line 1 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\_ViewImports.cshtml"
using Trax;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\_ViewImports.cshtml"
using Trax.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\_ViewImports.cshtml"
using Trax.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"faa50b43a85a000974dd2cd53633bb6837b732a0", @"/Views/Shared/Components/VcExpert/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caefc16673a8628db660a9e0232ec517c19821c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_VcExpert_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VmTeamMem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section id=""our-team"" class=""padding_top half-section-alt teams-border"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6 col-md-6 col-sm-12"">
                <div class=""heading-title heading_space wow fadeInUp"" data-wow-delay=""300ms"">
                    <span class=""defaultcolor text-center text-md-left"">");
#nullable restore
#line 10 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                                                                   Write(Model.Expert.Subtitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                    <h2 class=\"darkcolor font-normal text-center text-md-left\">");
#nullable restore
#line 11 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                                                                          Write(Model.Expert.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                </div>
            </div>
            <div class=""col-lg-6 col-md-6 col-sm-12"">
                <p class=""heading_space mt-n3 mt-sm-0 text-center text-md-left"">Curabitur mollis bibendum luctus. Duis suscipit vitae dui sed suscipit. Vestibulum auctor nunc vitae diam eleifend, in maximus metus sollicitudin. Quisque vitae sodales lectus. </p>
            </div>
        </div>
        <div class=""row"">

             <div class=""col-md-12"">
                 <div id=""ourteam-slider"" class=""owl-carousel"">
");
#nullable restore
#line 22 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                      foreach (var item in Model.TeamMember)
                     {

#line default
#line hidden
#nullable disable
            WriteLiteral("                         <div class=\"item\">\n                             <div class=\"team-box\">\n                                 <div class=\"image\">\n                                     <img");
            BeginWriteAttribute("src", " src=\"", 1318, "\"", 1343, 2);
            WriteAttributeValue("", 1324, "/images/", 1324, 8, true);
#nullable restore
#line 27 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
WriteAttributeValue("", 1332, item.Image, 1332, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1344, "\"", 1350, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                                 </div>\n                                 <div class=\"team-content\">\n                                     <h4 class=\"darkcolor\">");
#nullable restore
#line 30 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                                                      Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                                                                 Write(item.Surame);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                                     <p>");
#nullable restore
#line 31 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                                   Write(item.Position.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                                     <ul class=\"social-icons-simple\">\n\n");
#nullable restore
#line 34 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                                          foreach (var item2 in item.SocialToTeamMembers)
                                         {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                             <li><a");
            BeginWriteAttribute("class", " class=\"", 1860, "\"", 1886, 1);
#nullable restore
#line 36 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
WriteAttributeValue("", 1868, item2.Social.Name, 1868, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1887, "\"", 1905, 1);
#nullable restore
#line 36 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
WriteAttributeValue("", 1894, item2.Link, 1894, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i");
            BeginWriteAttribute("class", " class=\"", 1909, "\"", 1935, 1);
#nullable restore
#line 36 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
WriteAttributeValue("", 1917, item2.Social.Icon, 1917, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i> </a> </li>\n");
#nullable restore
#line 37 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"
                                          }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                     </ul>\n                                 </div>\n                             </div>\n                         </div>\n");
#nullable restore
#line 42 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcExpert\Default.cshtml"

                     }

#line default
#line hidden
#nullable disable
            WriteLiteral("                 </div>\r\n                </div>\n\n\n\n\n");
            WriteLiteral(@"        </div>
    </div>
</section><section id=""bg-counters"" class=""padding bg-counters parallax"">
    <div class=""container"">
        <div class=""row align-items-center text-center"">
            <div class=""col-lg-4 col-md-4 col-sm-4 bottom10"">
                <div class=""counters whitecolor  top10 bottom10"">
                    <span class=""count_nums font-light"" data-to=""2010"" data-speed=""2500""> </span>
                </div>
                <h3 class=""font-light whitecolor top20"">Since We Started</h3>
            </div>
            <div class=""col-lg-4 col-md-4 col-sm-4"">
                <p class=""whitecolor top20 bottom20 font-light title"">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc mauris arcu, lobortis id interdum vitae, interdum eget elit. </p>
            </div>
            <div class=""col-lg-4 col-md-4 col-sm-4 bottom10"">
                <div class=""counters whitecolor top10 bottom10"">
                    <span class=""count_nums font-light"" data-to=""895"" data-speed=""2500""> </span>");
            WriteLiteral("\n                </div>\n                <h3 class=\"font-light whitecolor top20\">Since We Started</h3>\n            </div>\n        </div>\n    </div>\n</section>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VmTeamMem> Html { get; private set; }
    }
}
#pragma warning restore 1591
