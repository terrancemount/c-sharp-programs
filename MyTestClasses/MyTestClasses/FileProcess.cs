using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestClasses
{
    public class FileProcess
    {
        /**
         * Check the file system to see if the file exsists.
         * @params {string} fileName is a string representing the filename
         * @returns {bool} a boolean with true meaning file exists and false meaning it does not.
         * @throws ArguementNullExecption if fileName empty or null.
         */
        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            return File.Exists(fileName);
        }
    }
}
