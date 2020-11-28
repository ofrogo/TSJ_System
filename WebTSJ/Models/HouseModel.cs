using System.ComponentModel.DataAnnotations;

namespace WebTSJ.Models
{
    public class HouseModel
    {
        [Required] public string IdAddress { get; set; }
        public int CountPodezd { get; set; }
        public int CountFloor { get; set; }
        [Required] public string IdDistrict { get; set; }
        [Required] public string IdCompany { get; set; }

        public HouseModel(string idAddress, int countPodezd, int countFloor, string idDistrict, string idCompany)
        {
            IdAddress = idAddress;
            CountPodezd = countPodezd;
            CountFloor = countFloor;
            IdDistrict = idDistrict;
            IdCompany = idCompany;
        }
    }
}