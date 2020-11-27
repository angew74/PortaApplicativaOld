using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WSPA
{
    public class Global : System.Web.HttpApplication
    {

        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(Global));

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Application_Error(object sender, EventArgs e)
        {
            System.Exception ex = Server.GetLastError();
            _log.Error(ex.Message);
            if (ex.InnerException != null)
            {
                _log.Error(ex.InnerException.Message);
            }
        }

    }
}