using customerdata.lib;
using customerdata.lib.Extensions;
using GenFu;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace customer.tests
{
    public class CustomerUnitTests
    {
        private readonly Mock<ICustomerReadDataStore> _customerReadDataStore;

        public CustomerUnitTests()
        {
            _customerReadDataStore = new Mock<ICustomerReadDataStore>();
            _customerReadDataStore.SetupAllProperties();
        }

        [Fact]
        public void DataStore_Returns_ArgumentNullWhenFileNameNotPassed()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var dataStore = new DataStore(string.Empty);
            });
        }

        [Fact]
        public async Task DataStore_Returns_FileNotFoundWhenFileDoesNotExist()
        {
            var file = "datafile.csv";
            await Assert.ThrowsAsync<FileNotFoundException>(async () =>
            {
                var dataStore = new DataStore(file);

                await dataStore.Select();
            });
        }

        [Fact]
        public void CustomerDto_Maps_ToCustomer()
        {
            var dto = new CustomerDto
            {
                first_name = "name"
            };

            var cust = (Customer)dto;

            Assert.True(!string.IsNullOrEmpty(cust.FirstName));
        }

        [Fact]
        public void Customer_Maps_ToCustomerDto()
        {
            var cust = new Customer
            {
                FirstName = "name"
            };

            var dto = (CustomerDto)cust;

            Assert.True(!string.IsNullOrEmpty(dto.first_name));
        }

        [Fact]
        public void StringExtension_RemovesSpecialCharacters()
        {
            var teststring = "\"abc\"";

            Assert.True(!teststring.RemoveSpecialCharacters().Contains('"'));
        }

        [Fact]
        public async Task DataStore_GetAll_ReturnsData()
        {
            _customerReadDataStore.Setup(x => x.SelectAll()).ReturnsAsync(() =>
            new List<Customer>() { A.New<Customer>() });

            var customerService = new CustomerService(_customerReadDataStore.Object);

            var result = await customerService.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DataStore_Search_ReturnsData()
        {
            _customerReadDataStore.Setup(x => x.Search(It.IsAny<string>())).ReturnsAsync(() =>
            new List<Customer>() { new Customer { FirstName = "TestName" } });

            var customerService = new CustomerService(_customerReadDataStore.Object);

            var result = await customerService.Search("Test");

            Assert.NotNull(result);
        }
    }
}
