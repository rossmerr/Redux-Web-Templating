<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TestObject>" %>
<%@ Import Namespace="Redux.Web.jQuery.Text.Models" %>
<%@ Import Namespace="Reduc.Web.jQuery.Timepicker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Example2</title>
    <%= Html.TimepickerApi() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Example2</h2>
    <p>Table converted into flexigrid with height, and width set to auto, stripes remove.</p>

    <%= Html.TimepickerFor(p => p.One) %>

</asp:Content>
