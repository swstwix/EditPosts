<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.PostsModels.PostAdminModel>" %>
<%@ Import Namespace="EditPosts.Domain.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="post_table">
        <table>
            <caption>
                All Posts</caption>
            <thead>
                <th>
                    Name :
                </th>
                <th>
                    Post date :
                </th>
                <th>
                    Hit count :
                </th>
                <th>
                </th>
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
                            <span>
                                <% using (Html.BeginForm("Delete", "Post", new {id = post.Id}))
                                   { %>
                                    <%= Html.ActionLink("View", "Details", "Post", new {id = post.Id},
                                        new {@class = "button"}) %>
                                    <%= Html.ActionLink("Edit", "Edit", "Post",
                                        new {id = post.Id},
                                        new {@class = "button"}) %>
                                    <input type="submit" value="Delete" class="button" />
                                <% } %></span>
                        </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
        <%= Html.ActionLink("Create", "Create", "Post", new {@class = "button"}) %>
    </div>
</asp:Content>