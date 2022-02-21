<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Restaurant.Web.Models.LoginModel>" %>
<div>
    <% using (Html.BeginForm("Login", "Account", new { ReturnUrl = ViewBag.ReturnUrl })) { %>
    <%: Html.AntiForgeryToken() %>
        <table style="width:100%;">
            <tr>
                <td colspan="2" class="specialOffers">
                    <div class="specialOffersHead">Sign in</div>
                    <div class="specialOffersText">
                        <table style="font-style:normal;">
<%--                            <tr style="color:Red;">
                                <td colspan="2"><%: Html.ValidationSummary(true)%></td>
                            </tr>--%>
                            <tr style="width:100%;min-width:300px;height:10px;">
                                <td style="padding-right:10px;"><%: Html.LabelFor(m => m.UserName) %></td>
                                <td><%: Html.TextBoxFor(m => m.UserName, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <tr style="width:100%;min-width:300px;height:30px;">
                                <td style="padding-right:10px;"><%: Html.LabelFor(m => m.Password) %></td>
                                <td><%: Html.PasswordFor(m => m.Password, new { style = "width:150px;padding:2px;font-size:8pt;color:#3C3C3C;" })%></td>
                            </tr>
                            <!--<tr style="width:100%;min-width:300px;">
                                <td>&nbsp;</td>
                                <td>
                                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                                    <%: Html.LabelFor(m => m.RememberMe, new { @class = "checkbox" }) %>
                                </td>
                            </tr>-->
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="2" style="float:right;">
                                    <input type="submit" value="Sign in" style="width:100px;height:30px;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    <% } %>
</div>