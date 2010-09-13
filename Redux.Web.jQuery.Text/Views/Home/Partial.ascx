<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Redux.Web.jQuery.Text.Models.TestObject>" %>


    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.One) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.One, new { @class = "required" })%>
                <%: Html.ValidationMessageFor(model => model.One) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Two) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Two) %>
                <%: Html.ValidationMessageFor(model => model.Two) %>
            </div>
        </fieldset>

    <% } %>

