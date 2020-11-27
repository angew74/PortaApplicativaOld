using System;
using System.Configuration;

using TestPAWeb.WebReference;
using Unisys.CdR.Servizi;
using System.Xml;
using log4net;
using TestPAWeb.EventiWS;
using System.Web.Services.Protocols;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace TestPAWeb
{
    public partial class _Default : System.Web.UI.Page
    {

        private static readonly ILog _log = LogManager.GetLogger(typeof(_Default));

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonNETTERR_Click(object sender, EventArgs e)
        {
             NVA webserviceObject = new NVA();
            webserviceObject.LogHeaderValue = new TestPAWeb.WebReference.LogHeader();
            string internalPW = "comunediroma2007";
            string user = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalAccount"), internalPW);
            string password = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalPassword"), internalPW);
            webserviceObject.Url = ConfigurationManager.AppSettings["URL"];
            webserviceObject.RequestSoapContext.Security.Tokens.Add(new Microsoft.Web.Services2.Security.Tokens.UsernameToken(user, Config.PlainToSHA1(password), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone));
            webserviceObject.LogHeaderValue.LogGuid = "AAAAA";
            try
            {
                 //XmlNode node = webserviceObject.VerificaNETTERR("18/02/2014","21/02/2014");
                XmlNode node = webserviceObject.VerificaNETTERR("03/11/2016", "03/11/2016");
                 XmlDocument doc = new XmlDocument();
                doc.LoadXml(node.OuterXml);
                doc.Save(@"c:\dev\outxml.xml");
                TextResult.Text = doc.OuterXml;
            }
             catch(SoapException se)
            {
                _log.Error(se.Message);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        protected void ButtonNETEVE_Click(object sender,EventArgs e)
        {
            Eventi webserviceObject = new Eventi();
            webserviceObject.LogHeaderValue = new TestPAWeb.EventiWS.LogHeader();
            string internalPW = "comunediroma2007";
            string user = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalAccount"), internalPW);
            string password = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalPassword"), internalPW);
            webserviceObject.Url = ConfigurationManager.AppSettings["URLEVE"];
            webserviceObject.RequestSoapContext.Security.Tokens.Add(new Microsoft.Web.Services2.Security.Tokens.UsernameToken(user, Config.PlainToSHA1(password), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone));
            webserviceObject.LogHeaderValue.LogGuid = "AAAAA";
            try
            {

                XmlNode node = webserviceObject.VariazioniAnagrafiche(21, 8, 2015, "051", 0); 
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(node.OuterXml);
                doc.Save(@"c:\dev\outxml.xml");
                TextResult.Text = doc.OuterXml;
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                TextResult.Text = ex.Message;
            }
        }

        protected void ButtonVABIS_Click(object sender, EventArgs e)
        {
            NVA webserviceObject = new NVA();
            webserviceObject.LogHeaderValue = new TestPAWeb.WebReference.LogHeader();
            string internalPW = "comunediroma2007";
            string user = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalAccount"), internalPW);
            string password = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalPassword"), internalPW);
            webserviceObject.Url = ConfigurationManager.AppSettings["URL"];
            webserviceObject.RequestSoapContext.Security.Tokens.Add(new Microsoft.Web.Services2.Security.Tokens.UsernameToken(user, Config.PlainToSHA1(password), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone));
            webserviceObject.LogHeaderValue.LogGuid = "AAAAA";
            try
            {
              
               // XmlNode node = webserviceObject.VerificaVABIS(1, 1, 081052, "", 27,65, "", "","","","","", 0);  
                XmlNode node = webserviceObject.VerificaVABIS(1, 1, 081052, "", 0,0, "", "", "", "", "", "", 0);  
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(node.OuterXml);
                doc.Save(@"c:\dev\outxml.xml");
                TextResult.Text = doc.OuterXml;             

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                TextResult.Text = ex.Message;
            }

        }

        protected void ButtonVABIS2_Click(object sender, EventArgs e)
        {

            NVA webserviceObject = new NVA();
            webserviceObject.LogHeaderValue = new TestPAWeb.WebReference.LogHeader();
            string internalPW = "comunediroma2007";
            string user = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalAccount"), internalPW);
            string password = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalPassword"), internalPW);
            webserviceObject.Url = ConfigurationManager.AppSettings["URL"];
            webserviceObject.RequestSoapContext.Security.Tokens.Add(new Microsoft.Web.Services2.Security.Tokens.UsernameToken(user, Config.PlainToSHA1(password), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone));
            webserviceObject.LogHeaderValue.LogGuid = "AAAAA";
            try
            {
                XmlNode node = webserviceObject.VerificaVABIS2(1, 081052,"", 27, "", "", 0);          
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(node.OuterXml);
                doc.Save(@"c:\dev1\ROOTPRJ\outxml.xml");
                TextResult.Text = doc.OuterXml;
               
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                TextResult.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NVA webserviceObject = new NVA();
            webserviceObject.LogHeaderValue = new TestPAWeb.WebReference.LogHeader();
            string internalPW = "comunediroma2007";
            string user = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalAccount"), internalPW);
            string password = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalPassword"), internalPW);
            webserviceObject.Url = ConfigurationManager.AppSettings["URL"];           
            webserviceObject.RequestSoapContext.Security.Tokens.Add(new Microsoft.Web.Services2.Security.Tokens.UsernameToken(user, Config.PlainToSHA1(password), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone));
            webserviceObject.LogHeaderValue.LogGuid = "AAAAA";
            try
            {

                //XmlNode node = webserviceObject.VerificaAutoCertificazione(3,"","M","Ruberto","",0,0,1974,01,01,1900,1);
                //       XmlNode node = webserviceObject.VerificaAutoCertificazione(3,"", "F", "Imperi", "Elisa", 0, 0, 1986, 01, 01, 1900, 0);
                //
                //  XmlNode node = webserviceObject.VerificaAnagrafica(3, "", "", "M", "RUBERTO", "NICO", 0, 0,1974, 0);
                //   XmlNode node = webserviceObject.VerificaAnagraficaEstesa("M", "ROSSINI", "PAOLO", 1978, 1978, "", "", "", "", 0);
                // XslCompiledTransform xslt = new XslCompiledTransform();
                // xslt.Load(@"C:\UnisysComponents\PortalexsltDecrypt\PRESVA2.xslt");
                XmlDocument doc = new XmlDocument();
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender1, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                //  XmlNode node = webserviceObject.VerificaAnagraficaSuper(1, "15079204", "", "", "", "", 0, 0, 0, 0);
                XmlNode node = webserviceObject.VerificaAnagrafica(1, "19465638", "", "", "", "", 0, 0, 0, 0);
                //   XmlNode node = webserviceObject.VerificaAnagrafica(3, "", "", "M", "ROSSI", "", 0, 0, 1970, 0);
                // XmlNode node = webserviceObject.VerificaDomiciliatiperIndirizzo(1, 081052, "", 27, "", "", "", "", "", "", "", 1);
                //  XmlNode node = webserviceObject.VerificaAnagrafica(1, "29974900", "", "", "", "", 0, 0, 0, 0);
                // XmlNode node = webserviceObject.VerificaStoricoFamigliaXData(2, "", "FLRCRL65A03H501X", "", "", "",0,0,0, 10, 09,2018, 0);
                //   XmlNode node = webserviceObject.VerificaAnagrafica(1, "00001403", "", "", "", "", 0, 0,0, 0);
                //  XmlNode node = webserviceObject.VerificaAnagrafica(1, "26250923", "PRTGTA60E71H501B", "", "", "", 0, 0, 0, 0);
                // XmlNode node = webserviceObject.VerificaStoricaDocumenti(1, "28334592", "PRTGTA60E71H501B", "", "", "", 0, 0, 0,1);
                //  XmlNode node = webserviceObject.VerificaDomXRangeCivici(1,1,081052,"",27,27,"","","","","","",1);
                // XmlNode node = webserviceObject.VerificaPatente(1, "14977688", "", "", "", "", 0, 0, 0, "","",1);
                doc.LoadXml(node.OuterXml);
                doc.Save(@"c:\test\statofamiglia_" + "4F549569" + ".xml");
                TextResult.Text = doc.OuterXml;
                //XmlWriter x = XmlWriter.Create(@"c:\dev\outxml.xml");
                //   node.WriteTo(x);
                //   x.WriteStartDocument();
                //   x.WriteEndDocument();

                // Execute the transform and output the results to a file.
                // xslt.Transform(@"c:\dev\outxml.xml", @"c:\dev\book.html");            
                //XmlNode node = webserviceObject.VerificaCRI(1, "26250924", "", "", "", "", 0, 0, 0, 0, 0, 0);
                //XmlNode node = webserviceObject.VerificaAutoCertificazione(1, "99", "", "M", "Ferro", "", 0, 0, 1970,"RM3992175F", 0);
                //     XmlNode node = webserviceObject.VerificaPatente(3, "", "", "M", "Ruberto", "", 0, 0, 1974,"","BE959XL", 0);
                // XmlNode node = webserviceObject.VerificaDomiciliatiperIndirizzo(1, 075103, "", 64, "", "", "", "", "DD", "", "10", 1);

                //   result.Text = node.InnerXml;

                //XDocument doc = XDocument.Load(@"C:\Users\Admin\Documents\va.xml");              
                //XmlSchemaSet schemas = new XmlSchemaSet();
                //schemas.Add(null, @"C:\Users\Admin\Documents\DocumentiProgetti\XSD\NETVA2.xsd");
                //Validazione.Text ="Attempting to validate";   
                //doc.Validate(schemas, (o, ep) =>
                //{
                //   Validazione.Text = ep.Message;                  
                //});
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            finally
            {
                
            }

        }


        private static bool ValidateCertificateCallback(object sender, X509Certificate certificate,
                                                X509Chain chain, SslPolicyErrors policyErrors)
        {
            // When running the developer mode, ignore all type of SSL connection error
            if (System.Configuration.ConfigurationManager.AppSettings["developMode"] == "true")
                return true;
            else
                // Return true only if there are no SSL Policy errors
                return policyErrors == SslPolicyErrors.None;
        }



        protected void ButtonNETSEPP_Click(object sender, EventArgs e)
        {
            NVA webserviceObject = new NVA();
            webserviceObject.LogHeaderValue = new TestPAWeb.WebReference.LogHeader();
            string internalPW = "comunediroma2007";
            string user = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalAccount"), internalPW);
            string password = Encryption.Decrypt(ConfigurationSettings.AppSettings.Get("PortalPassword"), internalPW);
            webserviceObject.Url = ConfigurationManager.AppSettings["URL"];
            webserviceObject.RequestSoapContext.Security.Tokens.Add(new Microsoft.Web.Services2.Security.Tokens.UsernameToken(user, Config.PlainToSHA1(password), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone));
            webserviceObject.LogHeaderValue.LogGuid = "AAAAA";
            try
            {
                //XmlNode node = webserviceObject.VerificaAutoCertificazione(3,"","M","Ruberto","",0,0,1974,01,01,1900,1);
                //       XmlNode node = webserviceObject.VerificaAutoCertificazione(3,"", "F", "Imperi", "Elisa", 0, 0, 1986, 01, 01, 1900, 0);
                // XmlNode node = webserviceObject.VerificaAnagrafica(1, "29974900", "", "", "", "", 0, 0, 0, 0);
                XmlNode node = webserviceObject.VerificaAutSepoltura(1, "13656797", "", "", "", "", 0, 0, 0, 0);
                // XslCompiledTransform xslt = new XslCompiledTransform();
                // xslt.Load(@"C:\UnisysComponents\PortalexsltDecrypt\PRESVA2.xslt");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(node.OuterXml);
                doc.Save(@"c:\dev\outxml.xml");
                TextResult.Text = doc.OuterXml;
                //XmlWriter x = XmlWriter.Create(@"c:\dev\outxml.xml");
                //   node.WriteTo(x);
                //   x.WriteStartDocument();
                //   x.WriteEndDocument();

                // Execute the transform and output the results to a file.
                // xslt.Transform(@"c:\dev\outxml.xml", @"c:\dev\book.html");            
                //XmlNode node = webserviceObject.VerificaCRI(1, "26250924", "", "", "", "", 0, 0, 0, 0, 0, 0);
                //XmlNode node = webserviceObject.VerificaAutoCertificazione(1, "99", "", "M", "Ferro", "", 0, 0, 1970,"RM3992175F", 0);
                //     XmlNode node = webserviceObject.VerificaPatente(3, "", "", "M", "Ruberto", "", 0, 0, 1974,"","BE959XL", 0);
                // XmlNode node = webserviceObject.VerificaDomiciliatiperIndirizzo(1, 075103, "", 64, "", "", "", "", "DD", "", "10", 1);

                //   result.Text = node.InnerXml;

                //XDocument doc = XDocument.Load(@"C:\Users\Admin\Documents\va.xml");              
                //XmlSchemaSet schemas = new XmlSchemaSet();
                //schemas.Add(null, @"C:\Users\Admin\Documents\DocumentiProgetti\XSD\NETVA2.xsd");
                //Validazione.Text ="Attempting to validate";   
                //doc.Validate(schemas, (o, ep) =>
                //{
                //   Validazione.Text = ep.Message;                  
                //});
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
    }
}
