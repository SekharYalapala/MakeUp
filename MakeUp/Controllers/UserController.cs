using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MakeupOnline.Models;

namespace WatchOnlineShopping.Controllers
{
    public class UserController : Controller
    {makeuponlineEntities db = new makeuponlineEntities();
        private string strCart = "Cart";
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User_table user)
        {
          makeuponlineEntities db= new makeuponlineEntities();
            db.User_table.Add(user);
           
           db.SaveChanges();
            string message = string.Empty;
            switch (user.UserId)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different user name.";
                    break;

                default:
                    message = "Registration successful.";
                    break;
            }
            ViewBag.Message = message;

            return View(user);
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User_table user)
        {
            makeuponlineEntities db = new makeuponlineEntities();
            int? userId = db.Validate_Users(user.UserName, user.Password).FirstOrDefault();

            string message = string.Empty;
            switch (userId.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    message = "Username has not registered.";
                    break;

                default:
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("CheckOut");
            }

            ViewBag.Message = message;
            return View(user);
        }
        public ActionResult CheckOut()
        {

            return View("CheckOut");
        }

        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Cart> iscart = (List<Cart>)Session[strCart];
            //save the order into order table
            Order order = new Order()
            {
                CustomerName = frc["cusName"],
                CustomerPhone = frc["cusPhone"],

                CustomerEmail = frc["cusEmail"],

                CustomerAddress = frc["cusAddress"],
                OrderDate = DateTime.Now,
                PaymentType = "Cash",
                Status = "Processing"

            };
            db.Orders.Add(order);
            db.SaveChanges();
            //save the order detail into orderdetail table
            foreach (Cart cart in iscart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderID = order.OrderId,
                    ProductID = cart.Product.ProductId,
                    Quantity = cart.Quantity,
                    Price = cart.Product.Price
                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            //remove shopping cart
            Session.Remove(strCart);
            return View("OrderSuccess");
        }
    }
}



//namespace MakeupOnline.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;

//    public partial class User_table
//    {
//        public int UserId { get; set; }
//        [Required]
//        public string UserName { get; set; }
//        [Required]
//[DataType(DataType.Password)]
//        public string Password { get; set; }
//        [Required]
//        [Compare("Password", ErrorMessage = "Password is does not match")]
//        public string ConfirmPassword { get; set; }
//        public System.DateTime CreatedDate { get; set; }
//        public Nullable<System.DateTime> LastLoginDate { get; set; }
//    }
//}



