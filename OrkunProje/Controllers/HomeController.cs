﻿using BL.Session;
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
    public class HomeController : Repository<Olta>
    {


        public ActionResult Index()
        {

            ViewBag.ToplamFiyat = Session["ToplamFiyat"];
            ViewBag.ToplamAdet = Session["ToplamAdet"];
            var asdasd = GetList();
           // ViewBag.ToplamFiyat = TempData["ToplamFiyat"];
            //ViewBag.ToplamAdet = TempData["ToplamAdet"];
            return View(asdasd);
       
        }

        public ActionResult Index2()
        {
            ViewBag.ToplamFiyat = TempData["ToplamFiyat"];
            ViewBag.ToplamAdet = TempData["ToplamAdet"];

            return View();
        }
    }
}