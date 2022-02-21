using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Repository.Masters
{
    public class MenuItem
    {
        public  List<Menu> GetMenu()
        {   
            using (var db = new ResturantDataContext())
            {
                var menu = db.Menus.ToList();
                return menu.ToList();
            }
        }

        public Menu GetMenu(int ID)
        {
            using (var db = new ResturantDataContext())
            {
                return db.Menus.FirstOrDefault(p => p.ID == ID);
            }
        }

        public bool AddMenu(Menu menu)
        {
            using (var context = new ResturantDataContext())
            {
                context.Menus.InsertOnSubmit(menu);
                context.SubmitChanges();
                return true;
            }
        }

        public bool UpdateMenu(Menu menu, int menuID)
        {
            using (var context = new ResturantDataContext())
            {
                var menuItem = context.Menus.SingleOrDefault(a => a.ID == Convert.ToInt32(menuID));
                if (menuItem != null && menuItem.ID != 0)
                {
                    menuItem.MenuName = menu.MenuName;
                    menuItem.Price = menu.Price;
                    menuItem.CategoryId = menu.CategoryId;
                    menuItem.ShortDescription = menu.ShortDescription;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}