#pragma checksum "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b5a34008ddf47b6f3a724e9eb6d332419695f2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activitiys_Details), @"mvc.1.0.view", @"/Views/Activitiys/Details.cshtml")]
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
#line 1 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\_ViewImports.cshtml"
using CharityV2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\_ViewImports.cshtml"
using CharityV2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b5a34008ddf47b6f3a724e9eb6d332419695f2b", @"/Views/Activitiys/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38cf5147c2dd7c69b860982b5fc0734cc1f3ba7c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Activitiys_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CharityV2.Models.ActivityDetailsVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Допълнителна информация</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dd>\r\n            <div class=\"img-fluid\">\r\n");
#nullable restore
#line 14 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
                 foreach (var item in Model.ImagePath)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>\r\n                        <img class=\"rounded float-sm-right justify-content-md-center\" width=\"200\"");
            BeginWriteAttribute("src", " src=\"", 417, "\"", 428, 1);
#nullable restore
#line 17 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
WriteAttributeValue("", 423, item, 423, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 429, "\"", 456, 3);
            WriteAttributeValue("", 435, "Image", 435, 5, true);
            WriteAttributeValue(" ", 440, "for", 441, 4, true);
#nullable restore
#line 17 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
WriteAttributeValue(" ", 444, Model.Name, 445, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </div>\r\n");
#nullable restore
#line 19 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n          Име\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 26 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n           Описание\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 32 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Местоположение\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.Place));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Начало\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 44 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n           Край\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 50 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n           Време на регистриране на събитието\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 56 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.RegistrationTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Брой интересуващи се\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 62 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.CountInterest));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Брой участници\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 68 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.CountParticipants));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Статус\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 74 "D:\VS\НЕНКОCharityV2-master\CharityV2-master\CharityV2\Views\Activitiys\Details.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        \r\n    </dl>\r\n</div>\r\n<div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b5a34008ddf47b6f3a724e9eb6d332419695f2b9090", async() => {
                WriteLiteral("Back");
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
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CharityV2.Models.ActivityDetailsVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
