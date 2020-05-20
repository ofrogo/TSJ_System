using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Jilez
    {
        [Required] [StringLength(6)] public string PassportId { get; set; }
        public string Fsl { get; set; }
        public int NumberFlat { get; set; }
        public string HouseAddress { get; set; }

        public Jilez(string passportId, string fsl, int numberFlat, string houseAddress)
        {
            PassportId = passportId;
            Fsl = fsl;
            NumberFlat = numberFlat;
            HouseAddress = houseAddress;
        }
    }
}