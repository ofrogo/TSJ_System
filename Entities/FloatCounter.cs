namespace Entities
{
    public class FloatCounter
    {
        public string IdOwner { get; set; }
        public int Water { get; set; }
        public int Gas { get; set; }
        public int Electricity { get; set; }

        public FloatCounter(string idOwner, int water, int gas, int electricity)
        {
            IdOwner = idOwner;
            Water = water;
            Gas = gas;
            Electricity = electricity;
        }
    }
}