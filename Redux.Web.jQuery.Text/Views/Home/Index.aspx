<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Redux.Web.jQuery.Text.Models" %>
<%@ Import Namespace="Redux.Web.Templating" %>
<%@ Import Namespace="Redux.Web.Html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= Html.ActionLink("Example 1", "Example1") %>
    </p>

    <p>
        <%= Html.ActionLink("Example 2", "Example2") %>
    </p>

    <p>
        <%= Html.ActionLink("Example 3", "Example3") %>
    </p>

    <p>
        <%= Html.ActionLink("Example 4", "Example4") %>
    </p>


</asp:Content>
