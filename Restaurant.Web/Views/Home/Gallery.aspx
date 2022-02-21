<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<Restaurant.Web.Models.GalleryModel>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="/Scripts/jquery.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.bxgallery.1.1.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#site_content ul').bxGallery({
                maxwidth: 650,
                maxheight: 400,
                thumbwidth: 60,
                thumbcrop: true,
                croppercent: .30,
                thumbplacement: 'right',
                thumbcontainer: 220,
                opacity: .7,
                load_text: 'Please wait while the gallery loads...',
                load_image: '',
                wrapperclass: ''
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="site_content">
        <div>
            <ul>
                <li><img src="/Images/gallery/Namaste.gif" title="Namaste" /></li>
                <li><img src="/Images/gallery/CurryOn.jpg" title="Keep Calm and Curry On" /></li>
                <li><img src="/Images/gallery/ChickenCurry.jpg" title="Chicken Curry" /></li>
                <li><img src="/Images/gallery/SheeshKebab.jpg" title="Sheesh Kebab" /></li>
                <li><img src="/Images/gallery/ChickenTikka.jpg" title="Chicken Tikka Starter" /></li>
                <li><img src="/Images/gallery/NaanBread.jpg" title="Naan Bread" /></li>
                <li><img src="/Images/gallery/OnionPakora.jpg" title="Onion Pakora" /></li>
                <li><img src="/Images/gallery/ChickenJalfrezi.jpg" title="Chicken Jalfrezi" /></li>
                <li><img src="/Images/gallery/Samosa.jpg" title="Chicken Samosa" /></li>
                <li><img src="/Images/gallery/Chips.jpg" title="Chips" /></li>
                <li><img src="/Images/gallery/SheekhWrap.jpg" title="Sheekh Kebab Wrap" /></li>
                <li><img src="/Images/gallery/SheeshKebabStarter.jpg" title="Sheesh Kebab Starter" /></li>
                <li><img src="/Images/gallery/TandooriChicken.jpg" title="Tandoori Chicken" /></li>
                <li><img src="/Images/gallery/OurHeadChef.jpg" title="Our Head Chef" /></li>
                <li><img src="/Images/gallery/Outside1.jpg" title="Our Takeaway View" /></li>
                <li><img src="/Images/gallery/Outside2.jpg" title="Our Takeaway View 2" /></li>
                <li><img src="/Images/gallery/WaitingArea1.jpg" title="Our Waiting Area" /></li>
                <li><img src="/Images/gallery/WaitingArea2.jpg" title="Our Takeaway Reception" /></li>
            </ul>
        </div>
        <div><br /></div>
    </div>
</asp:Content>
