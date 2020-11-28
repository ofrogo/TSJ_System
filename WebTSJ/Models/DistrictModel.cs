using System.ComponentModel.DataAnnotations;

namespace WebTSJ.Models
{
    public class DistrictModel
    {
        public DistrictModel(string idName)
        {
            IdName = idName;
        }

        [Required] public string IdName { get; set; }
    }
}