using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelperr
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
