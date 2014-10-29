using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /*
     * The purpose of this BLL class is to expose the ErrorLogWriter class in DAL to BookDB Repositories in the Prosjekt1/Repositories namespace,
     * so the functions in that namespace can print their exception details to the Error Log File in case something goes terribly wrong.
     */

    public class ErrorLogBLL
    {
        public static void WriteToErrorLogFile(string Entry)
        {
            ErrorLogWriter Writer = new ErrorLogWriter();
            Writer.WriteToLogFile(Entry);
        }
    }
}
