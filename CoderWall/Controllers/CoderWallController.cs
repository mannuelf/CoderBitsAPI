using CoderWall.Models;
using coderwall_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoderWall.Controllers
{
    public class CoderWallController : Controller
    {
        //
        // GET: /CoderWall/

        public ActionResult Index()
        {
            var coderbitsEngine = new CoderbitsEngine("yegengovender");

            var info = coderbitsEngine.CoderbitsInfo();
            return View(info);
        }

        public ActionResult User(string userName)
        {
            var coderbitsEngine = new CoderbitsEngine(userName);

            var info = coderbitsEngine.CoderbitsInfo();
            return View("Index",info);
        }

    }


}
