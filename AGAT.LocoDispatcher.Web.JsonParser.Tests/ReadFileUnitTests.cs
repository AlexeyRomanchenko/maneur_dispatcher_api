using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDispatcher.Web.JsonParser.Tests
{
    public class ReadFileUnitTests : Parser
    {
        [Theory]
        [InlineData("D:\\messages.json")]
        public async Task ReadTextFromFileOk(string pathToFile)
        {
            string jsonData = await GetJSONFromFileAsync(pathToFile);
            Assert.NotEmpty(jsonData);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task ReadTextFromFileWithoutPath(string pathToFile)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async()=> await GetJSONFromFileAsync(pathToFile));
        }

        [Theory]
        [InlineData("D:\\messages32.json")]
        public async Task ReadTextFromUnexistingFile(string pathToFile)
        {
            await Assert.ThrowsAsync<FileNotFoundException>(async () => await GetJSONFromFileAsync(pathToFile));
        }
    }
}
