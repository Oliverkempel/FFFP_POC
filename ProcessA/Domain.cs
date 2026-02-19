namespace ProcessA
{
    using FFFP_POC_Core;

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class Domain
    {
        private FileSystemWatcher watcher;
        // This represents up to date data from the database
        public List<Product> Products { get; set; }

        public string ExportDirectory { get; set; }
        public string ArchiveDirectory { get; set; }
        public string RequestDirectory { get; set; }

        public Domain()
        {
            // Set the directory to the desktop.
            ExportDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"InterchangeRoot\ProcessA\Export");
            RequestDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"InterchangeRoot\ProcessA\Requests");
            ArchiveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"InterchangeRoot\ProcessA\Archive");

            // This ensures the directories exist.
            InitDirectories();

            // Start the filesystem watcher
            StartWatcher();
            
        }

        private async void Watcher_FileCreatedInDir(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"New file in requests folder registered!: {e.Name}");
            
            try
            {
                string requestStr = "";

                // Read and deserialize the request, and perform retries if the file is still locked by the other process
                
                bool hasReadFile = false;
                
                while (!hasReadFile)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(e.FullPath))
                        {
                            requestStr = sr.ReadToEnd();
                        }
                        hasReadFile = true;
                    }
                    catch (IOException ex)
                    {
                        Thread.Sleep(20);
                    }
                }
                
                // Deserialize the request
                Request requestObj = JsonSerializer.Deserialize<Request>(requestStr);

                // Sus way to do it but fine enough for prototype
                if(requestObj.RequestType == "AllProducts")
                {
                    // Assemble filename
                    string filename = $"{requestObj.ResponseIndentifyer.ToString()}.json";
                    
                    // Export the products
                    ExportProducts(filename);
                }


            } catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }

        }

        public void ExportProducts(string filename)
        {
            Console.WriteLine("Waiting 5 seconds, then sending the data");
            // Dummy 5 second delay to "fake" a whole bunch of data
            Thread.Sleep(5000);

            try
            {
                // Convert list of products to json
                string jsonStr = JsonSerializer.Serialize(Products);

                string fullFilePath = Path.Combine(ExportDirectory, filename);

                // Writes them to the file safely
                using (StreamWriter sw = new StreamWriter(fullFilePath, false))
                {
                    sw.WriteLine(jsonStr);
                }

                Console.WriteLine("Products has been succesfully exported!");

            } catch(Exception ex) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }

        }

        // HELPERS

        private void StartWatcher()
        {
            // Init the filesystem watcher
            watcher = new FileSystemWatcher(RequestDirectory, RequestDirectory);

            // On what specific changes should the event fire
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.FileName;

            // Only monitor for txt files
            watcher.Filter = "*.txt";

            //watcher.Created += Watcher_FileCreatedInDir;
            watcher.Created += Watcher_FileCreatedInDir;

            // Allow the watcher to raise events
            watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitDirectories()
        {
            if (!Directory.Exists(ExportDirectory))
            {
                // Make sure to change permission for the folder to everyone!
                Directory.CreateDirectory(ExportDirectory);
            }

            if (!Directory.Exists(RequestDirectory))
            {
                // Make sure to change permission for the folder to everyone!
                Directory.CreateDirectory(RequestDirectory);
            }

            if (!Directory.Exists(ArchiveDirectory))
            {
                // Make sure to change permission for the folder to everyone!
                Directory.CreateDirectory(ArchiveDirectory);
            }
        }
    }
}
