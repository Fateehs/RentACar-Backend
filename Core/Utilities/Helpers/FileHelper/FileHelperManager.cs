using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Helpers.GuidHelperr;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelperService
    {
        string _path = Directory.GetCurrentDirectory() + "/wwwroot/";
        string _imageFolderPath = "images/";
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath =  guid + extension;

                using (FileStream fileStream = File.Create(_path + _imageFolderPath + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return _imageFolderPath + filePath;
                }
            }
            return null;
        }
    }
}
