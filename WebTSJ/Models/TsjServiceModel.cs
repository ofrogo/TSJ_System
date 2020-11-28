namespace WebTSJ.Models
{
    public class TsjServiceModel
    {
        public TsjServiceModel(string idName, int price)
        {
            IdName = idName;
            Price = price;
        }

        public string IdName { get; set; }
        public int Price { get; set; }
    }
}