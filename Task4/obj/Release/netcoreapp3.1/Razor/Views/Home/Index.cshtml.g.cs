#pragma checksum "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce471c5ccf40b6e6cdccaeedb734cae6f1c522e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\_ViewImports.cshtml"
using Task4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\_ViewImports.cshtml"
using Task4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce471c5ccf40b6e6cdccaeedb734cae6f1c522e4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c25832c8e2cc42194312570864dbd9dabd8e962", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""text-center"">
    <h1 class=""display-4"">User management</h1>
</div>
<div class=""toolbar"">
    <input type=""button"" id=""block""
           value=""Block"" />
    <input type=""button"" id=""unblock"" class=""btn add btn-success""
           value=""Unblock"" />
    <input type=""button"" id=""delete"" class=""btn edit btn-danger""
           value=""Delete"" />
</div>
<br /><br />
<table id=""UsersTable"" border=""1"" cellpadding=""10"">
    <tr>
        <th><input type=""checkbox"" id=""checkAll"" /></th>
        <th>Id</th>
        <th>UserName</th>
        <th>Email</th>
        <th>Registration Date</th>
        <th>Last Login Date</th>
        <th>Status</th>
    </tr>
");
#nullable restore
#line 26 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <input type=\"checkbox\" class=\"checkBox\"");
            BeginWriteAttribute("value", "\r\n                       value=\"", 860, "\"", 900, 1);
#nullable restore
#line 31 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
WriteAttributeValue("", 892, user.Id, 892, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </td>\r\n            <td>");
#nullable restore
#line 33 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
           Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 34 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
           Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 35 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 36 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
           Write(user.RegisterDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 37 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
           Write(user.LastLoginDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
           Write(user.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 40 "C:\Users\furer\Desktop\Itransition\Task4\Task4\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"<script>
        $(document).ready(function () {

            $(""#checkAll"").click(function () {
                $("".checkBox"").prop('checked',
                    $(this).prop('checked'));
            });

            $(""#delete"").click(function () {
                var selectedIDs = new Array();
                $('input:checkbox.checkBox').each(function () {
                    if ($(this).prop('checked')) {
                        selectedIDs.push($(this).val());
                    }
                });

                var options = {};
                options.url = ""/home/delete"";
                options.type = ""POST"";
                options.data = { selectedIDs: selectedIDs };
                options.success = function (json) {
                    if (json.isRedirect) { window.location.href = json.redirectUrl; }
                };
                $.ajax(options);
            });
            $(""#block"").click(function () {
                var selectedIDs = new Array();
      ");
                WriteLiteral(@"          $('input:checkbox.checkBox').each(function () {
                    if ($(this).prop('checked')) {
                        selectedIDs.push($(this).val());
                    }
                });

                var options = {};
                options.url = ""/home/block"";
                options.type = ""POST"";
                options.data = { selectedIDs: selectedIDs };
                options.success = function (json) {
                    if (json.isRedirect) { window.location.href = json.redirectUrl; }
                };
                $.ajax(options);
            });
            $(""#unblock"").click(function () {
                var selectedIDs = new Array();
                $('input:checkbox.checkBox').each(function () {
                    if ($(this).prop('checked')) {
                        selectedIDs.push($(this).val());
                    }
                });

                var options = {};
                options.url = ""/home/unblock"";
                ");
                WriteLiteral(@"options.type = ""POST"";
                options.data = { selectedIDs: selectedIDs };
                options.success = function (json) {
                    if (json.isRedirect) { window.location.href = json.redirectUrl; }
                };
                $.ajax(options);
            });
        });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
