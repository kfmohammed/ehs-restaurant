<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Restaurant.Web.Models.RegisterModel>" %>
<div>
    <% using (Html.BeginForm("Register", "Account", FormMethod.Post)) { %>
    <%: Html.AntiForgeryToken() %>
        <table style="width:100%;">
            <tr>
                <td colspan="2" class="specialOffers">
                    <div class="specialOffersHead">Create an account</div>
                    <div class="specialOffersText">
                        <table style="font-style:normal;">
<%--                            <tr style="color:Red;">
                                <td colspan="2"><%: Html.ValidationSummary(true, "")%></td>
                            </tr>--%>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.rFirstName) %></td>
                                <td><%: Html.TextBoxFor(m => m.rFirstName, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.rLastName) %></td>
                                <td><%: Html.TextBoxFor(m => m.rLastName, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.rUserName) %></td>
                                <td><%: Html.TextBoxFor(m => m.rUserName, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.Password)%></td>
                                <td><%: Html.PasswordFor(m => m.Password, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.ConfirmPassword)%></td>
                                <td><%: Html.PasswordFor(m => m.ConfirmPassword, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.rAddressLine1) %></td>
                                <td><%: Html.TextBoxFor(m => m.rAddressLine1, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td>&nbsp;</td>
                                <td><%: Html.TextBoxFor(m => m.rAddressLine2, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td>&nbsp;</td>
                                <td><%: Html.TextBoxFor(m => m.rAddressLine3, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td>&nbsp;</td>
                                <td><%: Html.TextBoxFor(m => m.rPostcode, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:15px;">
                                <td style="padding-right:5px;"><%: Html.LabelFor(m => m.rPhoneNumber) %></td>
                                <td><%: Html.TextBoxFor(m => m.rPhoneNumber, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="2" style="float:right;">
                                    <input type="submit" value="Register" style="width:100px;height:30px;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    <% } %>
</div>