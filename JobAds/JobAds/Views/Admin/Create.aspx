<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<JobAds.Domain.Entities.JobAd>" %>

<asp:Content ContentPlaceHolderID="TitleContents" runat="server">
    Post a new Job Ad
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <h2>Post a new Job Ad</h2>

    <% Html.EnableClientValidation(); %>
    <% using(Html.BeginForm()) { %>        
        <%= Html.HiddenFor(x => x.JobAdId) %>
        <table align="center">
            <tr>
                <td colspan="2">
                    <div class="field">
                        <label>Job title:</label>
                        <%= Html.TextBoxFor(x => x.Title, new { @class = "text-box fullwidth" }) %>
                        <%= Html.ValidationMessageFor(x => x.Title) %>
                    </div>                
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <div class="field">
                        <label>Job details</label>
                        <div class="subfield">
                            <label>Base Salary ($):</label>
                            <%= Html.EditorFor(x => x.Salary) %>
                            <%= Html.ValidationMessageFor(x => x.Salary) %>
                        </div>
                        <div class="subfield">
                            <label>Location:</label>
                            <%= Html.EditorFor(x => x.Location) %>
                            <div class="hint">Specify city and country</div>
                            <%= Html.ValidationMessageFor(x => x.Location) %>
                        </div>            
                    </div>                
                </td>
                <td>
                    <div class="field">
                        <label>Ad preferences</label>
                        <div class="subfield">
                            <label>Publish from:</label>
                            <%= Html.EditorFor(x => x.PublishFromDate) %>
                            <%= Html.ValidationMessageFor(x => x.PublishFromDate) %>
                        </div>
                        <div class="subfield">
                            <label>Visible to:</label>
                            <div><%= Html.EditorFor(x => x.OnlyMembersMaySeeDetails) %></div>
                        </div>            
                    </div>                   
                </td>
            </tr>
        </table>
        <input type="submit" value="Save" />


    <% } %>

</asp:Content>


