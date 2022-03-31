//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using MakeupOnline.Models;

//namespace MakeupOnline.Controllers
//{
//    public class NewsController : Controller
//    {
//        makeuponlineEntities makeuponlineDb = new makeuponlineEntities();
//        // GET: News
//        public ActionResult NewsIndex()
//        {
//            return View();
//        }
//        public PartialViewResult NewsListPartial()
//        {
//            var newsList = makeuponlineDb.News.OrderByDescending(x => x.NewsId).ToList();
//            return PartialView(newsList);

//        }
//    }
//}