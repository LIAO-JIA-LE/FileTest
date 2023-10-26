using Microsoft.AspNetCore.Mvc;

namespace FileTest.Controllers
{
    [Route("[controller]")]
    public class FileController : Controller
    {
        [HttpPost]
        [Route("[Action]")]
        public IActionResult Upload(List<IFormFile> files){
            foreach(var file in files){
                if (file != null && file.Length > 0)
                {
                    // 处理文件并将其保存到服务器或云存储
                    // 这里只是保存到wwwroot目录下
                    var filePath = Path.Combine("wwwroot", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                        
                    }
                }
            }
            return Ok("File uploaded successfully.");
        }
        [HttpGet("[Action]/{fileName}")]
        public IActionResult Download(string fileName)
        {
            var filePath = Path.Combine("wwwroot", fileName);
            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "application/octet-stream", fileName);
            }
            return NotFound();
        }
    }
}