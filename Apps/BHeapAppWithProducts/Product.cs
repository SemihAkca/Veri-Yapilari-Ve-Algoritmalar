using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHeapAppWithProducts
{
    public class Product:IComparable
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(object? obj)
        {
            Product p = obj as Product;
            return Price.CompareTo(p.Price);
        }
    }
}
