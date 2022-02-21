using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Repository.Masters
{
    public class OrderItem
    {
        public int AddOrder(DataModel.Order order)
        {
            using (var context = new ResturantDataContext())
            {
                context.Orders.InsertOnSubmit(order);
                context.SubmitChanges();
                return order.OrderId;
            }
            return 0;
        }
    }
}
