<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
         Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.PostsModels.PostEditViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Post.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <h2>
        <%= ViewData.GetViewDataInfo("OldName").Value %></h2>
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
    <hr />
    <h4>
        Try to edit :</h4>
    <% using (Html.BeginForm("Edit", "Post"))
       { %>
        <script type="text/javascript" src='<%= Url.Content("~/Scripts/ckeditor/ckeditor.js") %>'> </script>
        <%= Html.LabelFor(model => model.Post.Name, "Name : ") %>
        <br />
        <%= Html.TextBoxFor(model => model.Post.Name, new {style = "width: 100px;"}) %>
        <%= Html.ValidationMessageFor(model => model.Post.Name) %>
        <div>
            Tags :</div>
        <div>
            <ul id="tags" name="tags">
                <% foreach (string tag in Model.Tags.Split(';'))
                   {%>
                    <li>
                        <%= tag %></li>
                <% } %>
            </ul>
            <script src='<%= Url.Content("~/Scripts/Tagit/demo/js/jquery.1.7.2.min.js") %>'> </script>
            <script src='<%= Url.Content("~/Scripts/Tagit/demo/js/jquery-ui.1.8.20.min.js") %>'> </script>
            <script src='<%= Url.Content("~/Scripts/Tagit/js/tagit.js") %>'> </script>
            <link type="text/css" rel="stylesheet" href='<%= Url.Content("~/Scripts/Tagit/css/tagit-dark-grey.css") %>' />
            <script type="text/javascript">
                var availableTags = [
                    <%= Model.AvailableTags %>
                ];

                $("#tags").tagit({ tagSource: availableTags });
                var changeField = function() {
                    var selector = $("#tags>li");
                    var s = "";
                    selector.each(function(index) {
                        var len = $(this).text().toString().length;
                        s = s + $(this).text().toString().substring(0, len - 1) + ";";
                    });
                    var len = s.length;
                    s = s.substring(0, len - 1);
                    $("#Tags").val(s);
                };
                $("#tags").keydown(changeField);
                $("#tags").mouseleave(changeField);
            </script>
        </div>
        <p>
            <%= Html.TextAreaFor(model => model.Post.Body, new {id = "ckeditor"}) %>
            <%= Html.HiddenFor(p => p.Post.PostDate) %>
            <%= Html.HiddenFor(p => p.Post.Id) %>
            <%= Html.HiddenFor(p => p.Tags) %>
            <%= Html.HiddenFor(p => p.Post.HitCount) %>
        </p>
        <input type="submit" value="Save text" class="button" />
    <% } %>
    <script>
        CKEDITOR.replace('ckeditor');
    </script>
</asp:Content>