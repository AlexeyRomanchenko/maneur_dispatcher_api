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
        public void EmptyStringShouldThrowException(string mockJson)
        {
            Assert.Throws<ArgumentNullException>(()=> _jsonOperator.ParseToJson(mockJson));
        }

        [Theory]
        [InlineData("D://messages.json")]
        public async Task JsonParseShouldPassSuccess(string path)
        {
            try
            {
                DriveOperator drive = new DriveOperator();
                string jsonDataString =  await drive.GetJSONFromFileAsync(path);
                _jsonOperator.ParseToJson(jsonDataString);
                return;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
