#pragma checksum "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee46f121ba48d38e7df13605f165ff22d43b541a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Members_Details), @"mvc.1.0.view", @"/Views/Members/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee46f121ba48d38e7df13605f165ff22d43b541a", @"/Views/Members/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d40aafa2a956cb9f4837a45d08862015ed55438c", @"/Views/_ViewImports.cshtml")]
    public class Views_Members_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PinewoodGrow.Models.Member>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
  
	ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n\t<h4>Member</h4>\r\n\t<hr />\r\n\t<dl class=\"row\">\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 14 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 17 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 20 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 23 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 26 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 29 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 32 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telephone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 35 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Telephone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 38 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 41 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 44 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FamilySize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 47 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.FamilySize));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 50 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Income));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 53 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Income));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 56 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Notes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 59 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Notes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 62 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MemberDietaries));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 65 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
              
				int condCount = Model.MemberDietaries.Count;
				if (condCount > 0)
				{
					string firstCond = Model.MemberDietaries.FirstOrDefault().Dietary.Name;
					if (condCount > 1)
					{
						string condList = firstCond;
						var c = Model.MemberDietaries.ToList();
						for (int i = 1; i < condCount; i++)
						{
							condList += ", " + c[i].Dietary.Name;
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<a tabindex=\"0\"");
            BeginWriteAttribute("class", " class=\"", 1981, "\"", 1989, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" data-toggle=\"popover\"\r\n\t\t\t\t\t\t   data-trigger=\"focus\" title=\"Dietart Conditions\" data-placement=\"bottom\"\r\n\t\t\t\t\t\t   data-content=\"");
#nullable restore
#line 80 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                                    Write(condList);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 81 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                       Write(firstCond);

#line default
#line hidden
#nullable disable
            WriteLiteral("... <span class=\"badge badge-info\">");
#nullable restore
#line 81 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                                                                    Write(condCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t</a>\r\n");
#nullable restore
#line 83 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
					}
					else
					{
						

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                   Write(firstCond);

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                                  
					}
				}
			

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 92 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MemberSituations));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 95 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
              
				int sitCount = Model.MemberSituations.Count;
				if (sitCount > 0)
				{
					string firstSit = Model.MemberSituations.FirstOrDefault().Situation.Name;
					if (sitCount > 1)
					{
						string sitList = firstSit;
						var s = Model.MemberSituations.ToList();
						for (int i = 1; i < sitCount; i++)
						{
							sitList += ", " + s[i].Situation.Name;
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<a tabindex=\"0\"");
            BeginWriteAttribute("class", " class=\"", 2831, "\"", 2839, 0);
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" data-toggle=\"popover\"\r\n\t\t\t\t\t\t   data-trigger=\"focus\" title=\"Situations\" data-placement=\"bottom\"\r\n\t\t\t\t\t\t   data-content=\"");
#nullable restore
#line 110 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                                    Write(sitList);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n\t\t\t\t\t\t\t");
#nullable restore
#line 111 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                       Write(firstSit);

#line default
#line hidden
#nullable disable
            WriteLiteral("... <span class=\"badge badge-info\">");
#nullable restore
#line 111 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                                                                   Write(sitCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t\t</a>\r\n");
#nullable restore
#line 113 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
					}
					else
					{
						

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                   Write(firstSit);

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                                 
					}
				}
			

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 122 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Consent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 125 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Consent));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 128 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CompletedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 131 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.CompletedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 134 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CompletedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 137 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.CompletedOn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 140 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Household));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 143 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Household.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 146 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 149 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Gender.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t\t<dt class=\"col-sm-2\">\r\n\t\t\t");
#nullable restore
#line 152 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dt>\r\n\t\t<dd class=\"col-sm-10\">\r\n\t\t\t");
#nullable restore
#line 155 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
       Write(Html.DisplayFor(model => model.Address.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t</dd>\r\n\t</dl>\r\n</div>\r\n<div>\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee46f121ba48d38e7df13605f165ff22d43b541a17886", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 160 "C:\Users\Aidan\Documents\GitHub\PinewoodGrow\Views\Members\Details.cshtml"
                           WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee46f121ba48d38e7df13605f165ff22d43b541a20022", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\t<script type=\"text/javascript\">\r\n        $(function () {\r\n            $(\'[data-toggle=\"popover\"]\').popover();\r\n        });\r\n\t</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PinewoodGrow.Models.Member> Html { get; private set; }
    }
}
#pragma warning restore 1591
