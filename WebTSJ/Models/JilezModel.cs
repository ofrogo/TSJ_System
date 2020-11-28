using System.ComponentModel.DataAnnotations;

namespace WebTSJ.Models
{
    public class JilezModel
    {
        [Required] [StringLength(6)] public string PassportId { get; set; }
        public string Fsl { get; set; }
        public int NumberFlat { get; set; }
        public string HouseAddress { get; set; }

        public JilezModel(string passportId, string fsl, int numberFlat, string houseAddress)
        {
            PassportId = passportId;
            Fsl = fsl;
            NumberFlat = numberFlat;
            HouseAddress = houseAddress;
        }
    }
}