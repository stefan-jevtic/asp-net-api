#pragma checksum "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5371e1479a4b5798a40adbdb66cc8d1222eccd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Category/Index.cshtml", typeof(AspNetCore.Views_Category_Index))]
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
#line 1 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5371e1479a4b5798a40adbdb66cc8d1222eccd4", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Application.DTO.CategoryDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(48, 30, true);
            WriteLiteral("       \n       <p>\n           ");
            EndContext();
            BeginContext(78, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5371e1479a4b5798a40adbdb66cc8d1222eccd43487", async() => {
                BeginContext(101, 10, true);
                WriteLiteral("Create New");
                EndContext();
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
            EndContext();
            BeginContext(115, 128, true);
            WriteLiteral("\n       </p>\n       <table class=\"table\">\n           <thead>\n               <tr>\n                   <th>\n                       ");
            EndContext();
            BeginContext(244, 38, false);
#line 10 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(282, 73, true);
            WriteLiteral("\n                   </th>\n                   <th>\n                       ");
            EndContext();
            BeginContext(356, 40, false);
#line 13 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(396, 73, true);
            WriteLiteral("\n                   </th>\n                   <th>\n                       ");
            EndContext();
            BeginContext(470, 45, false);
#line 16 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.DisplayNameFor(model => model.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(515, 115, true);
            WriteLiteral("\n                   </th>\n                   <th></th>\n               </tr>\n           </thead>\n           <tbody>\n");
            EndContext();
#line 22 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
        foreach (var item in Model) {

#line default
#line hidden
            BeginContext(668, 67, true);
            WriteLiteral("               <tr>\n                   <td>\n                       ");
            EndContext();
            BeginContext(736, 37, false);
#line 25 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(773, 73, true);
            WriteLiteral("\n                   </td>\n                   <td>\n                       ");
            EndContext();
            BeginContext(847, 39, false);
#line 28 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(886, 73, true);
            WriteLiteral("\n                   </td>\n                   <td>\n                       ");
            EndContext();
            BeginContext(960, 44, false);
#line 31 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.DisplayFor(modelItem => item.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(1004, 73, true);
            WriteLiteral("\n                   </td>\n                   <td>\n                       ");
            EndContext();
            BeginContext(1078, 53, false);
#line 34 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.ActionLink("Edit", "Edit", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1131, 26, true);
            WriteLiteral(" |\n                       ");
            EndContext();
            BeginContext(1158, 59, false);
#line 35 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.ActionLink("Details", "Details", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1217, 26, true);
            WriteLiteral(" |\n                       ");
            EndContext();
            BeginContext(1244, 57, false);
#line 36 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
                  Write(Html.ActionLink("Delete", "Delete", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1301, 47, true);
            WriteLiteral("\n                   </td>\n               </tr>\n");
            EndContext();
#line 39 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Category/Index.cshtml"
       }

#line default
#line hidden
            BeginContext(1357, 38, true);
            WriteLiteral("           </tbody>\n       </table>\n\n\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Application.DTO.CategoryDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
