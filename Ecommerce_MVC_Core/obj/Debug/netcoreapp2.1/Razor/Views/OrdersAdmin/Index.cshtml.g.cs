#pragma checksum "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fe144e128b2aafcbf291d73ba77431df253ec3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrdersAdmin_Index), @"mvc.1.0.view", @"/Views/OrdersAdmin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/OrdersAdmin/Index.cshtml", typeof(AspNetCore.Views_OrdersAdmin_Index))]
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
#line 1 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core;

#line default
#line hidden
#line 2 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core.Models;

#line default
#line hidden
#line 4 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using System.Collections;

#line default
#line hidden
#line 5 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core.BootstrapModal;

#line default
#line hidden
#line 6 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\_ViewImports.cshtml"
using Ecommerce_MVC_Core.Code;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fe144e128b2aafcbf291d73ba77431df253ec3f", @"/Views/OrdersAdmin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71cfa9c3ae2f1e0493d4ca25e3a3394ef37b5862", @"/Views/_ViewImports.cshtml")]
    public class Views_OrdersAdmin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Ecommerce_MVC_Core.ViewModel.OrdersViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("deleteUserModal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#modal-popUP"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
  
    ViewData["Title"] = "Orders";

#line default
#line hidden
            BeginContext(104, 28, true);
            WriteLiteral("\n<div class=\"col-md-3\">\n    ");
            EndContext();
            BeginContext(132, 379, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff58870ca17144d2b37062aaba0ef046", async() => {
                BeginContext(191, 124, true);
                WriteLiteral("\n        <div class=\"form-horizontal\">\n            <div class=\"form-group\">\n                <input type=\"text\" name=\"search\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 315, "\"", 349, 1);
#line 10 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
WriteAttributeValue("", 323, Html.ViewBag.SearchString, 323, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(350, 154, true);
                WriteLiteral(" class=\"form-control\" />\n                <input type=\"submit\" value=\"Search\" class=\"btn btn-default pull-right\" />\n\n            </div>\n        </div>\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(511, 15, true);
            WriteLiteral("\n</div>\n<hr />\n");
            EndContext();
#line 18 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
  
    if (Model.ToList().Count <= 0)
    {

#line default
#line hidden
            BeginContext(570, 35, true);
            WriteLiteral("        <h1>No one orders Yet</h1>\n");
            EndContext();
#line 22 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(626, 456, true);
            WriteLiteral(@"        <table class=""table table-responsive table-hover"">
            <thead>
                <tr>
                    <th>#</th>
                    <th>Number</th>

                    <th>Users</th>
                    <th>Location</th>
                    <th>Payment Method</th>
                    <th>Charge</th>
                    <th>Total</th>
                    <th>Action</th>
                </tr>
            </thead>

            <tbody>
");
            EndContext();
#line 41 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                  
                    int count = 1;
                    foreach (var item in Model)
                    {

#line default
#line hidden
            BeginContext(1206, 61, true);
            WriteLiteral("                        <tr>\n                            <td>");
            EndContext();
            BeginContext(1268, 5, false);
#line 46 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                           Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(1273, 71, true);
            WriteLiteral("</td>\n                            <td>\n                                ");
            EndContext();
            BeginContext(1345, 11, false);
#line 48 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                           Write(item.Number);

#line default
#line hidden
            EndContext();
            BeginContext(1356, 100, true);
            WriteLiteral("\n                            </td>\n                            <td>\n                                ");
            EndContext();
            BeginContext(1457, 13, false);
#line 51 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                           Write(item.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1470, 100, true);
            WriteLiteral("\n                            </td>\n                            <td>\n                                ");
            EndContext();
            BeginContext(1571, 17, false);
#line 54 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                           Write(item.LocationName);

#line default
#line hidden
            EndContext();
            BeginContext(1588, 67, true);
            WriteLiteral("\n                            </td>\n                            <td>");
            EndContext();
            BeginContext(1656, 18, false);
#line 56 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                           Write(item.PaymentMethod);

#line default
#line hidden
            EndContext();
            BeginContext(1674, 38, true);
            WriteLiteral("</td>\n                            <td>");
            EndContext();
            BeginContext(1713, 19, false);
#line 57 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                           Write(item.DeliveryCharge);

#line default
#line hidden
            EndContext();
            BeginContext(1732, 71, true);
            WriteLiteral("</td>\n                            <td>\n                                ");
            EndContext();
            BeginContext(1804, 10, false);
#line 59 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                           Write(item.Total);

#line default
#line hidden
            EndContext();
            BeginContext(1814, 100, true);
            WriteLiteral("\n                            </td>\n                            <td>\n                                ");
            EndContext();
            BeginContext(1914, 268, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbf2de4005634faca9efd9bee6527ab3", async() => {
                BeginContext(2059, 119, true);
                WriteLiteral("\n                                    <i class=\"glyphicon glyphicon-trash\"></i>  Delete\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 62 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2182, 65, true);
            WriteLiteral("\n                            </td>\n                        </tr>\n");
            EndContext();
#line 67 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
                        count++;
                    }
                

#line default
#line hidden
            BeginContext(2320, 38, true);
            WriteLiteral("            </tbody>\n        </table>\n");
            EndContext();
#line 72 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\OrdersAdmin\Index.cshtml"
    }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Ecommerce_MVC_Core.ViewModel.OrdersViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
