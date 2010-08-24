<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<TestObject>" %>
<%@ Import Namespace="Redux.Web.jQuery.Text.Models" %>
<%@ Import Namespace="Redux.Web.jQuery.SmartTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>
    Example3
    </title>
    <%= Html.SmartTextBoxApi() %>
    <%= Html.SmartTextBoxStyle() %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Example3</h2>

    <%= Html.SmartTextBoxFor(p => p.One).SubmitChars(',').AutocompleteUrl(new { Controller = "Home", Action = "Example3Json" }).OnlyAutocomplete(true)%>



</asp:Content>
