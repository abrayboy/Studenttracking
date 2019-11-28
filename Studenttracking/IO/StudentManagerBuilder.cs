using Studenttracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Studenttracking.IO
{
    public static class StudentManagerBuilder
    {

        public static async Task<StudentManager> Build(StorageFile spreadSheet)
        {
            var lines = await FileIO.ReadLinesAsync(spreadSheet);
            var lineNumber = 0;
            var studentManager = new StudentManager();
            return studentManager;
        }
    }
}
