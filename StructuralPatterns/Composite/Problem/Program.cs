using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructuralPatterns.Composite.Problem;

// Item can be Box or Product
// The Box is not for sale, it's just a container, it will be Composite
// The Product is for sale and it will be Leaf, so it has Price
// This make the Item class is not clear about the Composite DP
public class Item
{
    public string Name { get; set; }

    // The Product has Price
    // But the Box has no Price
    public decimal Price { get; set; }

    // The Item always has children
    // But if a Leaf Item, there no children inside
    // Only the Composite (Container) has children
    // So this doesn't adhere the Composite DP
    public List<Item> Children { get; set; }

    public decimal Cost()
    {
        decimal cost = Price;
        // Cause the Children can be both Box or Product
        // we must check the Item is Box (Composite) or Product (Leaf) by the Children
        if (Children != null)
        {
            // Actually in this code we are doing a recursive to calculate the Cost
            // The condition to end the recursive is Leaf Item
            foreach (Item item in Children)
            {
                cost += item.Cost(); // Recursive call to Cost() for children items
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
                    Price = 20.5m,
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
