using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nClam;
using shalemServer.Helper;
using shalemServer.Helper.file;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class FileUploadController : ControllerBase
{
    private readonly string _uploadPath = "C:\\UploadedFiles"; // Change this path
    private readonly string _clamAVHost = "localhost"; // ClamAV Server
    private readonly int _clamAVPort = 3310; // Default ClamAV port

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            DateTime date = DateTime.Now;
            // Define your upload path
            string uploadPath = @"C:\UploadedFiles\manas\" + date.ToString("yyyyMMdd");

            // Ensure the directory exists
            FileHelper fileHelper = new FileHelper();
            AntiVirus antiVirus = new AntiVirus();
            // First, scan the file with Windows Defender
            FileHelper.EnsureDirectoryExists(uploadPath);
            bool isFileClean = await antiVirus.ScanWithWindowsDefender(file);

            if (!isFileClean)
            {
                return BadRequest("Virus detected in the uploaded file.");
            }
            // Generate a unique filename
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = file.FileName + "_" + Path.Combine(uploadPath, uniqueFileName);
            // Extract the directory path from the full file path
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            // Save the file
            await System.IO.File.WriteAllBytesAsync(filePath, memoryStream.ToArray());


            using var workbook = new XLWorkbook(memoryStream);
            var worksheet = workbook.Worksheet(1); // Read the first sheet

            List<ExcelData> dataList = new List<ExcelData>();
            var rows = worksheet.RowsUsed().Skip(10); // Skip first 10 rows

            foreach (var row in rows)
            {
                var data = new ExcelData
                {
                    Column1 = row.Cell(1).GetString(),
                    Column2 = row.Cell(2).GetString(),
                    Column3 = row.Cell(3).GetValue<int>() // Convert to int
                };
                dataList.Add(data);
            }


            return Ok(new
            {
                message = "File uploaded successfully!",
                fileName = uniqueFileName,
                filePath = filePath
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpGet("download/{fileName}")]
    public IActionResult DownloadFile(string fileName)
    {
        try
        {
            string uploadPath = @"C:\UploadedFiles\manas\"; // Define the base upload path
            string filePath = Path.Combine(uploadPath, fileName); // Combine with the file name
            string uploadPathRead = Path.GetDirectoryName(filePath);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            // Return the file as a download
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/octet-stream", fileName);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}
