using System.Diagnostics;

namespace HeaviestFirstShopping
{
    public class Basket
    {
        public IReadOnlyList<Product> Products => products; // Expose products as read-only for encapsulation
        private double maxWeight;
        private double currentWeight = 0.0;
        private List<Product> products;

        public Basket(double maxWeight)
        {
            this.maxWeight = maxWeight;
            products = new List<Product>();
        }

        public void AddProducts(List<Product> productsToAddList)
        {
            productsToAddList.Sort((a, b) => b.Weight.CompareTo(a.Weight));
            foreach (var productToAdd in productsToAddList)
            {
                if (currentWeight + productToAdd.Weight <= maxWeight)
                {
                    products.Add(productToAdd);
                    currentWeight += productToAdd.Weight;
                }
            }
        }
    }

    public class Product
    {
        public string Name { get; private set;} // Read-only property 
        public double Weight { get; private set;} // Read-only property

        public Product(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Product> itemsIWantToBuy = new List<Product>
            {
                new Product("Rice", 4.0),
                new Product("Potatoes", 3.0),
                new Product("Whole chicken", 5.0),
                new Product("Sliced bread", 12.0),
            };
            Basket basket = new Basket(20.0);

            basket.AddProducts(itemsIWantToBuy); // Rice must not be added

            double basketTotalWeight = basket.Products.Sum(p => p.Weight);

            TestFunctionality(basket, basketTotalWeight);
            PrintBasketItems(basket, basketTotalWeight);
        }

        private static void PrintBasketItems(Basket basket, double basketTotalWeight)
        {
            Console.WriteLine("Items in basket:");
            foreach (var product in basket.Products)
            {
                Console.WriteLine($" - {product.Name}: {product.Weight} kg");
            }
            Console.WriteLine($"Basket total weight: {basketTotalWeight} kg");
        }

        private static void TestFunctionality(Basket basket, double basketTotalWeight)
        {
            List<Product> expectedOrderedProductList = new List<Product>
            {
                new Product("Sliced bread", 12.0),
                new Product("Whole chicken", 5.0),
                new Product("Potatoes", 3.0),
            };

            Debug.Assert(basketTotalWeight <= 20.0, "Total weight exceeds the basket limit");
            Debug.Assert(basket.Products.Count == expectedOrderedProductList.Count, "Number of products in basket is incorrect");
            for (int i = 0; i < expectedOrderedProductList.Count; i++)
            {
                Debug.Assert(basket.Products[i].Name == expectedOrderedProductList[i].Name, $"Product at index {i} has incorrect name");
                Debug.Assert(basket.Products[i].Weight == expectedOrderedProductList[i].Weight, $"Product at index {i} has incorrect weight");
            }
        }
    }
}