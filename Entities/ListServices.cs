using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ListServices
    {
        public int Id { get; set; }
        [Required] public string IdBill { get; set; }
        [Required] public string IdService { get; set; }

        public int Amount { get; set; }

        public ListServices(int id, string idBill, string idService, int amount)
        {
            Id = id;
            IdBill = idBill;
            IdService = idService;
            Amount = amount;
        }

        public ListServices(string idBill, string idService, int amount)
        {
            IdBill = idBill;
            IdService = idService;
            Amount = amount;
        }
    }
}