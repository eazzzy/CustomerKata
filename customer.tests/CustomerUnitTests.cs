using customerdata.lib;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace customer.tests
{
    public class CustomerUnitTests
    {
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
    }
}
