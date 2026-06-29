using Models;

namespace Data
{
    public class StaticContext
    {
        private readonly List<Product> _products;

        public StaticContext()
        {
            _products=new List<Product>()
            {
                new Product(){Id=1,Name="Pc",Category="Teknolojik",Description="Mükemmel bir güçlü"+
                "bilgisayar",Price=6000,Stock=100,ImageUrl="~/uploads/picture.jpg"},
                 new Product(){Id=2,Name="Phone",Category="Teknolojik",Description="Mükemmel bir güçlü"+
                "telefon",Price=6000,Stock=100,ImageUrl="~/uploads/picture.jpg"},
                 new Product(){Id=3,Name="Phone",Category="Teknolojik",Description="Mükemmel bir güçlü"+
                "tablet",Price=6000,Stock=100,ImageUrl="~/uploads/picture.jpg"}
                 
            };

            
        }

       public List<Product> Products => _products;
        
    }
}