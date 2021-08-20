using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern_Version_1
{
    class Composite
    {
        public Composite Parent;
        public List<Composite> Children = new List<Composite>();
        private decimal price;

        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                this.PropagatePriceChangeToParent();
            }
        }
        public void AddChild(Composite composite)
        {
            this.Children.Add(composite);
            composite.Parent = this;
            this.Price = this.TotalPrice();
        }

        public void RemoveChild(Composite composite)
        {
            this.Children.Remove(composite);
            this.Price = this.TotalPrice();
        }

        public void PropagatePriceChangeToParent()
        {
            this.Parent?.ReCalculateTotal();
        }

        public void ReCalculateTotal()
        {
            this.Price = this.Children.Sum(a => a.Price);
        }

        public decimal TotalPrice()
        {
            if (this.Children.Count == 0)
            {
                return this.Price;
            }
            else
            {
                return this.Children
                   .Select(a => a.TotalPrice())
                   .Sum();
            }

        }
    }
}
