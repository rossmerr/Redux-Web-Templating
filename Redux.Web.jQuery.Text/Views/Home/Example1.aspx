<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Redux.Web.jQuery.Text.Models.TestObject>>" %>
<%@ Import Namespace="Redux.Web.jQuery.Dialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Example 1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    

    <%= Html.DialogForm() %>
    <%= Html.DialogValidate() %>

        <p id="opener">click me</p>

        <div id="dialog" title="Basic dialog">
    	    <p>Loading</p>
        </div>
        <%= Html.Dialog("#dialog", new { Controller = "Home", Action = "Partial" }).Buttons(buttons =>
                                                                                                           {
                                                                                                               buttons.AddButton("Cancel").Reset().Close();
                                                                                                               buttons.AddButton("Create").Validate().Submit().Reset().Close();
                                                                                                           }).AutoOpen(false)%>

        <%= Html.DialogOpener("#opener", "#dialog") %>

</asp:Content>
