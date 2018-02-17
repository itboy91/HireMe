using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireMe.UI.DomainModel
{
    public class EmailDTO
    {
        public string AddressTo { get; set; }
        public string Body { get; set; }
        public string Subject { set; get; }
    }
}