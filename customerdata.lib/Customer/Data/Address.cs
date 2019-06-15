using System;
using System.Collections.Generic;
using System.Text;

namespace customerdata.lib
{
    public class Address : IAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }

    }
}
