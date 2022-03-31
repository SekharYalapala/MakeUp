using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeupOnline.Models;


namespace MakeupOnline.Controllers
{
    public class CategoryController : Controller
    {
        makeuponlineEntities db = new makeuponlineEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CategoryPartial()
        {
            var categoryList = db.Categories.OrderBy(x => x.Name).ToList();
            return PartialView(categoryList);
        }
    }
}