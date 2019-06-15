using System;

namespace customerdata.lib
{
    public class Customer : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public IAddress Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }

        public static explicit operator CustomerDto(Customer model)
        {
            return new CustomerDto
            {
                address = model?.Address?.Street,
                city = model?.Address?.City,
                company_name = model?.CompanyName,
                email = model?.Email,
                first_name = model?.FirstName,
                last_name = model?.LastName,
                phone1 = model?.Phone1,
                phone2 = model?.Phone2,
                post = model?.Address?.PostCode,
                state = model?.Address?.State,
                web = model?.Web
            };
        }
    }
}
