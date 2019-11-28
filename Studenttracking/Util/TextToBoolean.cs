using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenttracking.Util
{
    public static class TextToBool
    {
        public static bool Get(string text)
        {
            return text.Contains("Y");
        }
    }
}
