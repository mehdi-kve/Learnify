using Abp.BlobStoring;
using Abp.Dependency;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learnify.Blob
{
    public class BlobAppService : IBlobAppService, ITransientDependency
    {
        private readonly IBlobContainer _blobContainer;

        public BlobAppService(IBlobContainer blobContainer)
        {
            _blobContainer = blobContainer;
        }

        public async Task<string> SaveAsync(string fileName, byte[] fileByte)
        {
            var blobName = $"{Guid.NewGuid().ToString()}-{fileName}";
            await _blobContainer.SaveAsync(blobName, new MemoryStream(fileByte));
            return $"{BlobContainerNames.Files}/{blobName}";

        }

        public async Task<byte[]> GetAsync(string fileName)
        {
            using (var stream = await _blobContainer.GetAsync(fileName))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }

        /* public Task DeleteAsync(string blobUrl)
         {
             throw new NotImplementedException();
         }*/

        /*public async Task<string> UploadAsync(IFormFile file, int courseStepId, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                return null;

            string uniqueFileName = $"{courseStepId}/{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            using var stream = file.OpenReadStream();
            var blobClient = _containerClient.GetBlobClient(uniqueFileName);
            await blobClient.UploadAsync(stream, cancellationToken);

            return blobClient.Uri.ToString();

        }*/
    }
}
