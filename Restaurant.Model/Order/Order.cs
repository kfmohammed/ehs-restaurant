using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.DataModel;

namespace Restaurant.Model
{
    public class Order
    {
        public int? OrderID { get; set; }
        public List<OrderMenu> OrderMenu { get; set; }
        public int CompletionModeId { get; set; }
        public int PaymentMethodId { get; set; }
        public Nullable<int> DiscountCodeId { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public decimal DiscountedFullPrice { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Nullable<DateTime> EstimatedCompletionDateTime { get; set; }
        private decimal _totalPrice = 0;
        public decimal TotalPrice
        {
            get
            {
                this._totalPrice = 0;
                foreach (var item in this.OrderMenu)
                {
                    this._totalPrice += (decimal)item.MenuItem.Price;
                }
                return this._totalPrice;
            }
            set { _totalPrice = value; }
        }
        public string FormattedTotalPrice
        {
            get
            {
                this._totalPrice = 0;
                foreach (var item in this.OrderMenu)
                {
                    this._totalPrice += (decimal)item.MenuItem.Price;
                }
                return String.Format("{0:0.00}", this._totalPrice);
            }
            set { FormattedTotalPrice = value; }
        }

        public int AddOrder(Order order)
        {
            var orderItem = MapModeltoData(order);
            return new Repository.Masters.OrderItem().AddOrder(orderItem);
        }

        #region Map POCO objects

        // Maps object from data to model
        private static Order MapDatatoModel(DataModel.Order orderItem)
        {
            if (orderItem != null)
            {
                return new Order
                           {
                               OrderID = orderItem.OrderId,
                               PaymentMethodId = orderItem.PaymentMethodId,
                               CompletionModeId = orderItem.CompletionModeId,
                               DiscountCodeId = orderItem.DiscountCodeId,
                               DiscountAmount = orderItem.DiscountAmount,
                               TotalPrice = orderItem.TotalFullPrice,
                               DiscountedFullPrice = orderItem.DiscountedFullPrice,
                               OrderDateTime = orderItem.OrderDateTime,
                               EstimatedCompletionDateTime = orderItem.EstimatedCompletionDateTime
                           };
            }
            return null;
        }

        // Maps object from  to data repository
        private static Restaurant.DataModel.Order MapModeltoData(Order orderItem)
        {
            return new Restaurant.DataModel.Order
            {
                PaymentMethodId = orderItem.PaymentMethodId,
                CompletionModeId = orderItem.CompletionModeId,
                DiscountCodeId = orderItem.DiscountCodeId,
                DiscountAmount = orderItem.DiscountAmount,
                TotalFullPrice = orderItem.TotalPrice,
                DiscountedFullPrice = orderItem.DiscountedFullPrice,
                OrderDateTime = orderItem.OrderDateTime,
                EstimatedCompletionDateTime = orderItem.EstimatedCompletionDateTime
            };
        }

        #endregion
    }
}