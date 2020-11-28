using System.ComponentModel.DataAnnotations;

namespace WebTSJ.Models
{
    public class BillModel
    {
        [Required] public string Id { get; set; }
        [Required] public string IdCompany { get; set; }
        [Required] public string IdJilez { get; set; }

        public BillModel(string id, string idCompany, string idJilez)
        {
            Id = id;
            IdCompany = idCompany;
            IdJilez = idJilez;
        }
    }
}