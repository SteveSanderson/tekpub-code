<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JobAds.Domain.Entities.JobAd>" %>

<asp:Content ContentPlaceHolderID="TitleContents" runat="server">
    <%= Model.Title %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2>Details about <%= Model.Title %></h2>
    Todo: Details will go here...
</asp:Content>

