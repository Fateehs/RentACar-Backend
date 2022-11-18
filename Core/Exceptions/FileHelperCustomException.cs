using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class FileHelperCustomException : Exception, ICustomException
    {
        public FileHelperCustomException(string message) : base(message)
        {

        }
    }
}
