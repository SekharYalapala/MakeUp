using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakeupOnline.Models;

namespace MakeupOnline.Controllers
{
    public class ShoppingCartController : Controller
    {
        makeuponlineEntities makeuponlineDb = new makeuponlineEntities();
        private string strCart = "Cart";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> iscart = new List<Cart>
                {
                    new Cart(makeuponlineDb.Products.Find(id),1)
                };
                Session[strCart] = iscart;
            }
            else
            {
                List<Cart> iscart = (List<Cart>)Session[strCart];
                int isCheck = isExistingCheck(id);
                if (isCheck == -1)
                    iscart.Add(new Cart(makeuponlineDb.Products.Find(id), 1));
                else
                    iscart[isCheck].Quantity++;

                Session[strCart] = iscart;

            }
            return View("Index");
        }
        private int isExistingCheck(int? id)
        {
            List<Cart> iscart = (List<Cart>)Session[strCart];
            for (int check = 0; check < iscart.Count; check++)
            {
                if (iscart[check].Product.ProductId == id)
                    return check;
            }
            return -1;
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int isCheck = isExistingCheck(id);
            List<Cart> iscart = (List<Cart>)Session[strCart];
            iscart.RemoveAt(isCheck);
            return View("Index");
        }
        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Cart> iscart = (List<Cart>)Session[strCart];
            for (int i = 0; i < iscart.Count; i++)
            {
                iscart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = iscart;
            return View("Index");
        }

    }

 
}