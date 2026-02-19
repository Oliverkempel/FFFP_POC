namespace ProcessB
{
    using FFFP_POC_Core;

    using System;
    using System.Collections.Generic;
    using System.Runtime.ExceptionServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class Domain
    {
        private FileSystemWatcher watcher;

        public string ResponseDirectory { get; set; }
        public string RequestDirectory { get; set; }
        public string ArchiveDirectory { get; set; }

        public Domain()
        {
            // Set the directory to look for responses to the export directory of Process A.
            ResponseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"InterchangeRoot\ProcessA\Export");
            RequestDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"InterchangeRoot\ProcessA\Requests");
            ArchiveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"InterchangeRoot\ProcessA\Archive");

        }

        
        public async Task<List<Product>> GetAllProducts()
        {
            Request req = new Request("AllProducts");

            string responseStr = await this.SendRequest(req);

            List<Product> response = JsonSerializer.Deserialize<List<Product>>(responseStr);

            return response;

        }
        
        private async Task<string> SendRequest(Request req)
        {
            string responseStr = "";

            try
            {
                // Convert list of products to json
                string jsonStr = JsonSerializer.Serialize(req);

                string assembledFileName = $"Request-{Guid.NewGuid().ToString()}.txt";

                string fullFilePath = Path.Combine(RequestDirectory, assembledFileName);

                // Writes them to the file safely
                using (StreamWriter sw = new StreamWriter(fullFilePath, false))
                {
                    sw.WriteLine(jsonStr);
                }

                Console.WriteLine("The request has been sent!");

            } catch(Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }

            Console.WriteLine("Now awaiting response...");

            // First we check if the file has already arrived!
            // ...

            // Use a semaphore to await for the file to show up in the folder
            SemaphoreSlim semaphore = new SemaphoreSlim(0);

            using(FileSystemWatcher fileWatcher = new FileSystemWatcher(ResponseDirectory))
            {
                fileWatcher.Created += (s, e) =>
                {
                    Console.WriteLine($"The responsefile was found! {e.Name}");

                    // Safely Read the file
                    using(StreamReader sr = new StreamReader(e.FullPath))
                    {
                        responseStr = sr.ReadToEnd();
                    }
                    // The file is found and we can therefore release the semaphore
                    semaphore.Release();
                };

                fileWatcher.EnableRaisingEvents = true;

                // Await here forever until the file shows up. (Some sort of timeout sould realisticly be used here!)
                await semaphore.WaitAsync();
            }

            return responseStr;

        }
    }
}
