using System.ComponentModel.DataAnnotations;

namespace WebTSJ.Models
{
    public class ListServicesModel
    {
        public int Id { get; set; }
        [Required] public string IdBill { get; set; }
        [Required] public string IdService { get; set; }

        public int Amount { get; set; }

        public ListServicesModel(int id, string idBill, string idService, int amount)
        {
            Id = id;
            IdBill = idBill;
            IdService = idService;
            Amount = amount;
        }

        public ListServicesModel(string idBill, string idService, int amount)
        {
            IdBill = idBill;
            IdService = idService;
            Amount = amount;
        }
    }
}