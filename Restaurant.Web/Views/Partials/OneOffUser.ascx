<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Restaurant.Web.Models.OneOffUserModel>" %>
<div>
    <% using (Html.BeginForm("CreateOneOffUser", "Account", FormMethod.Post)) { %>
    <%: Html.AntiForgeryToken() %>
        <table style="width:100%;">
            <tr>
                <td colspan="2" class="specialOffers">
                    <div class="specialOffersHead">Your Details</div>
                    <div class="specialOffersText">
                        <table style="font-size:9pt;font-style:normal;width:100%;">
<%--                            <tr style="color:Red;">
                                <td colspan="2"><%: Html.ValidationSummary(true, "")%></td>
                            </tr>--%>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.exFirstName) %></td>
                                <td><%: Html.TextBoxFor(m => m.exFirstName, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.exLastName) %></td>
                                <td><%: Html.TextBoxFor(m => m.exLastName, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.exUserName)%></td>
                                <td><%: Html.TextBoxFor(m => m.exUserName, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.exAddressLine1)%></td>
                                <td><%: Html.TextBoxFor(m => m.exAddressLine1, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td>&nbsp;</td>
                                <td><%: Html.TextBoxFor(m => m.exAddressLine2, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td>&nbsp;</td>
                                <td><%: Html.TextBoxFor(m => m.exAddressLine3, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.exPostcode)%></td>
                                <td><%: Html.TextBoxFor(m => m.exPostcode, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.exPhoneNumber)%></td>
                                <td><%: Html.TextBoxFor(m => m.exPhoneNumber, new { style = "width:150px;padding:2px;font-size:9pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="2" style="float:right;">
                                    <input type="submit" value="Order Now" style="width:100px;height:30px;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    <% } %>
</div>