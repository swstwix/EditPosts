<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EditPosts.PresentationServices.ViewModels.PostsModels.PostPreviewModel>" %>
<%@ Import Namespace="EditPosts.PresentationServices.Utils.Extensions" %>
<fieldset>
    <legend>
        <h4>
            <%= Model.Name %></h4>
    </legend>
    <div class="preview_text">
        <%= Model.Body.AsHtmlPreview(300) %>
    </div>
    <br />
    <%: Html.ActionLink("View", "Details", "Post", new {id = Model.PostId},
                                        new {@class = "button"}) %>
</fieldset>