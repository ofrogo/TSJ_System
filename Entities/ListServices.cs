namespace Entities
{
    public class ListServices
    {
        public int Id { get; set; }
        public string IdBill { get; set; }
        public string IdService { get; set; }
        
        public int Amount { get; set; }

        public ListServices(int id, string idBill, string idService, int amount)
        {
            Id = id;
            IdBill = idBill;
            IdService = idService;
            Amount = amount;
        }
    }
}