#pragma checksum "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bbffcb94c387326a3ec27d04adc8cf336d34cfa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_VcCounters_Default), @"mvc.1.0.view", @"/Views/Shared/Components/VcCounters/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bbffcb94c387326a3ec27d04adc8cf336d34cfa", @"/Views/Shared/Components/VcCounters/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caefc16673a8628db660a9e0232ec517c19821c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_VcCounters_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Counters>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section id=""bg-counters"" class=""padding bg-counters parallax"">
    <div class=""container"">
        <div class=""row align-items-center text-center"">
            <div class=""col-lg-4 col-md-4 col-sm-4 bottom10"">
                <div class=""counters whitecolor  top10 bottom10"">
                    <span class=""count_nums font-light"" data-to=""");
#nullable restore
#line 10 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
                                                            Write(Model.StartYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 10 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
                                                                              Write(Model.StartYear);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                </div>\n                <h3 class=\"font-light whitecolor top20\">");
#nullable restore
#line 12 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
                                                   Write(Model.Subtitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n            </div>\n            <div class=\"col-lg-4 col-md-4 col-sm-4\">\n");
            WriteLiteral("                <p class=\"whitecolor top20 bottom20 font-light title\">");
#nullable restore
#line 16 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
                                                                 Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n\n            </div>\n            <div class=\"col-lg-4 col-md-4 col-sm-4 bottom10\">\n                <div class=\"counters whitecolor top10 bottom10\">\n                    <span class=\"count_nums font-light\" data-to=\"");
#nullable restore
#line 21 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
                                                            Write(Model.StudentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 21 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
                                                                                 Write(Model.StudentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\n                </div>\n                <h3 class=\"font-light whitecolor top20\">");
#nullable restore
#line 23 "C:\Users\User\OneDrive\Masaüstü\BackendPro\Trax\Trax\Views\Shared\Components\VcCounters\Default.cshtml"
                                                   Write(Model.Subtitle2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n            </div>\n        </div>\n    </div>\n</section>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Counters> Html { get; private set; }
    }
}
#pragma warning restore 1591
