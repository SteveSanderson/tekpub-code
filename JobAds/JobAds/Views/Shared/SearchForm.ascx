<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="searchForm">
    <% using(Html.BeginForm("Search", "Jobs", FormMethod.Get)) { %>
        <h2>
            Search job ads:
            <%= Html.TextBox("query") %>
            <input type="submit" value="Search" />
        </h2>
    <% } %>
</div>