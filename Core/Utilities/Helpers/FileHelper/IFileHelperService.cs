using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelperService
    {
        public string Add(IFormFile file);
        public void Delete(string filePath);
        public string Update(IFormFile file, string oldFilePath);
    }
}
