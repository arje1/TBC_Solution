using Microsoft.AspNetCore.Http;
using PersonRegister.Core.Application.Interfaces.Services;
using System.IO;

namespace PersonRegister.Infrastructure.FileSystem
{
    internal class FileService : IFileService
    {

        private readonly string address;
        public FileService(string address)
        {
            this.address = address;
        }


        public void UploadPhoto(IFormFile file, string fileName)
        {
            SaveFile(file, fileName);
        }
        /// <summary>
        /// ინახავს ფაილს მითითებული სახელით
        /// </summary>
        /// <param name="file">ფაილი</param>
        /// <param name="fileName">ფაილის ახალი სახელი</param>
        public void SaveFile(IFormFile file, string fileName)
        {

            Directory.CreateDirectory(address);

            var filePath = Path.Combine(address, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

        }

        /// <summary>
        /// შლის ფაილს მითითებული სახელით
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFile(string fileName)
        {
            var target = Path.Combine(address, fileName);
            if (Directory.Exists(target))
            {
                var filePath = Path.Combine(target, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        public string GetExtension(string filename)
        {
            return Path.GetExtension(filename);
        }
    }
}
