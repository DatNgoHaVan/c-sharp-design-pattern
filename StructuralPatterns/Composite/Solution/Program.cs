using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreationalPatterns.FactoryMethod.Solution;

// Make a common interface for both Box and Product
// Both of them have the Cost
public interface ICommonItem
{
    public decimal Cost();
}

// Leaf Item represents Product
public class Product : ICommonItem
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public decimal Cost()
    {
        return Price;
    }
}

// Composite (Container) represents Box
public class Box : ICommonItem
{
    public string BoxName { get; set; }
    // ItemChildren can be a Box or a Product
    private List<ICommonItem> ItemChildren = new List<ICommonItem>();

    public decimal Cost()
    {
        // Now the cost of the Box will only go to the child and get the Cost
        // We don't need to check type of the children to calculate, the children do themselves
        decimal cost = 0;
        foreach (var item in Box.ItemChildren)
        {
            cost += item.Cost();
        }
        return cost;
    }

    // Add new methods to add or delete children
    public void Add(ICommonItem item)
    {
        ItemChildren.Add(item);
    }

    public void Remove(ICommonItem item)
    {
        ItemChildren.Remove(item);
    }

}

public class main
{
    static void Main(string[] args)
    {
        // Create leaf items
        var hammer = new Product { ProductName = "Hammer", Price = 10.50m };
        var iphone15 = new Product { ProductName = "IPhone15", Price = 45 };
        var macbookPro = new Product { ProductName = "Macbook Pro 16 inch", Price = 90.5m };

        var shopeeCart = new Box { BoxName = "Shopee Order Cart" };
        shopeeCart.Add(macbookPro);
        shopeeCart.Add(iphone15);

        // Calculate and print the total cost
        Console.WriteLine(shopeeCart.Cost());
    }
}
