namespace Entities
{
    public class TsjService
    {
        public TsjService(string idName, int price)
        {
            IdName = idName;
            Price = price;
        }

        public string IdName { get; set; }
        public int Price { get; set; }
    }
}