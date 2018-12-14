using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Order
    {
        private readonly List<Product> _products = new List<Product>();
        public BonusProvider Bonus;

        public void AddProduct(Product p0)
        {
            _products.Add(p0);
        }

        public double GetValueOfProducts()
        {
            return _products.Sum(item => item.Value);
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }
    }
}
