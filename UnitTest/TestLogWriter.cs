using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    /*
     * This class will write a log file with every failed Assert in a unit test.
     * The logfile is saved at "<project path>\TestResults\UnitTestLog <date-and-time>.txt".
     */

    public class TestLogWriter
    {
        private string TestResultsFilePath;
        private string TimeFileString, TimeNameString, DateFileString, DateNameString;

        public TestLogWriter()
        {
            TimeFileString = DateTime.Now.ToLongTimeString();
            TimeNameString = DateTime.Now.ToString("H_mm_ss");
            DateFileString = DateTime.Now.ToLongDateString();
            DateNameString = DateTime.Now.ToString("dd-MM-yyyy");

            TestResultsFilePath = GetTestResultsFilePath();
        }

        private string GetTestResultsFilePath()
        {
            // This will output <project path>\UnitTest\bin\Debug when a unit test is running.
            string CurrentPath = System.IO.Directory.GetCurrentDirectory();

            // This will remove "\UnitTest\bin\Debug" from the string, leaving the project root directory
            string AppDir = CurrentPath.Remove(CurrentPath.Length - 19);

            // Append \TestResults\ for the complete file path
            return AppDir + @"\TestResults\UnitTestLog " + DateNameString + " " + TimeNameString + ".txt";
        }

        public void WriteToLogFile(string Entry)
        {
            // Used to add header to the file
            bool FileExists = File.Exists(TestResultsFilePath);

            using (StreamWriter Writer = File.AppendText(TestResultsFilePath))
            {
                if (!FileExists)
                {
                    Writer.WriteLine("");
                    Writer.WriteLine("========================== Unit Test Error Log ==========================");
                    Writer.WriteLine("");
                    Writer.WriteLine("-------------------------------------------------------------------------");
                    Writer.WriteLine("");
                    Writer.WriteLine("Unit Test deployed at");
                    Writer.WriteLine("{0} {1}", TimeFileString, DateFileString);
                    Writer.WriteLine("");
                    Writer.WriteLine("-------------------------------------------------------------------------");
                    Writer.WriteLine("");
                    Writer.WriteLine("");
                }

                Writer.WriteLine("*************** An Assert in the Unit Test failed ***************");
                Writer.WriteLine("");
                Writer.WriteLine("Exception details with stacktrace:");
                Writer.WriteLine("   {0}", Entry);
                Writer.WriteLine("");
                Writer.WriteLine("");
                Writer.WriteLine("");
            }
        }
    }
}
