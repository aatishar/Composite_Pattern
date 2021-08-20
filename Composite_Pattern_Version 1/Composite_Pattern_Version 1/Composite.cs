using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern_Version_1
{
    class Composite
    {
        private List<Composite> children = new List<Composite>();

        public Composite Parent { get; private set; }
        public IReadOnlyList<Composite> Children => this.children;
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
            this.children.Add(composite);
            composite.Parent = this;
            this.Price = this.TotalPrice();
        }

        public void RemoveChild(Composite composite)
        {
            this.children.Remove(composite);
            this.Price = this.TotalPrice();
        }

        public void PropagatePriceChangeToParent()
        {
            this.Parent?.ReCalculateTotal();
        }

        public void ReCalculateTotal()
        {
            this.Price = this.children.Sum(a => a.Price);
        }

        public decimal TotalPrice()
        {
            if (this.children.Count == 0)
            {
                return this.Price;
            }
            else
            {
                return this.children
                   .Select(a => a.TotalPrice())
                   .Sum();
            }

        }
    }
}
