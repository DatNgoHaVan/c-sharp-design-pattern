using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c_sharp_design_pattern.CreationalPatterns.FactoryMethod.Problem
{
    // Item can be Box or Product
    // This make Naming Convention issue
    public class Item
    {
        public string ItemName { get; set; }

        // The Product has Price
        // But the Box
        public decimal Price { get; set; }

        // The Item always has children
        // But if a Leaf Item, there no children inside
        // Only the Composite (Container) has children
        // So this doesn't adhere the Composite DP
        public List<Item> ItemChildren { get; set; }

        public decimal Cost()
        {
            decimal cost = Price;
            // Cause the Children can be both Box or Product
            // we must check the Item is Composite or Leaf by the Children
            if (ItemChildren != null)
            {
                // Actually in this code we are doing a recursive to calculate the Cost
                // The condition to end the recursive is Leaf Item
                foreach (Item item in ItemChildren)
                {
                    cost += item.Cost(); // Recursive call to Cost() for child items
                }
            }

            return cost;
        }
    }

    public class main
    {
        static void Main(string[] args)
        {
            var package = CreateItemPackage();
            Console.WriteLine(package.Cost());
        }

        private static Item CreateItemPackage()
        {
            return new Item
            {
                Name = "root box",
                Price = 0,
                Children = new List<Item>
            {
                new Item
                {
                    Name = "Mouse",
                    Price = 20.5f,
                    Children = null // No clear distinction between leaf and composite
                },
                new Item
                {
                    Name = "sub box",
                    Price = 0,
                    Children = new List<Item>
                    {
                        new Item
                        {
                            Name = "Keyboard",
                            Price = 60,
                            Children = null // No clear distinction between leaf and composite
                        },
                        new Item
                        {
                            Name = "Charger",
                            Price = 15,
                            Children = null // No clear distinction between leaf and composite
                        }
                    }
                }
            }
            };
        }
    }
}
