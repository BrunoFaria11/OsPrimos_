#pragma checksum "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\Admin\WebSite.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "730b66c1854b9ceba0da06f1eec184c9691ff8c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_WebSite), @"mvc.1.0.view", @"/Views/Admin/WebSite.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/WebSite.cshtml", typeof(AspNetCore.Views_Admin_WebSite))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"730b66c1854b9ceba0da06f1eec184c9691ff8c6", @"/Views/Admin/WebSite.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71cfa9c3ae2f1e0493d4ca25e3a3394ef37b5862", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_WebSite : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 2 "C:\Users\bruno\OneDrive\Ambiente de Trabalho\Ecommerce_Primos\Ecommerce_MVC_Core\Views\Admin\WebSite.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
            BeginContext(35, 618, true);
            WriteLiteral(@"
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""card card-secondary w-100"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Banner</h3>

                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                    </div>
                </div>
                <div class=""card-body"">
                    ");
            EndContext();
            BeginContext(653, 1935, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03e86c49ab37402c800fe4c5fd9df908", async() => {
                BeginContext(671, 1910, true);
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-sm-12"">
                                <div class=""card-body text-center "" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>


                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px;margin-top:20px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                               ");
                WriteLiteral(@"         <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>

                                <div class=""card-body text-center "" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px;margin-top:20px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                        </div>

                        <div class=""form-group"">
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2588, 663, true);
            WriteLiteral(@"
                </div>
                <!-- /.card-body -->
            </div>

        </div>
        <div class=""row"">
            <div class=""card card-secondary w-100"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Tipo de Produtos</h3>

                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                    </div>
                </div>
                <div class=""card-body"">
                    ");
            EndContext();
            BeginContext(3251, 2699, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b2cd3d64dc44e7391487dacf58e87d2", async() => {
                BeginContext(3269, 2674, true);
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-3"">
                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                            <div class=""col-3"">
                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;heig");
                WriteLiteral(@"ht:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                            <div class=""col-3"">
                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                            <div class=""col-3"">
                                <div class=""card-body text-center"" style=""height: 300px;backgroun");
                WriteLiteral(@"d-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                 

                        </div>

                        <div class=""form-group"">
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5950, 669, true);
            WriteLiteral(@"
                </div>
                <!-- /.card-body -->
            </div>

        </div>
        <div class=""row"">
            <div class=""card card-secondary w-100"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Banner + Video YouTube</h3>

                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                    </div>
                </div>
                <div class=""card-body"">
                    ");
            EndContext();
            BeginContext(6619, 824, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebee6036e4bd40e6a04ba94721cfbf21", async() => {
                BeginContext(6637, 799, true);
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-sm-12"">
                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                        </div>

                        <div class=""form-group"">
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7443, 655, true);
            WriteLiteral(@"
                </div>
                <!-- /.card-body -->
            </div>
        </div>
        <div class=""row"">
            <div class=""card card-secondary w-100"">
                <div class=""card-header"">
                    <h3 class=""card-title"">3 Imagens</h3>

                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                    </div>
                </div>
                <div class=""card-body"">
                    ");
            EndContext();
            BeginContext(8098, 2060, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "15e80610e4f74e23946a2e4943df154c", async() => {
                BeginContext(8116, 2035, true);
                WriteLiteral(@"
                        <div class=""row"">

                            <div class=""col-4"">
                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                            <div class=""col-4"">
                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;hei");
                WriteLiteral(@"ght:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                            <div class=""col-4"">
                                <div class=""card-body text-center"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <a class=""btn btn-default  btn-lg"" href=""#"" style=""border-radius: 50%;background-color: transparent;color: white;width:91px;height:91px;padding-top: 30px;"">
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class=""form-group"">
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(10158, 664, true);
            WriteLiteral(@"
                </div>
                <!-- /.card-body -->
            </div>
        </div>
        <div class=""row"">
            <div class=""card card-secondary w-100"">
                <div class=""card-header"">
                    <h3 class=""card-title"">Fotos do Instagram</h3>

                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">
                            <i class=""fas fa-minus""></i>
                        </button>
                    </div>
                </div>
                <div class=""card-body"">
                    ");
            EndContext();
            BeginContext(10822, 2168, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70baebcabe47472384b18455fcf172fb", async() => {
                BeginContext(10840, 2143, true);
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-1"">

                            </div>
                            <div class=""col-2"">
                                <div class=""card-body box-profile"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <div class=""text-center"">

                                    </div>
                                </div>
                            </div>
                            <div class=""col-2"">
                                <div class=""card-body box-profile"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <div class=""text-center"">

                                    </div>
                                </div>
                            </div>
                            <div class=""col-2"">
                                <div class=""card-body box-profile"" style=""height: 300px;backgro");
                WriteLiteral(@"und-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <div class=""text-center"">

                                    </div>
                                </div>
                            </div>
                            <div class=""col-2"">
                                <div class=""card-body box-profile"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <div class=""text-center"">

                                    </div>
                                </div>
                            </div>
                            <div class=""col-2"">
                                <div class=""card-body box-profile"" style=""height: 300px;background-color: rgba(95, 95, 95, 0.59);border-radius:8px"">
                                    <div class=""text-center"">

                                    </div>
                                </div>
                            </div>
                        </div>
     ");
                WriteLiteral("                   <div class=\"form-group\">\n                        </div>\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12990, 117, true);
            WriteLiteral("\n                </div>\n                <!-- /.card-body -->\n            </div>\n        </div>\n    </div>\n\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
