using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDispatcher.Web.JsonParser.Tests
{
    public class JsonParsingUnitTests: ParseJob
    {
        private JsonOperator _jsonOperator;
        public JsonParsingUnitTests()
        {
            _jsonOperator = new JsonOperator();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task EmptyStringShouldThrowException(string mockJson)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async()=> await _jsonOperator.ParseToJson(mockJson));
        }

        [Theory]
        [InlineData("D://json/messages.json")]
        public async Task JsonParseShouldPassSuccess(string path)
        {
            try
            {
                DriveOperator drive = new DriveOperator();
                string jsonDataString =  await drive.GetJSONFromFileAsync(path);
                await _jsonOperator.ParseToJson(jsonDataString);
                return;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Theory]
        [InlineData("D://json")]
        public async Task GetJSONFilesSuccess(string path)
        {
            try
            {
                DriveOperator drive = new DriveOperator();
                 await drive.GetFilesFromDirectoryAndParseAsync(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
