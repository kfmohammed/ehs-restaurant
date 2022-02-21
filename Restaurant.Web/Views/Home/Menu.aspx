<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Restaurant.Web.Models.MenuModel>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/Content/jquery.ui.css" />
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.tmpl.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#accordion").accordion({
                collapsible: true
            });

            RenderYourOrderTable(0);
            $('input:radio[name=rdCollOrDeli]').click(function () { RenderYourOrderTable(0); });
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

            var URL = "/GetYourOrder/" + addOrDelete + "/" + menuId + "/" + CollOrDeli + "/" + (new Date()).getTime();

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
                    <td style="width:20px;"><img id=Delete{{= MenuId}} src="/Images/Delete.png" title="Add this to my order" onClick="RenderYourOrderTable(this)" style="float:right;cursor:pointer;"/></td>
                </tr>
            {{/each}}
            <tr style="width:100%;height:40px;font-weight:bold;">
                <td style="width:200px;">Total Price</td>
                <td>{{= Data.FormattedTotalPrice}}</td>
                <td style="width:20px;">&nbsp;</td>
            </tr>
            </tr>
        </table>
    </script>
    <script id="YourOrderCompleteTemplate" type="text/html">
        <div>
            Your order is now with the restaurant.
        </div>
        <div>
            A confirmation email has been sent to the email address you've provided.
        </div>
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="site_content">
        <div id="sidebar_container">
            <table>
                <tr>
                    <% using (Html.BeginForm("Menu", "Home", FormMethod.Post)) { %>
                    <td colspan="2" class="specialOffers">
                        <div class="specialOffersHead">Your Order</div>
                        <div class="specialOffersText">
                            <table style="font-style:normal;">
                                <tr style="width:100%;min-width:300px;">
                                    <td id="YourOrderContainer"></td>
                                    </td>
                                </tr>
                                <tr style="height:20px;vertical-align:top;"><td><hr /></td></tr>
                                <tr>
                                    <td style="color:#333;text-align:justify;">
                                        <div>
                                            You can select items you wish to order and can see the total price here.
                                        </div>
                                        <div>&nbsp;</div>
                                        <div>
                                            Once you're happy, just give us a call for either collection or delivery.
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="font-weight:bold;">
                                            (01473) 222277 / 225611
                                        </div>
                                        <div>&nbsp;</div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <%} %>
                </tr>
            </table>
        </div>
        <div class="content" id="accordion">
            <% foreach (var category in Model.CategoryItems) {%>
                <h3><%=category.CategoryName%></h3>
                <div>
                    <table>
                        <% foreach (var menuItem in Model.MenuItems.Where(i => i.CategoryId == category.CategoryID)) {%>
                            <tr class="shadedItem">
                                <td style="width:100%;"><%=menuItem.MenuName%></td>
                                <td style="text-align:right;">£&nbsp;<%=menuItem.FormattedPrice%></td>
                                <td style="padding:8px;max-width:30px;">
                                    <a id="Add<%=menuItem.ID%>" onclick="RenderYourOrderTable(this)"><img src="/Images/Add.png" style="cursor:pointer;" title="Add this to my order" /></a>
                                </td>
                            </tr>
                        <%} %>
                    </table>
                </div>
            <% }%>
        </div>
        <div class="content" style="font-size:10pt;color:#333;">
            <div>
                - Any dishes not in the menu can be prepared upon request.
            </div>
            <div>
                - Please inform us of any dietary requirements such as wheat free or nut allergies when placing your order.
            </div>
            <div>
                - Some of our dishes may contain traces of nuts.
            </div>
        </div>
    </div>
</asp:Content>
