using System;
using System.Collections.Generic;
using System.Text;

namespace customerdata.lib
{
    public interface IAddress
    {
        string Street { get; set; }
        string City { get; set; }
        string State { get; set; }
        string PostCode { get; set; }

    }
}
