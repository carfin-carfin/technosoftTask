using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutorial_api2.Models;

namespace tutorial_api2.Controllers
{
    public class Api2Controller : Controller
    {
        static List<Country> database = new List<Country>();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("countries")]
        public ActionResult Countries()
        {
            countryResponse countryResponses = new countryResponse();

            if (database.Count == 0)
            {
                countryResponses.HttpStatus = "204"; //no content
                return Json(countryResponses, JsonRequestBehavior.AllowGet);
            }
            else
            {
                countryResponses.HttpStatus = "200"; // success
                for (int i = 0; i < database.Count; i++)
                {
                    countryResponses.Body.Add(database[i]);
                }

                return Json(countryResponses, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Route("Country")]
        public ActionResult Country(int country_id)
        {
            countryResponse countryResponses = new countryResponse();

            countryResponses.HttpStatus = "200";

            int index = -1;
            for (int i = 0; i < database.Count; i++)
            {
                 if (database[i].id == country_id.ToString())
                 {
                     index = i;
                 }
            }

            if (index != -1)    // found data with id == country_id
            {
                countryResponses.Body.Add(database[index]);
            }
            else //not found data with id == country_id
            {
                countryResponses.HttpStatus = "204";

                Country baru = new Country("-1", "NULL", "NULL");
                countryResponses.Body.Add(baru);
            }

            return Json(countryResponses, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("countries")]
        public ActionResult Countries(string name, string callingCode)
        {
            int size = database.Count;
            string ids;
            if (size == 0)
            {
                ids = size.ToString();
            }
            else
            {
                int id = Int32.Parse(database[size - 1].id) + 1;
                ids = id.ToString();
            }
            
            Country baru = new Country(ids, name, callingCode);
            
            CountryAdd countryResponses = new CountryAdd();

            database.Add(baru);

            countryResponses.HttpStatus = "200";
            countryResponses.id = ids;

            return Json(countryResponses, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        [Route("countries")]
        public ActionResult Countries(int country_id)
        {
            List<Country> temp = new List<Country>();
            bool found = false;
            for (int i = 0; i < database.Count; i++)
            {
                if (database[i].id != country_id.ToString())
                {
                    temp.Add(database[i]);
                }
                else 
                {
                    found = true;
                }
            }

            database.Clear();
            database = temp;

            CountryAdd countryResponses = new CountryAdd();

            if (found)
            {
                countryResponses.HttpStatus = "200"; // Delete successfully
                countryResponses.id = country_id.ToString();
            }
            else
            {
                countryResponses.HttpStatus = "204"; // Not Found, Fail to delete
                countryResponses.id = "-1";
            }

            return Json(countryResponses, JsonRequestBehavior.AllowGet);
        }

        [HttpPatch]
        [Route("countries")]
        public ActionResult Countries(int country_id, string name, string callingCode)
        {
            bool found = false;
            for (int i = 0; i < database.Count; i++)
            {
                if (database[i].id == country_id.ToString())
                {
                    found = true;
                    database[i].name = name;
                    database[i].callingCode = callingCode;
                }
            }

            CountryAdd countryResponses = new CountryAdd();

            if (found)
            {
                countryResponses.HttpStatus = "200"; // patch successfully
                countryResponses.id = country_id.ToString();
            }
            else
            {
                countryResponses.HttpStatus = "204"; // Not Found, Fail to patch
                countryResponses.id = "-1";
            }

            return Json(countryResponses, JsonRequestBehavior.AllowGet);
        }
    }
}