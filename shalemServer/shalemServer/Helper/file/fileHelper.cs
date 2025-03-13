namespace shalemServer.Helper.file
{
    public class FileHelper
    {
        // Method to check and create a directory if it doesn't exist
        public static void EnsureDirectoryExists(string uploadPath)
        {
            try
            {
                if (!Directory.Exists(uploadPath))
                {
                    // Create the directory if it does not exist
                    Directory.CreateDirectory(uploadPath);
                    Console.WriteLine($"Directory '{uploadPath}' created successfully.");
                }
                else
                {
                    Console.WriteLine($"Directory '{uploadPath}' already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating the directory: {ex.Message}");
            }
        }
    }
}
