<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.List<Redux.Web.jQuery.Text.Models.TestObject>>" %>
<%@ Import Namespace="Redux.Web.jQuery.Text.Models" %>
<%@ Import Namespace="Redux.Web.Templating" %>
<%@ Import Namespace="Redux.Web.jQuery.Jeditable" %>
<%@ Import Namespace="Redux.Web.jQuery.Flexigrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>
    Example4
    </title>
    <%= Html.FlexigridApi() %>
    <%= Html.FlexigridStyle() %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Example4</h2>

    <%= Html.Flexigrid<TestObject>(Model, columns =>
                                        {
                                            columns.AddColumn(p => p.One).Width(150).Sortable(true).Editable("edit", new { Controller = "Home", Action = "EditCell" });
                                            columns.AddColumn(p => p.Two);
                                        }).UsePager().UseRp(false).Url(new { Controller = "Home", Action = "Example4" }).ShowTableToggleBtn().Width(400).Height(100).Title("test")%>




    <%= Html.Flexigrid<TestObject>(Model, columns =>
                                        {
                                            columns.AddColumn(p => p.Two).IsVisible(false);
                                            columns.AddColumn(p => p.One).Width(150).Sortable(true);
                                           
                                        }).UsePager().UseRp(false).ShowTableToggleBtn().Width(500).Height(100).Title("test")%>


    <%= Html.Flexigrid<TestObject>(Model, columns =>
                                        {
                                            columns.AddColumn(p => p.One).Width(150).Sortable(true);
                                            columns.AddColumn(p => p.Two);
                                        }).UsePager().UseRp(false).ShowTableToggleBtn().Width(500).Height(100).Title("test").DataType(Redux.Web.Templating.DataType.Json)%>


    <%= Html.Flexigrid<TestObject>(Model, columns =>
                                        {
                                            columns.AddColumn(p => p.One).Width(150).Sortable(true);
                                            columns.AddColumn(p => p.Two);
                                        }).SearchItems(search =>
                                                           {
                                                               search.AddField(p => p.One, "test");
                                                           })
                                        .UsePager().UseRp(false).ShowTableToggleBtn().Width(500).Height(100).Title("test").DataType(Redux.Web.Templating.DataType.Json)%>
</asp:Content>
