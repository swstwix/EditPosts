<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EditPosts.PresentationServices.ViewModels.PostsModels.PostPreviewModel>" %>
<%@ Import Namespace="EditPosts.PresentationServices.Utils.Extensions" %>
<blockquote class="well">
    <p><%= Model.Body.AsHtmlPreview(300) %></p>
    <small><%= Model.Name %></small>
    <%: Html.ActionLink("View", "Details", "Post", new {id = Model.PostId}, new {@class = "btn pull-right btn-primary"}) %>
</blockquote>