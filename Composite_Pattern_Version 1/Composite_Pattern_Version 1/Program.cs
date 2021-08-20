using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite_Pattern_Version_1
{  
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Composite();
            var p1 = new Composite();
            var p2 = new Composite();
            var p3 = new Composite();
            var c1 = new Composite { Price = 14 };
            var c2 = new Composite { Price = 15 };
            var c3 = new Composite { Price = 16 };

            root.AddChild(p1);
            root.AddChild(p2);

            p1.AddChild(c1);
            p1.AddChild(c2);

            p2.AddChild(p3);

            p3.AddChild(c3);

            Console.WriteLine(root.TotalPrice());
            Console.WriteLine(root.Price);
            Console.WriteLine(p1.Price);
            Console.WriteLine(p2.Price);
            Console.WriteLine(p3.Price);
        }
    }
}
