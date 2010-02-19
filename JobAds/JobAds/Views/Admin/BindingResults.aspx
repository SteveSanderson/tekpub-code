<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JobAds.Domain.Entities.JobAd>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>You entered:</h2>

    <div>JobAdId: <b><%= Model.JobAdId %></b></div>
    <div>Title: <b><%= Model.Title %></b></div>
    <div>Salary: <b><%= Model.Salary %></b></div>
    <div>Location: <b><%= Model.Location %></b></div>
    <div>OnlyMembersMaySeeDetails: <b><%= Model.OnlyMembersMaySeeDetails %></b></div>
    <div>PublishFromDate: <b><%= Model.PublishFromDate %></b></div>
    
    <hr />
    You came from: <b><%= ViewData["referer"] ?? "unknown" %></b>
    
</asp:Content>