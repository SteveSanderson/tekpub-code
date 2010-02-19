<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<bool>" %>

<% var options = ViewData.ModelMetadata.AdditionalValues["optionValues"]; %>
<% foreach(var option in (IDictionary<object, string>)options) { %>
    <label>
        <%= Html.RadioButton("", option.Key, option.Key.Equals(Model)) %>
        <%= option.Value %>
    </label>
    <br />
<% } %>
