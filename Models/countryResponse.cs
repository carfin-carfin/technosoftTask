using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutorial_api2.Models
{
    public class countryResponse
    {
        public string HttpStatus { get; set; }
        public List<Country> Body { get; set; }
        public countryResponse()
        {
            this.Body = new List<Country>();
        }
    }
}