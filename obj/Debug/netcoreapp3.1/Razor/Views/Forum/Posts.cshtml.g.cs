#pragma checksum "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fba5d7fb909935ba4dbb39198125c9cfcdd33db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Forum_Posts), @"mvc.1.0.view", @"/Views/Forum/Posts.cshtml")]
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
#line 1 "C:\Users\Villar\Desktop\Forum\Forum\Views\_ViewImports.cshtml"
using Forum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Villar\Desktop\Forum\Forum\Views\_ViewImports.cshtml"
using Forum.DataModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fba5d7fb909935ba4dbb39198125c9cfcdd33db", @"/Views/Forum/Posts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd2c8799bcfd48bfa699a3d77740edfd29ccd2d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Forum_Posts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Forum.ViewModels.PostsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Posts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Comment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"container text-dark\">\r\n    <div class=\"col-12\">\r\n        <div class=\"row\">\r\n            <div class=\"card mb-2 p-3\">\r\n                <h2><b>Posts on ");
#nullable restore
#line 6 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                           Write(Model.Forum.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h2>\r\n                <h2><b>Forum Id: ");
#nullable restore
#line 7 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                            Write(Model.Forum.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h2>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 309, "\"", 336, 1);
#nullable restore
#line 8 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
WriteAttributeValue("", 315, Model.Forum.ImageUrl, 315, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail mb-2\" style=\"height:50px;width:50px;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fba5d7fb909935ba4dbb39198125c9cfcdd33db5431", async() => {
                WriteLiteral("Create new post");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                                                                               WriteLiteral(Model.ForumId);

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
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n\r\n");
#nullable restore
#line 15 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
             foreach (var post in Model.Posts)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card mb-3\">\r\n                    <div class=\"card-body\">\r\n                        <p><b>Date Created:</b>");
#nullable restore
#line 19 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                          Write(post.Post.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n                        <p><b>Post ID:</b>");
#nullable restore
#line 20 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                     Write(post.Post.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p><b>Title:</b>");
#nullable restore
#line 21 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                   Write(post.Post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p><b>Content:</b>");
#nullable restore
#line 22 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                     Write(post.Post.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p><b>Post Type:</b>");
#nullable restore
#line 23 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                       Write(post.Post.PostType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"card-footer\">\r\n");
#nullable restore
#line 26 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                         if (post.Post.PostReplies.Count() == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h1>No Comments Found!</h1>                           \r\n");
#nullable restore
#line 29 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"row\">\r\n                            <div class=\"col-1\">\r\n                                <a class=\"btn btn-primary mb-2\" data-toggle=\"collapse\"");
            BeginWriteAttribute("href", " href=\"", 1550, "\"", 1587, 2);
            WriteAttributeValue("", 1557, "#collapseExample_", 1557, 17, true);
#nullable restore
#line 32 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
WriteAttributeValue("", 1574, post.Post.Id, 1574, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" role=""button"" aria-expanded=""false"" aria-controls=""collapseExample"">
                                    View Comments
                                </a>
                            </div>
                            <div class=""col-1"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fba5d7fb909935ba4dbb39198125c9cfcdd33db11308", async() => {
                WriteLiteral("Comment");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                                                                                                 WriteLiteral(post.Post.Id);

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
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"collapse\"");
            BeginWriteAttribute("id", " id=\"", 2099, "\"", 2133, 2);
            WriteAttributeValue("", 2104, "collapseExample_", 2104, 16, true);
#nullable restore
#line 40 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
WriteAttributeValue("", 2120, post.Post.Id, 2120, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <div class=\"card card-body\">\r\n                                <p>Total number of Comments: ");
#nullable restore
#line 42 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                                        Write(post.Post.PostReplies.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 43 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                 foreach (var reply in post.Post.PostReplies)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"card card-body m-3\">\r\n                                        <h6><b>Commented By: ");
#nullable restore
#line 46 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                                        Write(reply.User.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h6>\r\n                                        <ul class=\"list-group list-group-flush mt-5\">\r\n                                            <li class=\"list-group-item\"><b>Comment:</b> ");
#nullable restore
#line 48 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                                                                   Write(reply.ReplyContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                            <li class=\"list-group-item\"><b>Date Created:</b> ");
#nullable restore
#line 49 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                                                                        Write(reply.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                        </ul>\r\n                                    </div>\r\n");
#nullable restore
#line 52 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 57 "C:\Users\Villar\Desktop\Forum\Forum\Views\Forum\Posts.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Forum.ViewModels.PostsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
