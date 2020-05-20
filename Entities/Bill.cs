using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Bill
    {
        [Required] public string Id { get; set; }
        [Required] public string IdCompany { get; set; }
        [Required] public string IdJilez { get; set; }

        public Bill(string id, string idCompany, string idJilez)
        {
            Id = id;
            IdCompany = idCompany;
            IdJilez = idJilez;
        }
    }
}