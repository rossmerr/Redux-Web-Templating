<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<TestObject>>" %>
<%@ Import Namespace="Redux.Web.jQuery.Text.Models" %>
<%@ Import Namespace="Redux.Web.Templating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Example2
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Example2</h2>
    <p>Table converted into flexigrid with height, and width set to auto, stripes remove.</p>

    <table class="flexme">
        <thead>
    		    <tr>
            	    <th width="100">Col 1</th>
            	    <th width="100">Col 2</th>

            	    <th width="100">Col 3 is a long header name</th>
            	    <th width="300">Col 4</th>
                </tr>
        </thead>
        <tbody>
    		    <tr>
            	    <td>This is data 1 with overflowing content</td>

            	    <td>This is data 2</td>
            	    <td>This is data 3</td>
            	    <td>This is data 4</td>
                </tr>
    		    <tr>
            	    <td>This is data 1</td>
            	    <td>This is data 2</td>

            	    <td>This is data 3</td>
            	    <td>This is data 4</td>
                </tr>
    		    <tr>
            	    <td>This is data 1</td>
            	    <td>This is data 2</td>
            	    <td>This is data 3</td>

            	    <td>This is data 4</td>
                </tr>
    		    <tr>
            	    <td>This is data 1</td>
            	    <td>This is data 2</td>
            	    <td>This is data 3</td>
            	    <td>This is data 4</td>

                </tr>
    		    <tr>
            	    <td>This is data 1</td>
            	    <td>This is data 2</td>
            	    <td>This is data 3</td>
            	    <td>This is data 4</td>
                </tr>

    		    <tr>
            	    <td>This is data 1</td>
            	    <td>This is data 2</td>
            	    <td>This is data 3</td>
            	    <td>This is data 4</td>
                </tr>
        </tbody>        
    </table>

 


    <%= Html.Flexigrid<TestObject>(".flexme", new { Width= 100, Height = 200 }) %>
</asp:Content>
