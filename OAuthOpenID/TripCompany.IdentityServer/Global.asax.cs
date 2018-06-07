using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TripCompany.IdentityServer
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            int i = 10;
            int j = i;
            System.Diagnostics.Debug.WriteLine("Test Output message.");
            Console.WriteLine("Console message.");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            string message = ex.Message;

            //Console.Write(string.Format("{0}; {1}; {2}; {3}", ex.Message, ex.StackTrace, ex.InnerException == null ? "": ex.InnerException.Message, ex.Source));
            System.Diagnostics.Debug.WriteLine(string.Format("{0}; {1}; {2}; {3}", ex.Message, ex.StackTrace, ex.InnerException == null ? "": ex.InnerException.Message, ex.Source));

            throw ex;
            
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}