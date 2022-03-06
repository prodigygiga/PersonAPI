using Microsoft.AspNetCore.Http;
using PersonDirectory.Application.Commons;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Application.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Infrastructure.FileService
{
    public class FileService:IFileService
    {
        private readonly string path;
        public FileService(string path)
        {
            this.path = path;
        }


        public Task<string> SavePicture(IFormFile file, string fileName)
        {
            var splittedFileName = fileName.Split('.');
            if(splittedFileName.Length != 2)
            {
                throw new DataRejectedException("ფაილის დასახელება უნდა შეიცავდეს ინფორმაციას ფორმატზე");       
            }
            var name = splittedFileName[0];
            var fileFormat = "." + splittedFileName[1];
            var hash = Functions.CreateMD5(DateTime.Now.ToString());

            var objectName = name + "_" + hash + fileFormat;
            
            Directory.CreateDirectory(Environment.CurrentDirectory + path);

            

            var filePath = Path.Combine(Environment.CurrentDirectory + path, objectName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Task.FromResult(path+objectName);
        }

    }
}
