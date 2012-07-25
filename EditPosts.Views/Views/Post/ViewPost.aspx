<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainContent.Master"
    Inherits="System.Web.Mvc.ViewPage<EditPosts.Domain.Models.Post>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Model.Name %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Model.Name %></h2>
    <div>
        Hit count :
        <%= Model.HitCount %>
    </div>
    <div>
        Date created :
        <%= Model.PostDate %>
        <br />
        <br />
    </div>
    <p>
        <%: Html.ActionLink("Edit", "Details", new {id = Model.Id}, new {@class = "button"}) %>
        |
        <%: Html.ActionLink("Back to List", "Admin", new {}, new {@class = "button"}) %>
    </p>
    <div>
        <%= Model.Body %>
    </div>
</asp:Content>