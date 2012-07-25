﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
    Inherits="System.Web.Mvc.ViewPage<EditPosts.Views.Models.PostIndexViewModel>" %>

<%@ Import Namespace="EditPosts.Domain" %>
<%@ Import Namespace="EditPosts.Views.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Main Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="leftpanel">
        <h2>
            Latest Post :</h2>
        <% foreach (Post post in Model.LatestPosts)
           {%>
        <% Html.RenderPartial("Preview", new PostPreviewViewModel { Post = post }); %>
        <% } %>
        <hr />
    </div>
    <div class="rightpanel">
        <%= Html.Action("TagsAndPopularPosts", "Post") %>
    </div>
</asp:Content>