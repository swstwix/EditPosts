<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<EditPosts.Views.Models.TagCloudWithBestPost>" %>

<%@ Import Namespace="EditPosts.Domain" %>
<%@ Import Namespace="EditPosts.Views.Models" %>
<div id="xlistwarp">
    <h2>
        Tag cloud :</h2>
    <fieldset>
        <legend>
            <h4>
                Tag with hit rating :</h4>
        </legend>
        <ul id="xlist">
            <% foreach (Tag tag in Model.AllTags)
               { %>
            <li value="<%= tag.Posts.Count %>">
                <%= Html.ActionLink(string.Format("{0}({1})", tag.Name, tag.Rating), "Index", "Tag",
                                        new {name = tag.Name}, new {}) %>
            </li>
            <%
               }%>
        </ul>
    </fieldset>
</div>
<hr />
<h2>
    Popular posts :</h2>
<% foreach (Post post in Model.BestPosts)
   {%>
<% Html.RenderPartial("Preview", new PostPreviewViewModel { Post = post }); %>
<% } %>
<script src='<%= Url.Content(@"../../Scripts/jquery-1.5.1.min.js") %>' type="text/javascript"> </script>
<script src='<%= Url.Content(@"../../Scripts/jquery.tinysort.min.js") %>' type="text/javascript"> </script>
<script src='<%= Url.Content(@"../../Scripts/jquery.tagcloud.min.js") %>' type="text/javascript"> </script>
<script>
    $("#xlist").tagcloud({ colormin: "d88", colormax: "d08", type: "list", sizemin: 20, sizemax: 40 });
</script>
<hr />