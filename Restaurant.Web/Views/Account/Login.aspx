<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" %>
<%@ Import Namespace="Restaurant.Web.Models" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Restaurant/Content/jquery.ui.css" />
    <script type="text/javascript" src="/Restaurant/Scripts/jquery.js"></script>
    <script type="text/javascript" src="/Restaurant/Scripts/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/Restaurant/Scripts/jquery.tmpl.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            RenderYourOrderTable(0);
        });

        function RenderYourOrderTable(obj) {
                var addOrDelete = "Nothing";
                var CollOrDeli = "Nothing";
                var menuId = 0;

                if (obj.id != undefined || obj.id != null) {
                    menuId = obj.id;

                    if (obj.id.indexOf("Add") != -1) {
                        addOrDelete = "Add";
                        menuId = menuId.replace("Add", "");
                    }
                    else if (obj.id.indexOf("Delete") != -1) {
                        addOrDelete = "Remove";
                        menuId = menuId.replace("Delete", "");
                    }
                }

                if ($('#rdCollection').attr("checked") == true) { CollOrDeli = "Collection" }
                else if ($('#rdDelivery').attr("checked") == true) { CollOrDeli = "Delivery" }

                var URL = "/Restaurant/GetYourOrder/" + addOrDelete + "/" + menuId + "/" + CollOrDeli + "/" + (new Date()).getTime();

                $.ajax({
                    type: "GET",
                    contentType: "application/json; charset=utf-8",
                    url: URL,
                    data: "{}",
                    dataType: "json",
                    error: function (data) {
                    },
                    success: function (data) {
                        if (data.Data.length == 0) {
                        }
                        else {
                            $("#YourOrderContainer").children().remove();
                            $("#YourOrderTemplate").render(data).appendTo("#YourOrderContainer");
                            $("#YourOrderContainer").fadeIn('fast');
                            if (data.Data.CompletionModeId == undefined || data.Data.CompletionModeId == null || (data.Data.CompletionModeId != 1 && data.Data.CompletionModeId != 2)) {
                                $("#rdCollection").attr("checked", false);
                                $("#rdDelivery").attr("checked", false);
                            }
                            else if (data.Data.CompletionModeId == 1) {
                                $("#rdCollection").attr("checked", true);
                                $("#rdDelivery").attr("checked", false);
                            }
                            else {
                                $("#rdCollection").attr("checked", false);
                                $("#rdDelivery").attr("checked", true);
                            }
                        }
                    }
                });
            }
    </script>

    <script id="YourOrderTemplate" type="text/html">
        <table style="font-style:normal;">
            {{each(i,client) Data.OrderMenu }}
                <tr style="width:100%;">
                    <td style="width:20px;">{{= Quantity}}&nbsp;&nbsp;&nbsp;&nbsp;x&nbsp;&nbsp;&nbsp;&nbsp;{{= MenuItem.MenuName}}</td>
                    <td style="float:right;">{{= MenuItem.FormattedPrice}}</td>
                    <td style="width:20px;"><img id=Delete{{= MenuId}} src="/Restaurant/Images/Delete.png" title="Add this to my order" onClick="RenderYourOrderTable(this)" style="float:right;cursor:pointer;"/></td>
                </tr>
            {{/each}}
            <tr style="width:100%;height:40px;font-weight:bold;">
                <td style="width:200px;">Total Price</td>
                <td>{{= Data.FormattedTotalPrice}}</td>
                <td style="width:20px;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="width:250px;height:40px;vertical-align:middle;font-size:9pt;">
                    <input type="radio" name="rdCollOrDeli" value="rdCollOrDeli" id="rdCollection" onClick="RenderYourOrderTable(this)" style="padding-right:5px;"><label for="rdCollection" style="padding-right:20px;">Collection</label></input>
                    <input type="radio" name="rdCollOrDeli" value="rdCollOrDeli" id="rdDelivery" onClick="RenderYourOrderTable(this)" style="padding-right:5px;"><label for="rdDelivery">Delivery</label></input>
                </td>
            </tr>
        </table>
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="site_content">
<%--        <div id="sidebar_container" style="width:30%;">
            <div>
                <%: Html.ValidationSummary()%>
            </div>
            <div style="padding:5px;">
                <%= Html.Partial("../Partials/Login", new LoginModel())%>
            </div>
            <div style="padding:5px;">
                <%= Html.Partial("../Partials/Register", new RegisterModel())%>
            </div>
        </div>--%>
        <div class="sidebar_container" style="width:100%;padding:8px;">
            <table>
                <tr>
                    <td style="vertical-align:top;padding:5px;width:40%;">
                        <div class="specialOffers">
                            <div class="specialOffersHead">Your Order</div>
                            <div class="specialOffersText">
                                <div id="YourOrderContainer"></div>
                            </div>
                        </div>
                    </td>
                    <td style="vertical-align:top;width:60%;padding:5px;min-height:520px;">
                        <div>
                            <%= Html.Partial("../Partials/OneOffUser", new OneOffUserModel())%>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>