using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExamples
{
    public interface ILogger
    {
        void LogException(string message);
    }

    public class SimpleLogger : ILogger
    {
        public void LogException(string message)
        {
            //Log to file.
        }
    }

    public class Log4Net : ILogger
    {
        public void LogException(string message)
        {
            this.LogError(message);
        }

        public void LogError(string message)
        {
            //Log to file and DB if configured
        }
    }

    public class MyApplication
    {
        public void MyImplementation(ILogger logger)
        {
            try
            {
                //Logic...
            }
            catch(Exception ex)
            {
                logger.LogException(ex.Message);
            }
        }
    }
}
