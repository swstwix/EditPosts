<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.PostsModels.PostIndexModel>" %>
<%@ Import Namespace="EditPosts.PresentationServices.ViewModels.PostsModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Main Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="leftpanel">
        <h2>
            Latest Post :</h2>
        <% foreach (PostPreviewModel post in Model.LatestPosts)
           {%>
            <% Html.RenderPartial("Preview", post); %>
            <br />
        <% } %>
    </div>
    <div class="rightpanel">
        <%= Html.Action("TagCloud", "Tag") %>
    </div>
</asp:Content>