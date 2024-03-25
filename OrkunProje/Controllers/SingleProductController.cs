using BL.Session;
using DAL.Context;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Controllers
{
    public class SingleProductController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("SingleProduct", "SingleProduct");
        }

        public ActionResult SingleProduct()
        {
            return View();
        }
    }
}