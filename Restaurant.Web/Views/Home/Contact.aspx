<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Restaurant.Web.Models.ContactModel>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="site_content">
        <div id="sidebar_container">
            <div class="sidebar" style="width: 420px;">
                <div>
                    <iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=massala+ipswich&amp;aq=&amp;sll=37.0625,-95.677068&amp;sspn=46.812293,107.138672&amp;ie=UTF8&amp;hq=massala&amp;hnear=Ipswich,+Suffolk,+United+Kingdom&amp;ll=52.062874,1.138158&amp;spn=0.013504,0.022136&amp;t=m&amp;output=embed"></iframe>
                    <br />
                    <small><a target="_blank" href="http://goo.gl/maps/luZ7P" style="color:#5b5b5b;float:left;padding:10px;">View Larger Map</a></small>
                </div>
                <p></p><p></p>
                <div style="float:right;">
                    <a href="http://www.just-eat.co.uk/massala" target="_blank"><img src="/Images/logos/JustEatLogo.jpg" alt="facebook" height="50px" /></a>

                    <a href="http://www.facebook.com/massalaipswich" target="_blank"><img src="/Images/logos/flogo.png" alt="facebook" height="50px" /></a>
                </div>
            </div>
        </div>
        <div class="content" style="width: 470px;">
            <div>
                <h2>Address</h2>
            </div>
            <div>
                <table style="width:100%;margin:0;padding:0">
                    <tr>
                        <td style="width:200px;">
                            <div>
                                <p>You can easily find us at:</p>
                            </div>
                        </td>
                        <td style="padding-top:15px;">
                            <div>117, Bramford Road,</div>
                            <div>Ipswich,</div>
                            <div>IP1 2LW</div>                                
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                        <td colspan="2">
                            <p>It's just opposite Farmfoods and Domino's Pizza.</p>
                        </td>
                    </tr>
                </table>
                        
            </div>
            <div>
                <h2>Opening Hours</h2>
            </div>
            <div>
                <div style="padding:5px;padding-bottom:15px;font-size:11pt;">
                    We are open on bank holidays too.
                </div>
                <table id="table">
                    <tr>
                        <td style="width: 175px;">Monday</td>
                        <td style="width: 175px;">5:00 pm - 11:00 pm</td>
                    </tr>
                    <tr>
                        <td>Tuesday</td>
                        <td>5:00 pm - 11:00 pm</td>
                    </tr>
                    <tr>
                        <td>Wednesday</td>
                        <td>5:00 pm - 11:00 pm</td>
                    </tr>
                    <tr>
                        <td>Thursday</td>
                        <td>5:00 pm - 11:00 pm</td>
                    </tr>
                    <tr>
                        <td>Friday</td>
                        <td>5:00 pm - 11:00 pm</td>
                    </tr>
                    <tr>
                        <td>Saturday</td>
                        <td>5:00 pm - 11:00 pm</td>
                    </tr>
                    <tr>
                        <td>Sunday</td>
                        <td>5:00 pm - 11:00 pm</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
