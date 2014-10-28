using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /*
     * This class will write an error log for every exception in the DAL.
     * The logfile is saved at "<project path>\TestResults\UnitTestLog <date-and-time>.txt".
     */

    public class ErrorLogWriter
    {
        private string LogFilePath;
        private string TimeFileString, TimeNameString, DateFileString, DateNameString;

        public ErrorLogWriter()
        {
            TimeFileString = DateTime.Now.ToLongTimeString();
            TimeNameString = DateTime.Now.ToString("H_mm_ss");
            DateFileString = DateTime.Now.ToLongDateString();
            DateNameString = DateTime.Now.ToString("dd-MM-yyyy");

            LogFilePath = GetLogFilePath();
        }

        private string GetLogFilePath()
        {
            // This will output <project path>\UnitTest\bin\Debug when a unit test is running.
            string CurrentPath = System.IO.Directory.GetCurrentDirectory();

            // This will remove "\UnitTest\bin\Debug" from the string, leaving the project root directory
            string AppDir = CurrentPath.Remove(CurrentPath.Length - 19);

            // Append \TestResults\ for the complete file path
            return AppDir + @"\TestResults\UnitTestLog " + DateNameString + " " + TimeNameString + ".txt";
        }

        private void WriteHeader()
        {
            using (StreamWriter Writer = File.AppendText(LogFilePath))
            {
                Writer.WriteLine("");
                Writer.WriteLine("========================== DAL Error Log ==========================");
                Writer.WriteLine("");
                Writer.WriteLine("-------------------------------------------------------------------------");
                Writer.WriteLine("");
                Writer.WriteLine("Timestamp:");
                Writer.WriteLine("{0} {1}", TimeFileString, DateFileString);
                Writer.WriteLine("");
                Writer.WriteLine("-------------------------------------------------------------------------");
                Writer.WriteLine("");
                Writer.WriteLine("");
            }
        }

        public void WriteToLogFile(string Entry)
        {
            if (!File.Exists(LogFilePath))
            {
                WriteHeader();
            }

            using (StreamWriter Writer = File.AppendText(LogFilePath))
            {
                Writer.WriteLine("*************** An Exception in the DAL occured ***************");
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
