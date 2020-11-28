using System.ComponentModel.DataAnnotations;

namespace WebTSJ.Models
{
    public class FloatCounterModel
    {
        [Required] [StringLength(6)] public string IdOwner { get; set; }
        public int Water { get; set; }
        public int Gas { get; set; }
        public int Electricity { get; set; }

        public FloatCounterModel(string idOwner, int water, int gas, int electricity)
        {
            IdOwner = idOwner;
            Water = water;
            Gas = gas;
            Electricity = electricity;
        }
    }
}