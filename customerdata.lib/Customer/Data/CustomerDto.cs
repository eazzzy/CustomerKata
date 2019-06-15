using System;
using System.Collections.Generic;
using System.Text;

namespace customerdata.lib
{
    public class CustomerDto
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string post { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string email { get; set; }
        public string web { get; set; }

        public static explicit operator Customer(CustomerDto model)
        {
            return new Customer
            {
                Address = new Address
                {
                    City = model?.city,
                    PostCode = model?.post,
                    State = model?.state,
                    Street = model?.address
                },
                CompanyName = model?.company_name,
                Email = model?.email,
                FirstName = model?.first_name,
                LastName = model?.last_name,
                Phone1 = model?.phone1,
                Phone2 = model?.phone2,
                Web = model?.web
            };
        }
    }
}
