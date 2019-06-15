using System;
using System.Collections.Generic;
using System.Text;

namespace customerdata.lib
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone1 { get; set; }
    }
}
