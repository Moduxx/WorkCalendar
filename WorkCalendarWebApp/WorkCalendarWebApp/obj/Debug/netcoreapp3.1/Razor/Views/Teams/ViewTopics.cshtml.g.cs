#pragma checksum "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b248c95f71601da8215c095b080ff36bb6480c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teams_ViewTopics), @"mvc.1.0.view", @"/Views/Teams/ViewTopics.cshtml")]
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
#line 1 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\_ViewImports.cshtml"
using WorkCalendarWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\_ViewImports.cshtml"
using WorkCalendarWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b248c95f71601da8215c095b080ff36bb6480c7", @"/Views/Teams/ViewTopics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30d21123bb7981219ae8b5bc721a3201e580a04d", @"/Views/_ViewImports.cshtml")]
    public class Views_Teams_ViewTopics : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WorkCalendarWebApp.Data.Objective>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
  
    ViewData["Title"] = "ViewTopics";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Topics for this team</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>There are not any topics.</p>\r\n");
#nullable restore
#line 12 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 19 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
               Write(Html.DisplayNameFor(model => model.TeamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 22 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
               Write(Html.DisplayNameFor(model => model.WorkerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 25 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
               Write(Html.DisplayNameFor(model => model.TopicName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 28 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
               Write(Html.DisplayNameFor(model => model.SubtopicName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 31 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
               Write(Html.DisplayNameFor(model => model.IsLearnt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 36 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TeamName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 43 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
                   Write(Html.DisplayFor(modelItem => item.WorkerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TopicName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SubtopicName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 52 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IsLearnt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 55 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 58 "C:\Users\Admin\Documents\GitHub\WorkCalendar\WorkCalendarWebApp\WorkCalendarWebApp\Views\Teams\ViewTopics.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WorkCalendarWebApp.Data.Objective>> Html { get; private set; }
    }
}
#pragma warning restore 1591
