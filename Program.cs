namespace Supermarket
{
    public class Basket
    {
        private double maxWeight;
        private double currentWeight = 0.0;
        private List<Product> products;
        public IReadOnlyList<Product> Products => products;

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
        public string Name { get; set; }
        public double Weight { get; set; }

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

            Console.WriteLine("Items in basket:");
            foreach (var product in basket.Products)
            {
                Console.WriteLine(product.Name + ": " + product.Weight + " kg");
            }
        }
    }

}