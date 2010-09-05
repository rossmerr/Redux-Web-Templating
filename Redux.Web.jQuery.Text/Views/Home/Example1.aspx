<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Redux.Web.jQuery.Text.Models.TestObject>>" %>
<%@ Import Namespace="Redux.Web.jQuery.Dialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Example 1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    

    <%= Html.DialogForm() %>
    <%= Html.DialogValidate() %>

        <div id="dialog" title="Basic dialog">
    	    <p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
        </div>
        <%= Html.Dialog("#dialog", new { Controller = "Home", Action = "Partial" }).Buttons(buttons => {
                                                                                                            buttons.AddButton("Create",string.Empty);
                                                                                                        })%>

</asp:Content>
