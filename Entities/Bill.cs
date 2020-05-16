namespace Entities
{
    public class Bill
    {
        public string Id { get; set; }
        public string IdCompany { get; set; }
        public string IdJilez { get; set; }

        public Bill(string id, string idCompany, string idJilez)
        {
            Id = id;
            IdCompany = idCompany;
            IdJilez = idJilez;
        }
    }
}