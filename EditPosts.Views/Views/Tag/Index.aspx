<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.TagsModels.TagIndexModel>" %>
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
                <%= Html.ActionLink("View", "Details", "Post", new {id = post.Id}, new {@class = "button"}) %>
            </fieldset>
        <% } %>
    </div>
    <div class="rightpanel">
        <%= Html.Action("TagCloud", "Tag") %>
    </div>
</asp:Content>