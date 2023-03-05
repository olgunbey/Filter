using FilterExample.API.Models;

namespace FilterExample.API
{
    public class ProductUret 
    {
        public static List<Product> ProductUrets()
        {
            return new List<Product>()
            {
                new Product() {ID=1,ProductName="A",Stock=21},
                new Product() {ID=2,ProductName="B",Stock=31},
                new Product() {ID=3,ProductName="C",Stock=41},
            };
        }
    }
}
