﻿using AteshgahPracticalProject.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AteshgahPracticalProject.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}