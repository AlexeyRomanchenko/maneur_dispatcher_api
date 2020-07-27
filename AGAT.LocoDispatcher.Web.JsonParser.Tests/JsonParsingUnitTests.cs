using AGAT.LocoDispatcher.Web.JsonPasrer.Utils;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDispatcher.Web.JsonParser.Tests
{
    public class JsonParsingUnitTests: Parser
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task EmptyStringShouldThrowException(string mockJson)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async()=> await ParseToJson(mockJson));
        }

        [Theory]
        [InlineData("dsjdis")]
        public async Task JsonParseShouldPassSuccess(string mockJson)
        {
            try
            {
                await ParseToJson(mockJson);
                return;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
