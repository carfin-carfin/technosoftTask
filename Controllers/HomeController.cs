using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutorial_api2.Models;

namespace tutorial_api2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        //[HttpGet]
        [Route("tambah")]
        public ActionResult Tambah(string a, string b)
        {
            int num_a = int.Parse(a);
            int num_b = int.Parse(b);

            int total = num_a + num_b;

            clsResult tambahResponse = new clsResult();

            tambahResponse.HttpStatus = "200";
            tambahResponse.hasil = total.ToString();

            return Json(tambahResponse);
        }
    }
}
