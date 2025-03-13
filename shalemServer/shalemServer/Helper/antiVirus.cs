using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace shalemServer.Helper
{

    public class AntiVirus
    {
        public async Task<bool> ScanWithWindowsDefender(IFormFile file)
        {
            try
            {
                // Create a temporary file to save the uploaded file
                var tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + Path.GetExtension(file.FileName));

                // Save the uploaded file to disk
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Use ProcessStartInfo to run Windows Defender's MpCmdRun
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"C:\Program Files\Windows Defender\MpCmdRun.exe",
                        Arguments = $"-Scan -ScanType 3 -File \"{tempFilePath}\"", // Full file scan
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                // Start the process and get the output
                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                process.WaitForExit();

                // Check if the output or error contains 'threats found'
                if (output.Contains("found threats") || error.Contains("found threats"))
                {
                    // Clean up the temporary file
                    System.IO.File.Delete(tempFilePath);
                    return false; // Virus found
                }

                // Clean up the temporary file
                System.IO.File.Delete(tempFilePath);
                return true; // No virus found
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scanning with Windows Defender: {ex.Message}");
                return false;
            }
        }
    }
}
