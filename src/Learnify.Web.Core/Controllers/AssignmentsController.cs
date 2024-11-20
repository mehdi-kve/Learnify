using Learnify.Blob;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learnify.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentsController : LearnifyControllerBase
    {
        private readonly IBlobAppService _blobAppService;

        public AssignmentsController(IBlobAppService blobAppService)
        {
            _blobAppService = blobAppService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPdf(byte[] pdfBytes)
        {
            await _blobAppService.SavePdfAsync("my-pdf-file.pdf", pdfBytes);
            return Ok();
        }

        [HttpGet]
        [Route("download/{fileName}")]
        public async Task<IActionResult> DownloadAsync(string fileName)
        {
            var fileDto = await blobAppService.GetAsync(new GetBlobRequestDto { Name = fileName });
            return File(fileDto.Content, "application/octet-stream", fileDto.Name);
        }
    }
}
