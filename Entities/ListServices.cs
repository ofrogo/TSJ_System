namespace Entities
{
    public class ListServices
    {
        public int Id { get; set; }
        public string IdBill { get; set; }
        public string IdService { get; set; }

        public ListServices(int id, string idBill, string idService)
        {
            Id = id;
            IdBill = idBill;
            IdService = idService;
        }
    }
}