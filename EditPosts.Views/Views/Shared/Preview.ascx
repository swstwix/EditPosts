<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EditPosts.PresentationServices.ViewModels.PostsModels.PostPreviewModel>" %>
<%@ Import Namespace="EditPosts.PresentationServices.Utils.Extensions" %>
<div class="well">
    <%: Html.ActionLink("View", "Details", "Post", new {id = Model.PostId}, new {@class = "btn pull-right btn-primary"}) %>
    <h4><%= Model.Name %></h4>
    <p><%= Model.Body.AsHtmlPreview(300) %></p>
</div>