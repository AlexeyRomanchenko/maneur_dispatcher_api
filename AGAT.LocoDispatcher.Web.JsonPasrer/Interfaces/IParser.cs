using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.JsonPasrer.Interfaces
{
    interface IParser
    {
        Task ParseToJson(string jsonString);
    }
}
