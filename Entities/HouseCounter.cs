

using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class HouseCounter
    {
        [Required] public string Id { get; set; }
        public int Water { get; set; }
        public int Gas { get; set; }
        public int Electricity { get; set; }

        public HouseCounter(string id, int water, int gas, int electricity)
        {
            Id = id;
            Water = water;
            Gas = gas;
            Electricity = electricity;
        }
    }
}