<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EditPosts.PresentationServices.ViewModels.TagsModels.TagCloudModel>" %>
<%@ Import Namespace="EditPosts.PresentationServices.ViewModels.TagsModels.TagItem" %>
<div id="xlistwarp">
    <h2>
        Tag cloud :</h2>
    <fieldset>
        <legend>
            <h4>
                Tag with hit rating :</h4>
        </legend>
        <ul id="xlist">
            <% foreach (TagCloudItemModel tag in Model.AllTags)
               { %>
                <li value="<%= tag.Rating %>">
                    <%= Html.ActionLink(string.Format("{0}({1})", tag.Name, tag.Rating), "Index", "Tag",
                                        new {name = tag.Name}, new {}) %>
                </li>
            <%
               }%>
        </ul>
    </fieldset>
</div>
<script src='<%= Url.Content(@"../../Scripts/jquery-1.5.1.min.js") %>' type="text/javascript"> </script>
<script src='<%= Url.Content(@"../../Scripts/jquery.tinysort.min.js") %>' type="text/javascript"> </script>
<script src='<%= Url.Content(@"../../Scripts/jquery.tagcloud.min.js") %>' type="text/javascript"> </script>
<script>
    $("#xlist").tagcloud({ colormin: "d88", colormax: "d08", type: "list", sizemin: 20, sizemax: 40 });
</script>
<hr />