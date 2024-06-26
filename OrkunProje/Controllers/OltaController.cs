﻿using DAL.Entities;
using DAL.Repository;
using OrkunProje.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrkunProje.Controllers
{
    [Oturum]
    public class OltaController : Repository<Olta>
    {

        public ActionResult Index()
        {
            //ViewBag.ToplamFiyat = TempData["ToplamFiyat"];
            //ViewBag.ToplamAdet = TempData["ToplamAdet"];
            ViewBag.ToplamFiyat = Session["ToplamFiyat"];
            ViewBag.ToplamAdet = Session["ToplamAdet"];

            return View(GetList());
        }

        public ActionResult Detay(int ilanNo)
        {
            Olta Olta = GetById(k => k.İlanNo == ilanNo);
            return View(Olta);
        }
    }
}