using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutorial_api2.Models;

namespace tutorial_api2.Controllers
{
    public class ApiController : Controller
    {
        // GET: api
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("countries")]
        public ActionResult Countries()
        {

            countryResponse countryResponses = new countryResponse();

            countryResponses.HttpStatus = "200";
        
            return Json(countryResponses);
        }
    }
}