using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace WordUnscramble
{
    public class FileReader
    {
        public string[] Read(string filename)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(filename);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fileContent;
        }
    }
}