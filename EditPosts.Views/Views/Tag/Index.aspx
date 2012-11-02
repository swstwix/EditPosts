<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.TagsModels.TagIndexModel>" %>
<%@ Import Namespace="EditPosts.Domain.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Tag.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span6">
        <h2>Posts with <%= Model.Tag.Name %>:</h2>
        <% foreach (Post post in Model.Tag.Posts)
           {%>
              <div class="well">
                <h4><%= post.Name %></h4>
                <%= post.Body %>
                <%= Html.ActionLink("View", "Details", "Post", new {id = post.Id}, new {@class = "button"}) %>
              </div>
        <% } %>
    </div>
    <div class="span6">
        <%= Html.Action("TagCloud", "Tag") %>
    </div>
</asp:Content>