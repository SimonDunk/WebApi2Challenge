using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class ProductData
    {
        //dummy data
        private string[] descs = { "large tv", "22in monitor", "4k tv", "1080p tv", "144p tv" };
        private string[] models = { "A100", "IPS9000", "OLED117" };
        private string[] brands = { "GL", "SUSA", "ACE", "PAN", "TKL" };

        //filling database with products
        public ProductData(ProductContext c, int i)
        {
            for (int n = 0; i > n; n++)
            {
                AddProduct(c, i);
            }
            c.SaveChanges();
        }

        //adding individual product
        private void AddProduct(ProductContext context, int i)
        {
            Random rnd = new Random();
            context.ProductList.Add(new Product { Description = descs[rnd.Next(0, descs.Count())], Model = models[rnd.Next(0, models.Count())], Brand = brands[rnd.Next(0, brands.Count())] });
        }
    }
}
