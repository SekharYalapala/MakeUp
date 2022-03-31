using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MakeupOnline.Models;

namespace MakeupOnline.Controllers
{
    public class ProductsController : Controller
    {
        makeuponlineEntities db = new makeuponlineEntities();
        // GET: Products
        public ActionResult ProductsIndex()
        {
            return View();
        }
        public PartialViewResult productListPartial(int? category)
        {



            if (category != null)
            {
                //ViewBag.category = category;
                var productList=db.Products.OrderByDescending(x => x.ProductId).Where(x => x.CategoryId == category).ToList();
                return PartialView(productList);
            }

            else
            {
                var productList = db.Products.OrderByDescending(x => x.ProductId).ToList();
                return PartialView(productList);
            }
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult AddImage()
        {
            Product product = new Product();

            makeuponlineEntities db = new makeuponlineEntities();

            return View(product);
        }



        [HttpPost]
        public ActionResult AddImage(Product model, HttpPostedFileBase image1)
        {
            using (makeuponlineEntities db = new makeuponlineEntities())
            {


                if (image1 != null)
                {
                    //convert img into binaryformat
                    model.Image = new byte[image1.ContentLength];
                    //inputstream- convert actual data to binary
                    image1.InputStream.Read(model.Image, 0, image1.ContentLength);//copy img to product class

                }
                db.Products.Add(model);
                db.SaveChanges();
            }
            ModelState.Clear();


            return View(model);
        }
    }

}