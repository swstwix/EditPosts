<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/AdminArea.Master" Inherits="System.Web.Mvc.ViewPage<EditPosts.PresentationServices.ViewModels.PostsModels.PostEditViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <script src="<%: Url.Content("~/Scripts/ckeditor/ckeditor.js") %>"> </script>
    <script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.11.js") %>"> </script>
    <link rel="stylesheet" type="text/css" href="<%: Url.Content("~/Content/themes/base/jquery.ui.all.css") %>"></link>
    <script type="text/javascript">
        $(function() {
            $(function() {

                function split(val) {
                    return val.split( /,\s*/ );
                }

                function extractLast(term) {
                    return split(term).pop();
                }

                $("#Tags")
                    // don't navigate away from the field on tab when selecting an item
                    .bind("keydown", function(event) {
                        if (event.keyCode === $.ui.keyCode.TAB &&
                            $(this).data("autocomplete").menu.active) {
                            event.preventDefault();
                        }
                    })
                    .autocomplete({
                        source: function(request, response) {
                            $.getJSON("<%= Url.Action("TagsForAutocomplete", "Tag") %>", {
                                term: extractLast(request.term)
                            }, response);
                        },
                        search: function() {
                            // custom minLength
                            return extractLast(this.value);
                        },
                        focus: function() {
                            // prevent value inserted on focus
                            return false;
                        },
                        select: function(event, ui) {
                            var terms = split(this.value);
                            // remove the current input
                            terms.pop();
                            // add the selected item
                            terms.push(ui.item.value);
                            // add placeholder to get the comma-and-space at the end
                            terms.push("");
                            this.value = terms.join(", ");
                            return false;
                        }
                    });
            });
        });

    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <%= ViewData.GetViewDataInfo("oldName").Value %>
    </h2>

    <% using (Html.BeginForm())
       {%>
        <%: Html.ValidationSummary(true) %>

        <div>
            <%: Html.LabelFor(model => model.HitCount) %> :
            <%: Html.DisplayFor(model => model.HitCount) %>
        </div>

        <div>
            <%: Html.LabelFor(model => model.Date) %> :
            <%: Html.DisplayFor(model => model.Date) %>
        </div>
            
        <hr/>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Tags) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Tags) %>
            <%: Html.ValidationMessageFor(model => model.Tags) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Body) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Body, new {@class = "ckeditor"}) %>
            <%: Html.ValidationMessageFor(model => model.Body) %>
        </div>

        <p>
            <input type="submit" value="Save" class="button"/>
        </p>
    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>