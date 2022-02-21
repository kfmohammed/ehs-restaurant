using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Model
{
    public class OrderMenu
    {
        public int? OrderMenuId { get; set; }
        public int MenuId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        private Menu _menuItem { get; set; }
        public Menu MenuItem 
        {
            get
            {
                this._menuItem = new Menu();
                var menu = new Menu();
                this._menuItem = menu.GetMenu(this.MenuId);
                this._menuItem.Price = this._menuItem.Price * Quantity;
                return this._menuItem;
            }
            set { _menuItem = value; }
        }
        
        public int AddOrderMenu(OrderMenu orderMenu)
        {
            var orderMenuItem = MapModeltoData(orderMenu);
            return new Repository.Masters.OrderMenuItem().AddOrderMenu(orderMenuItem);
        }

        #region Map POCO objects

        // Maps object from data to model
        private static OrderMenu MapDatatoModel(DataModel.OrderMenu orderMenuItem)
        {
            if (orderMenuItem != null)
            {
                return new OrderMenu
                           {
                               OrderMenuId = orderMenuItem.OrderMenuId,
                               MenuId = orderMenuItem.MenuId,
                               OrderId = orderMenuItem.OrderId,
                               Quantity = orderMenuItem.Quantity
                           };
            }
            return null;
        }

        // Maps object from  to data repository
        private static DataModel.OrderMenu MapModeltoData(OrderMenu orderMenuItem)
        {
            return new DataModel.OrderMenu
            {
                MenuId = orderMenuItem.MenuId,
                OrderId = orderMenuItem.OrderId,
                Quantity = orderMenuItem.Quantity
            };
        }

        #endregion
    }
}