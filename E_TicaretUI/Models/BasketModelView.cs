using E_TicaretEntity;

namespace E_TicaretUI.Models
{
    public class BasketModelView
    {
        public List<UIBasket> Basket { get; set; }
        //public double BasketPrice { get; set; }
        //public double Basketpiece { get; set; }
        public double totalproductprice { get; set; }
        public double totalprice { get; set; }
        public double cargo { get; set; }
        public int productcount { get; set; }

    }
}
