using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteshgahPracticalProject.Core.Utilities.Files
{
    public static class FileManagerHelper
    {
        public static void CreateDirectoryIfNotExists(string creatingPath)
        {
            if (!IsPathExist(creatingPath))
                Directory.CreateDirectory(creatingPath);
        }

        private static bool IsPathExist(string path)
        {
            return Directory.Exists(path);
        }
    }
}
