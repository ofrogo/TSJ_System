namespace Entities
{
    public class Jilez
    {
        public string PassportId { get; set; }
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