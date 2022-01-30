#pragma checksum "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\IncomeChart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "170f317488e18ddacf5316d25cf54f0055c2bdc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncomeChart_Index), @"mvc.1.0.view", @"/Views/IncomeChart/Index.cshtml")]
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
#line 1 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\_ViewImports.cshtml"
using PinewoodGrow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\_ViewImports.cshtml"
using PinewoodGrow.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"170f317488e18ddacf5316d25cf54f0055c2bdc3", @"/Views/IncomeChart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d40aafa2a956cb9f4837a45d08862015ed55438c", @"/Views/_ViewImports.cshtml")]
    public class Views_IncomeChart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PinewoodGrow.Models.DataPoint>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\IncomeChart\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1></h1>



<script>
window.onload = function () {

var chart = new CanvasJS.Chart(""chartContainer"", {
	animationEnabled: true,
	theme: ""light2"", // ""light1"", ""light2"", ""dark1"", ""dark2""
	title: {
		text: ""Member's report by Income"",
		fontSize: 30,
		padding: 30
	},
	axisY: {
        title: ""No. of Member"",
        titleFontSize: 20
	},
    dataPointWidth: 50,
	data: [{
		type: ""column"",
		dataPoints: ");
#nullable restore
#line 28 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\IncomeChart\Index.cshtml"
               Write(Html.Raw(ViewBag.DataPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
	}]
});
chart.render();

}
</script>
<div id=""chartContainer"" style=""height: 500px; width:70%; margin:auto;""></div>


<table class=""table table-striped"" style=""width:70%; margin:auto;"">
    <thead>
        <tr>
            <th>
                Range of Income
            </th>
            <th>
                No. of Member
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                Under $5000
            </td>
            <td>
                0
            </td>
        </tr>
        <tr>
            <td>
                $5000 to $9999
            </td>
            <td>
                0
            </td>
        </tr>
        <tr>
            <td>
                $10000 to $14999
            </td>
            <td>
                3
            </td>
        </tr>
        <tr>
            <td>
                $15000 to $19999
            </td>
            <td>
                2
            </td>
        </tr>
  ");
            WriteLiteral(@"      <tr>
            <td>
                $20000 to $24999
            </td>
            <td>
                0
            </td>
        </tr>
        <tr>
            <td>
                $25000 or more
            </td>
            <td>
                0
            </td>
        </tr>

");
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n<script src=\"https://canvasjs.com/assets/script/canvasjs.min.js\"></script>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PinewoodGrow.Models.DataPoint>> Html { get; private set; }
    }
}
#pragma warning restore 1591
