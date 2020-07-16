#pragma checksum "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4073af4150ab748036797f135a69a2bd8a99efc2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_RegisterForCourse), @"mvc.1.0.view", @"/Views/Student/RegisterForCourse.cshtml")]
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
#line 1 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\_ViewImports.cshtml"
using GroupBCapstoneProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\_ViewImports.cshtml"
using GroupBCapstoneProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
using GroupBCapstoneProject.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4073af4150ab748036797f135a69a2bd8a99efc2", @"/Views/Student/RegisterForCourse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50fe17463a6e178e695157ba9184f8ef4f726319", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_RegisterForCourse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Student/RegisterForCourse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
  
    ViewData["Title"] = "RegisterForCourse";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"<h3>Register For A Course</h3>

<h2>Courses</h2>

<table>
    <thead>
        <tr>
            <th>Course Number</th>
            <th>Section Number</th>
            <th>Available Seats</th>
            <th>Faculty</th>
            <th>Start Time</th>
            <th>End Time</th>
            <th>Credit Hours</th>
            <th>Building Name</th>
            <th>Building Number</th>
            <th>Meets on Monday</th>
            <th>Meets on Tuesday</th>
            <th>Meets on Wednesday</th>
            <th>Meets on Thursday</th>
            <th>Meets on Friday</th>
            <th>Meets on Saturday</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 33 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
         foreach (CourseForRegistration course in ViewBag.listOfCoursesForRegistration)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n            <td>");
#nullable restore
#line 35 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.CourseNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 36 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.SectionNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 37 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.AvailableSeats);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.Faculty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 39 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                 if (course.StartTime.HasValue) 
                {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.StartTime.Value.ToString("T"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                                                     ;
                }
                else { 

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                  Write(course.StartTime.ToString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                                                   ; }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n");
#nullable restore
#line 45 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                 if (course.EndTime.HasValue)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
               Write(course.EndTime.Value.ToString("T"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                                                       ;
                }
                else { 

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                  Write(course.EndTime.ToString());

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                                                 ; }

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 50 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.CreditHours);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 51 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.BuildingName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 52 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.BuildingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 53 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.MeetsOnMonday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 54 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.MeetsOnTuesday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 55 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.MeetsOnWednesday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 56 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.MeetsOnThursday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 57 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.MeetsOnFriday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 58 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
           Write(course.MeetsOnSaturday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>    \r\n");
#nullable restore
#line 60 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n<p style=\"font-weight: bold\">Want to register for a class?  Enter the Section Number of the class you would like and hit Register.</p>\r\n<div style=\"color: #ff0000;\">");
#nullable restore
#line 65 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                        Write(ViewData["ErrorMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4073af4150ab748036797f135a69a2bd8a99efc213170", async() => {
                WriteLiteral("\r\n\r\n    <select id=\"SelectSectionNumberList\" name=\"courseID\">\r\n");
#nullable restore
#line 70 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
         foreach (CourseForRegistration course in ViewBag.listOfCoursesForRegistration)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4073af4150ab748036797f135a69a2bd8a99efc213842", async() => {
#nullable restore
#line 72 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
                                  Write(course.SectionNumber);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 72 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
               WriteLiteral(course.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 73 "D:\C# Programming\Capstone Stuff\GroupBCapstoneProject\GroupBCapstoneProject\Views\Student\RegisterForCourse.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </select>\r\n\r\n    <button type=\"submit\" class=\"btn btn-dark\">Register</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
