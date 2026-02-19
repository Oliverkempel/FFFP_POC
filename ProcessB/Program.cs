namespace ProcessB;

using FFFP_POC_Core;

public class Program
{
    public async static Task Main(string[] args)
    {
        Console.WriteLine("Process B - I want products!");

        Domain domain = new Domain();
        while (true)
        {
            Console.WriteLine("Press any key to request products!");
            Console.ReadKey();

            List<Product> response = await domain.GetAllProducts();

            // Print the response!
            foreach (Product product in response)
            {
                Console.WriteLine(product.ToString());
            }
        }

    }

}