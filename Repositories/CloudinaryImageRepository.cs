using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BlogMVC.Web.Repositories
{
    public class CloudinaryImageRepository : IImageRepository
    {
        private readonly IConfiguration configuration;
        private readonly Account account;

        public CloudinaryImageRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(account);

            var UploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };

            var uploadtResult = await client.UploadAsync(UploadParams);

            if (uploadtResult != null && uploadtResult.StatusCode == HttpStatusCode.OK)
            {
                return uploadtResult.SecureUri.ToString();
            }
            return null;
        }

    }
}

