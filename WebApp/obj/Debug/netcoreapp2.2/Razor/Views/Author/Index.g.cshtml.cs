#pragma checksum "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a184cba6dd5ba2dd49d7f10c59ff085e3f191010"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Author_Index), @"mvc.1.0.view", @"/Views/Author/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Author/Index.cshtml", typeof(AspNetCore.Views_Author_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a184cba6dd5ba2dd49d7f10c59ff085e3f191010", @"/Views/Author/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Author_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Application.DTO.AuthorDTO>>
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
            BeginContext(47, 32, true);
            WriteLiteral("       \r\n       <p>\r\n           ");
            EndContext();
            BeginContext(79, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a184cba6dd5ba2dd49d7f10c59ff085e3f1910103475", async() => {
                BeginContext(102, 10, true);
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
            BeginContext(116, 134, true);
            WriteLiteral("\r\n       </p>\r\n       <table class=\"table\">\r\n           <thead>\r\n               <tr>\r\n                   <th>\r\n                       ");
            EndContext();
            BeginContext(251, 38, false);
#line 10 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
                  Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(289, 292, true);
            WriteLiteral(@"
                   </th>
                   <th>
                       Full Name
                   </th>
                   <th>
                       Created at
                   </th>
                   <th></th>
               </tr>
           </thead>
           <tbody>
");
            EndContext();
#line 22 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
        foreach (var item in Model) {

#line default
#line hidden
            BeginContext(620, 69, true);
            WriteLiteral("               <tr>\r\n                   <td>\r\n                       ");
            EndContext();
            BeginContext(690, 37, false);
#line 25 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
                  Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(727, 76, true);
            WriteLiteral("\r\n                   </td>\r\n                   <td>\r\n                       ");
            EndContext();
            BeginContext(804, 43, false);
#line 28 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
                  Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(847, 76, true);
            WriteLiteral("\r\n                   </td>\r\n                   <td>\r\n                       ");
            EndContext();
            BeginContext(924, 44, false);
#line 31 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
                  Write(Html.DisplayFor(modelItem => item.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(968, 76, true);
            WriteLiteral("\r\n                   </td>\r\n                   <td>\r\n                       ");
            EndContext();
            BeginContext(1045, 53, false);
#line 34 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
                  Write(Html.ActionLink("Edit", "Edit", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1098, 27, true);
            WriteLiteral(" |\r\n                       ");
            EndContext();
            BeginContext(1126, 59, false);
#line 35 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
                  Write(Html.ActionLink("Details", "Details", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1185, 27, true);
            WriteLiteral(" |\r\n                       ");
            EndContext();
            BeginContext(1213, 57, false);
#line 36 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
                  Write(Html.ActionLink("Delete", "Delete", new {  id=item.Id  }));

#line default
#line hidden
            EndContext();
            BeginContext(1270, 50, true);
            WriteLiteral("\r\n                   </td>\r\n               </tr>\r\n");
            EndContext();
#line 39 "/home/kica/harddisk/c/RiderProjects/ShoeShop/WebApp/Views/Author/Index.cshtml"
       }

#line default
#line hidden
            BeginContext(1330, 42, true);
            WriteLiteral("           </tbody>\r\n       </table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Application.DTO.AuthorDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
