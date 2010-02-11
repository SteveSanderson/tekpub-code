<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SearchResultsViewModel>" %>
<%@ Import Namespace="JobAds.Models" %>
<asp:Content ContentPlaceHolderID="TitleContents" runat="server">
    Search results for '<%= Html.Encode(Model.Query) %>'
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("SearchForm"); %>
    
    <div class="resultsSummary">
        <a class="rssLink" href="<%= Url.Action("Feed", new { query = Model.Query }) %>">
            <img src="/content/rss.jpg" />
        </a>
        <a class="excelLink" href="<%= Url.Action("Export", new { query = Model.Query }) %>"><img src="/content/excel.jpg" /></a>
        Results 
        <b><%= Model.PagingInfo.FirstResultIndex %> - <%= Model.PagingInfo.LastResultIndex %></b> of <b><%= Model.PagingInfo.TotalResults %></b> 
        for <b><%= Html.Encode(Model.Query) %></b>
        
        <% if (Model.SearchSuggestion != null) { %>
            <span class="suggestion">                
                Did you mean:
                <%= Html.ActionLink(Model.SearchSuggestion, "Search",
                                    new { query = Model.SearchSuggestion }) %>?
            </span>
        <% } %>
    </div>
    
    <table class="jobAdsTable" cellspacing="0">
        <% foreach(var ad in Model.Results) { %>
            <tr>
                <td class="jobTitle"><%= ad.Title %></td>
                <td class="jobLocation"><%= ad.Location %></td>
                <td class="jobSalary"><%= ad.Salary.ToString("$0,000") %></td>
                <td class="jobDownload"><%= Html.ActionLink("Details (PDF)", "DownloadJobDetails", new { ad.JobAdId }) %></td>
            </tr>
        <% } %>
    </table>
    
    <div class="pageLinks">
        Page:
        <% for(var i = 1; i <= Model.PagingInfo.PageCount; i++) { %>
            <% if (i == Model.PagingInfo.CurrentPage) { %>
                <b><%= i %></b>
            <% } else { %>
                <%= Html.ActionLink(i.ToString(), "Search", new { query = Model.Query, page = i }) %>
            <% } %>
        <% } %>
    </div>
</asp:Content>
