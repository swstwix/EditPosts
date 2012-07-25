<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.Views.Models.PostAdminViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="post_table">
        <table>
            <caption>
                Posts from
                <%= Model.BeginIndex() %>
                to
                <%= Model.EndIndex() %></caption>
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
                <% for (int i = Model.BeginIndex(); i < Model.EndIndex(); i++)
                   {%>
                    <tr>
                        <td>
                            <div class="table_postname">
                                <%= Model.Posts.ElementAt(i).Name %>
                            </div>
                        </td>
                        <td>
                            <div class="table_postdate">
                                <%= Model.Posts.ElementAt(i).PostDate %>
                            </div>
                        </td>
                        <td>
                            <div class="table_postcount">
                                <%= Model.Posts.ElementAt(i).HitCount %>
                            </div>
                        </td>
                        <td>
                            <span>
                                <% using (Html.BeginForm("Delete", "Post", new {id = Model.Posts.ElementAt(i).Id, page = Model.CurrentPage}))
                                   { %>
                                    <%= Html.ActionLink("View", "Details", "Post", new {id = Model.Posts.ElementAt(i).Id},
                                        new {@class = "button"}) %>
                                    <%= Html.ActionLink("Edit", "Edit", "Post",
                                        new {id = Model.Posts.ElementAt(i).Id},
                                        new {@class = "button"}) %>
                                    <input type="submit" value="Delete" class="button" />
                                <% } %></span>
                        </td>
                    </tr>
                <% } %>
            </tbody>
        </table>
        <% using (Html.BeginForm("Create", "Post"))
           {%>
            <input type="submit" value="Add new post" class="button" />
        <% } %>
    </div>
</asp:Content>