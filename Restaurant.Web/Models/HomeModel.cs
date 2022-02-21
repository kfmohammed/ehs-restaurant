using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Model;

namespace Restaurant.Web.Models
{
    public class HomeModel {}
    public class ContactModel {}
    public class GalleryModel {}
    public class SpecialOffersModel { }

    public class MenuModel
    {
        public List<Category> CategoryItems { get; set; }
        public List<Menu> MenuItems { get; set; }
    }
}