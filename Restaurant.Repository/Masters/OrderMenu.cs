using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Repository.Masters
{
    public class OrderMenuItem
    {
        public int AddOrderMenu(DataModel.OrderMenu orderMenu)
        {
            using (var context = new ResturantDataContext())
            {
                context.OrderMenus.InsertOnSubmit(orderMenu);
                context.SubmitChanges();
                return orderMenu.OrderId;
            }
            return 0;
        }
    }
}
