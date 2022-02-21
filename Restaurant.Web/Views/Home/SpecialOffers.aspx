<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Restaurant.Web.Models.SpecialOffersModel>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.divroller.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="site_content">
        <div id="sidebar_container" style="width:50%;padding-left:10px;">
            <table>
                <tr>
                    <td colspan="2" class="specialOffers">
                        <div class="specialOffersHead">£10 OFF on orders over £40</div>
                        <div class="specialOffersText">
                            Cannot be used with any other offer. Valid for collection or delivery. £10 off does not apply to set meals.
                            <!--The amount will be automatically deducted when you checkout.-->
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="sidebar_container" class="specialOffers" style="padding:10px;">
            <table>
                <tr>
                    <td colspan="2" class="specialOffers">
                        <div class="specialOffersHead">£5 OFF on orders over £20</div>
                        <div class="specialOffersText">
                            Cannot be used with any other offer. Valid for collection or delivery. £5 off does not apply to set meals.
                            <!--The amount will be automatically deducted when you checkout.-->
                        </div>
                    </td>
                </tr>
                <tr><td colspan="2">&nbsp;</td></tr>
            </table>
        </div>
    </div>
</asp:Content>
