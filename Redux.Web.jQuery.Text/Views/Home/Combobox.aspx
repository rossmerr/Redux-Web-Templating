<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Redux.Web.jQuery.Text.Models.ComboboxModel>" %>
<%@ Import Namespace="Redux.Web.jQuery.Combobox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Combobox</title>
	

    <%= Html.ComboboxApi() %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Combobox</h2>

    <%=Html.ComboboxFor( p=> p.ListOne, Model.ListOne) %>


    
    <%=Html.ComboboxFor( p=> p.ListTwo, Model.ListTwo) %>

    <script>
        $(document).ready(function () {

            $('#ListTwo').change(function (eventObject) {
                console.log($(eventObject.target).val());
            })

        });
    </script>

</asp:Content>
