using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Restaurant.Web.Models;
//using Restaurant.Web.WebAPI;
using Restaurant.Model;

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeModel());
        }

        public ActionResult Contact()
        {
            return View(new ContactModel());
        }

        public ActionResult SpecialOffers()
        {
            return View(new SpecialOffersModel());
        }

        public ActionResult Gallery()
        {
            return View(new GalleryModel());
        }

        // TODO: Refactor to a separate new controller to use ApiController (WebAPI)...
        [System.Web.Mvc.HttpGet]
        public ActionResult Menu()
        {
            var category = new Category();
            var menu = new Menu();
            var returnMenuModel = new MenuModel
                                      {
                                          CategoryItems = category.GetCategoryList(),
                                          MenuItems = menu.GetMenuList()
                                      };

            return View(returnMenuModel);
        }

        public ActionResult GetYourOrder(string addOrDelete, int menuId, string collOrDeli)
        {
            Order yourOrder = null;
            JsonResult result;

            if (HttpContext.Session["YourOrder"] == null)
            {
                yourOrder = new Order
                {
                    PaymentMethodId = (int)PaymentMethod.Cash,
                    CompletionModeId = (int)CompletionMode.Collection,
                    DiscountCodeId = null,
                    DiscountAmount = null,
                    TotalPrice = 0,
                    DiscountedFullPrice = 0,
                    OrderDateTime = DateTime.Now,
                    EstimatedCompletionDateTime = null,
                    OrderMenu = new List<OrderMenu>()
                };
            }
            else if (addOrDelete == "Add")
            {
                var orderMenu = new OrderMenu();
                var menu = new Menu();

                yourOrder = (Order)(HttpContext.Session["YourOrder"]);

                orderMenu.MenuId = menuId;

                if (yourOrder.OrderMenu.Exists(j => j.MenuId == menuId))
                {
                    var i = yourOrder.OrderMenu.FindIndex(j => j.MenuId == menuId);
                    yourOrder.OrderMenu[i].Quantity += 1;
                }
                else
                {
                    orderMenu.MenuId = menuId;
                    orderMenu.Quantity = 1;
                    orderMenu.MenuItem = menu.GetMenu(menuId);
                    yourOrder.OrderMenu.Add(orderMenu);
                }
            }
            else if (addOrDelete == "Remove")
            {
                yourOrder = (Order)(HttpContext.Session["YourOrder"]);
                var toDelete = yourOrder.OrderMenu.FindLastIndex(j => j.MenuId == menuId);

                if (yourOrder.OrderMenu[toDelete].Quantity > 1)
                {
                    yourOrder.OrderMenu[toDelete].Quantity -= 1;
                }
                else
                {
                    yourOrder.OrderMenu.RemoveAt(toDelete);
                }
            }
            else
            {
                yourOrder = (Order)HttpContext.Session["YourOrder"];
            }

            if (!String.IsNullOrEmpty(collOrDeli))
            {
                switch (collOrDeli)
                {
                    case "Collection": yourOrder.CompletionModeId = (int)CompletionMode.Collection;
                        break;
                    case "Delivery": yourOrder.CompletionModeId = (int)CompletionMode.Delivery;
                        break;
                }
            }

            HttpContext.Session["YourOrder"] = yourOrder;
            result = new JsonResult { Data = yourOrder };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Menu(FormCollection col)
        {
            return RedirectToAction("Login", "Account");
        }

        //public ActionResult SaveOrder()
        //{
        //    JsonResult result;
        //    if (HttpContext.Session["YourOrder"] == null)
        //    {
        //        result = new JsonResult { Data = null };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }

        //    try
        //    {
        //        var order= new Order();
        //        var yourOrder = (Order) HttpContext.Session["YourOrder"];
        //        var yourOrderId = order.AddOrder(yourOrder);
        //        yourOrder.OrderID = yourOrderId;

        //        foreach (var item in yourOrder.OrderMenu)
        //        {
        //            var yourOrderMenu = new OrderMenu();
        //            item.OrderId = (int)yourOrder.OrderID;
        //            yourOrderMenu.AddOrderMenu(item);
        //        }

        //        HttpContext.Session.Clear();
        //        HttpContext.Session.Abandon();

        //        using (MailMessage message = new MailMessage())
        //        {
        //            message.From = new MailAddress("mkfaizuddin@gmail.com");
        //            message.To.Add(new MailAddress("khaja.mohammed@willis.com"));
        //            message.Subject = "Subject goes here";
        //            message.Body = "Email matter goes here";
        //            message.IsBodyHtml = false;

        //            using (SmtpClient smtpclient = new SmtpClient())
        //            {
        //                smtpclient.Host = "smtp.gmail.com";
        //                smtpclient.Credentials = new NetworkCredential("mkfaizuddin@gmail.com", "acclaimed");
        //                smtpclient.Send(message);
        //            }
        //        }

        //        result = new JsonResult { Data = yourOrderId };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception e)
        //    {
        //        HttpContext.Session.Clear();
        //        HttpContext.Session.Abandon();
        //        result = new JsonResult { Data = null };
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
