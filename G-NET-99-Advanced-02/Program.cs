namespace G_NET_99_Advanced_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new List<Product>()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
            };
            Console.WriteLine("--- Electronics ---");
            List<Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            PrintProducts(electronics);
            Console.WriteLine("\n--- Under $50 ---");
            List<Product> cheapProducts = SearchProducts(catalog, p => p.Price < 50);
            PrintProducts(cheapProducts);
            Console.WriteLine("\n--- In Stock ---");
            List<Product> inStockProducts = SearchProducts(catalog, p => p.Stock > 0);
            PrintProducts(inStockProducts);
            Console.WriteLine("\n--- Clothing Under $100 ---");
            List<Product> cheapClothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            PrintProducts(cheapClothing);
            //Task 3 Part 3.1 Print Reports 
            Console.WriteLine("--- Short Report ---");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
            Console.WriteLine("\n--- Detailed Report ---");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
        }
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                if (filter(product) == true)
                {
                    result.Add(product);
                }
            }
            return result;
        }
        public static void PrintProducts(List<Product> productsList)
        {
            foreach (Product p in productsList)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
        }
        public static void PrintReport(List<Product> products, Action<Product> printAction)
        {
            foreach (Product product in products)
            {
                printAction(product);
            }
        }
    }
}
