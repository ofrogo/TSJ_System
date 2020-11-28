using System.ComponentModel.DataAnnotations;

namespace WebTSJ.Models
{
    public class ManageCompanyModel
    {
        public ManageCompanyModel(string idName, string fslOwner, string officeAddress, int countHouse)
        {
            IdName = idName;
            FslOwner = fslOwner;
            OfficeAddress = officeAddress;
            CountHouse = countHouse;
        }

        [Required] public string IdName { get; set; }

        public string FslOwner { get; set; }

        public string OfficeAddress { get; set; }

        public int CountHouse { get; set; }
    }
}
