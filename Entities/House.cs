

using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class House
    {
        [Required] public string IdAddress { get; set; }
        public int CountPodezd { get; set; }
        public int CountFloor { get; set; }
        [Required] public string IdDistrict { get; set; }
        [Required] public string IdCompany { get; set; }

        public House(string idAddress, int countPodezd, int countFloor, string idDistrict, string idCompany)
        {
            IdAddress = idAddress;
            CountPodezd = countPodezd;
            CountFloor = countFloor;
            IdDistrict = idDistrict;
            IdCompany = idCompany;
        }
    }
}