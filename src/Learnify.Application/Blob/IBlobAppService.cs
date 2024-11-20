using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learnify.Blob
{
    public interface IBlobAppService
    {
        Task<string> SaveAsync(string fileName, byte[] fileByte);
        Task<byte[]> GetAsync(string fileName);

       // Task<string> UploadAsync(IFormFile file, int courseStepId, CancellationToken cancellationToken = default);
       // Task DeleteAsync(string blobUrl);
    }
}
