﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeupOnline.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult ContactUsIndex()
        {
            return View();
        }
    }
}