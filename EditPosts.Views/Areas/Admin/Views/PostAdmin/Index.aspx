<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.PostsModels.PostAdminModel>" %>
<%@ Import Namespace="EditPosts.Domain.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="span12">
        <h2>All posts</h2>
        <table class="table table-striped well">
            <thead>
                <tr>
                    <th>Name :</th>
                    <th>Post date :</th>
                    <th>Hit count :</th>
                    <th style="width: 110px;">Actions :</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (Post post in Model.Posts)
                   {%>
                <tr>
                    <td>
                        <%= post.Name %>
                    </td>
                    <td>
                        <%= post.PostDate %>
                    </td>
                    <td>
                        <%= post.HitCount %>
                    </td>
                    <td>
                        <%= Html.ActionLink("View", "Details", "PostAdmin", new {id = post.Id},new {@class = "btn btn-primary"}) %>
                        <%= Html.ActionLink("Edit", "Edit", "PostAdmin",new {id = post.Id},new {@class = "btn btn-primary"}) %>
                    </td>
                </tr>
                <% } %>
            </tbody>
        </table>

        <%= Html.ActionLink("Create", "Create", "Post", new {@class = "btn btn-large btn-primary"}) %>
    </div class="span12">
    
</asp:Content>