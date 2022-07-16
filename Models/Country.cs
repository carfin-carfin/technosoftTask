using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutorial_api2.Models
{
    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
        public string callingCode { get; set; }
        public Country(string id, string name,string callingCode)
        {
            this.id = id;
            this.name = name;
            this.callingCode = callingCode;
        }
        public Country()
        {
        }
    }
}