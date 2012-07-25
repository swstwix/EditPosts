<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EditPosts.Views.Models.PostPreviewViewModel>" %>
<fieldset>
    <legend>
        <h4>
            <%= Model.Post.Name %></h4>
    </legend>
    <div class="preview_text">
        <%= Model.PreviewText %>
    </div>
    <br />
    <%: Html.ActionLink("View", "ViewPost", "Post", new {id = Model.Post.Id},
                                        new {@class = "button"}) %>
</fieldset>