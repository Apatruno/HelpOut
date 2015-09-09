using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpOut.Models
{
    public class EventDTO
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public string OrganizationName { get; set; }
        public string getAddress()
        {
            string fullAddress = Address + ", " + City + ", " + State + ", " + ZipCode;
            return fullAddress;
        }
        
    }
}