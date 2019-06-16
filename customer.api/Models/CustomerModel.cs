using customerdata.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer.api.Models
{
    public class CustomerModel : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public IAddress Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public static IEnumerable<Models.CustomerModel> Parse(IEnumerable<global::customerdata.lib.Customer> models)
        {
            return models.Select(x => (Models.CustomerModel)x);
        }

        public static explicit operator Models.CustomerModel(global::customerdata.lib.Customer model)
        {
            return new CustomerModel
            {
                Address = new Address
                {
                    City = model?.Address?.City,
                    PostCode = model?.Address?.PostCode,
                    State = model?.Address?.State,
                    Street = model?.Address?.Street
                },
                CompanyName = model?.CompanyName,           
                Email = model?.Email,
                FirstName = model?.FirstName,
                LastName = model?.LastName,
                Phone1 = model?.Phone1,
                Phone2 = model?.Phone2,
                Web = model?.Web
            };
        }
    }
}
