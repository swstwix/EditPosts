<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
    Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.TagsModels.TagIndexModel>" %>

<%@ Import Namespace="EditPosts.Domain" %>
<%@ Import Namespace="EditPosts.Domain.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Tag.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="leftpanel">
        <h2>
            Posts with
            <%= Model.Tag.Name %>
            :</h2>
        <% foreach (Post post in Model.Tag.Posts)
           {%>
        <fieldset>
            <legend>
                <h4>
                    <%= post.Name %></h4>
            </legend>
            <%= post.Body %>
            <%= Html.ActionLink("View", "ViewPost", "Post", new {id = post.Id}, new {@class = "button"}) %>
        </fieldset>
        <% } %>
    </div>
    <div class="rightpanel">
        <%= Html.Action("TagsAndPopularPosts", "Post") %>
    </div>
    <script src='<%= Url.Content(@"~/Scripts/jquery-1.5.1.min.js") %>' type="text/javascript"> </script>
    <script src='<%= Url.Content(@"~/Scripts/jquery.tinysort.min.js") %>' type="text/javascript"> </script>
    <script src="../../Scripts/jquery.tagcloud.min.js" type="text/javascript"> </script>
    <script>
        //$("#xlist>li").tsort({ order: "rand" });
        $("#xlist").tagcloud({ colormin: "d88", colormax: "d08", type: "list", sizemin: 20, sizemax: 40 });
    </script>
</asp:Content>