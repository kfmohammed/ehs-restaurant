<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Restaurant.Web.Models.HomeModel>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.divroller.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="site_content">
        <div id="sidebar_container">
            <div id="divroller_container">
                <div>
                    <div class="sidebar"><img src="/Images/logos/KeepCalm.jpg" alt="MassalaMotto" width="225" /></div>
                </div>
                <div>
                    <div class="sidebar_main">"...Very good value for money, we collected in the shop and it was very tidy and kitchen could be seen. Lots of food and great quality..."</div>
                </div>
                <div>
                    <div class="sidebar_main">"...Used them couple of times and they always came up to my expectations. Delivery time is good and food is great. Highly recommended..."</div>
                </div>
                <div>
                    <div class="sidebar_main">"...Fantastic first order. Loved it. I'm a curry guru and thoroughly enjoyed my meal..."</div>
                </div>
                <div>
                    <div class="sidebar_main">"...Truly delicious. Great quality lamb and fish with tons of spice and flavour - will definitely order from here again..."</div>
                </div>
            </div>
        </div>
        <div class="content">
            <div>
                <h1>Welcome to Massala</h1>
            </div>
            <p>
                Newest Indian Takeaway in Ipswich - Massala. Why not give us a try?
            </p>
            <p>
                <b>Keep Calm & Curry On</b> - that's our motto! Why not treat yourself to one of the nation's
                favourite dishes when you've had a hard day at work, or just have been playing hard!
            </p>
            <p>
                We prepare your dishes freshly in a uniquely designed open planned kitchen by our
                well experienced chef and his team of Indian cuisine experts. Order from the classic
                Chicken Tikka Massala, or for a little extra heat try the favourite hot dishes like
                Madras and Vindaloo, or why not give one of Massala specials a try? Whatever your
                taste, we can prepare your favourite dish to your liking.
            </p>
            <p>
                To order just give us a call or pop into the shop. We're easy to find on 117 Bramford
                Road, opposite Farmfoods and Domino's Pizza.
            </p>
        </div>
    </div>
    <script type="text/javascript">
        $("#divroller_container").divroller({ pause: 3500, visible: 1 });
    </script>
</asp:Content>
