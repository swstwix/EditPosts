﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/AdminArea.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.PostsModels.PostDetailsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Post.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Model.Post.Name %></h2>
    <div>
        Hit count :
        <%= Model.Post.HitCount %>
    </div>
    <div>
        Date created :
        <%= Model.Post.PostDate %>
        <br />
        <br />
    </div>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new {id = Model.Post.Id}, new {@class = "button"}) %>
        |
        <%: Html.ActionLink("Back to List", "Index", new {}, new {@class = "button"}) %>
    </p>
    <div>
        <%= Model.Post.Body %>
    </div>
</asp:Content>