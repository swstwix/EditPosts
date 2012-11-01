﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.PostsModels.PostDetailsModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Post.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-fluid">
        <div class="well span12">
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
            <%: Html.ActionLink("Back to List", "Index", new {}, new {@class = "btn btn-primary"}) %>
        </div>
        <div class="well span12">
            <%= Model.Post.Body %>
        </div>
    </div>
</asp:Content>