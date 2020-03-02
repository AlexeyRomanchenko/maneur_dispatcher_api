namespace AGAT.LocoDispatcher.Web
{
    public class TestDI
    {
        public object Make()
        {
            var json = new {
                Name = "Alex",
                Lastname = "Romanchenko",
            };
            return json;
        }
    }
}
