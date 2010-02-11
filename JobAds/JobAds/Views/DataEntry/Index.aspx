<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Please enter some text</h2>

    <% using(Html.BeginForm()) { %>
        <%= Html.HttpMethodOverride(HttpVerbs.Put) %>
    
        Your text: <%= Html.TextBox("text") %>
        <input type="submit" value="Go" />
    <% } %>
</asp:Content>