using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Repository.Masters;

namespace Restaurant.Model
{
    [Serializable]
    public class Menu
    {
        #region Properties
        
        public int ID { get; set; }
        public string MenuName{ get; set; }
        public string ShortDescription{ get; set; }
        public System.Nullable<decimal> Price{ get; set; }
        public System.Nullable<int> CategoryId{ get; set; }
        public string CategoryName {get;set;}

        public string FormattedPrice
        {
            get
            {
                return String.Format("{0:0.00}", this.Price);
            }
            set { FormattedPrice = value; }
        }

        #endregion

        #region Map POCO Objects

        // Maps object from data to model
        private static Menu MapDatatoModel(Restaurant.DataModel.Menu menuItem)
        {
            if (menuItem != null)
            {
                return new Menu
                {
                    ID = menuItem.ID,
                    MenuName = menuItem.MenuName,
                    CategoryId = menuItem.CategoryId,
                    Price = menuItem.Price,
                    ShortDescription  = menuItem.ShortDescription
                };
            }

            return null;
        }

        // Maps object from  to data repository
        private static Restaurant.DataModel.Menu MapModeltoData(Menu menuItem)
        {
            
            int categoryid = new CategoryItem().ValidateCategory(menuItem.CategoryName);
            menuItem.CategoryId = categoryid;
            
            return new Restaurant.DataModel.Menu
            {
                MenuName = menuItem.MenuName,
                CategoryId = menuItem.CategoryId,
                Price = menuItem.Price,
                ShortDescription  = menuItem.ShortDescription
            };
        }

        #endregion
		
        #region Methods
        public List<Menu> GetMenuList()
        {
            var returnList = new List<Menu>();
            var menulist = new Repository.Masters.MenuItem().GetMenu();

            if (menulist != null)
            {
                returnList.AddRange(menulist.Select(MapDatatoModel));
                return returnList;
            }

            return null;
        }

        public Menu GetMenu(int menuID)
        {
            return MapDatatoModel(new MenuItem().GetMenu(menuID));
        }

        public bool AddMenu(Menu menu)
        {
            var menuItem = MapModeltoData(menu);
            return menuItem != null && new Repository.Masters.MenuItem().AddMenu(menuItem);
        }

        public bool UpdateMenu(Menu menu,int ID)
        {
            var menuItem = MapModeltoData(menu);
            return menuItem != null && new Repository.Masters.MenuItem().AddMenu(menuItem);
        }

        #endregion

        #region PrivateMethods
        //private int ValidateCategory(string CategoryName)
        //{
            
        //}

        //private string GetCategoryName(int CategoryID)
        //{

        //}
        #endregion

    }
}
