using INASaia.Model;
using INASaia.ServiceContracts;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Linq; 
using Unisys.CdR.RefreshCounters;

namespace Unisys.CdR.WS
{
    /// <summary>
    /// Summary description for Eventi
    /// </summary>
    [WebService(Description = "Interrogazioni Anagrafe Roma Capitale", Namespace = "http://saia.ancitel.it/xmlmanager/ap5"), SoapDocumentService(SoapBindingUse.Literal, SoapParameterStyle.Wrapped, RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    public class Eventi : System.Web.Services.WebService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Eventi));
        public Unisys.CdR.Servizi.Log.LogHeader LogHash;

        protected void ThrowSoapException(string msg, string errCode)
        {
            Unisys.CdR.Servizi.SoapExcepGest e = new Unisys.CdR.Servizi.SoapExcepGest(msg, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, errCode);

            throw e.Exception;
        }


        protected byte checkRights(string MethodCode, byte ClientServiceLevel)
        {


            Modifier modify = new Modifier("PORTA APPLICATIVA", false);
            object objectProfile = System.Web.HttpRuntime.Cache.Get(System.Web.HttpContext.Current.User.Identity.Name);
            if ((objectProfile != null))
            {
                Unisys.CdR.CustomProfile.UserProfile upro = (Unisys.CdR.CustomProfile.UserProfile)objectProfile;
                Int16 liv = default(Int16);
                try
                {
                    liv = upro.Principal.get_IsServiceAssigned(MethodCode);

                }
                catch (Exception ex)
                {
                    modify.IncrementCounter("Errori autenticazione/sec");
                    Unisys.CdR.WS.Verifiche.Condivise.traccia("Profilo utente corrotto o anomalo", ex.Message, "Unisys.CdR.WS.Verifiche.GenericVA.checkRights");
                }
                if (liv == -99)
                {
                    modify.IncrementCounter("Errori autenticazione/sec");
                    throw new Exception("Il profilo della porta delegata non è autorizzato a chiamare il servizio indicato: contattare l'amministratore del proprio sistema");
                }

                else if (liv < 0)
                {
                    modify.IncrementCounter("Errori autenticazione/sec");
                    throw new Exception("Il servizio richiesto è sospeso o non abilitato: contattare l'amministratore del proprio sistema");

                }


                if (liv < ClientServiceLevel)
                {
                    return (byte)liv;
                }
                else
                {
                    return ClientServiceLevel;
                }
            }
            else
            {
                modify.IncrementCounter("Errori autenticazione/sec");
                throw new Exception("Impossibile verificare l'identità del client (token di sicurezza non trovato)");

            }

        }

        [WebMethod(Description = "Eventi anagrafici per Giorno e Tipologia Evento"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VariazioniAnagrafiche(int Giorno, int Mese, int Anno, string CodiceEvento, byte ServiceLevel)
        {

            // System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            System.Web.HttpContext.Current.Items.Add("logheader", "nico");
            _log.Debug("1");
            XDocument xdoc = XDocument.Parse("<Elenco></Elenco>");
            XmlDocument xml = new XmlDocument();
            try
            {               
                string dataInizio = string.Empty;
                DateTime today = new DateTime(Anno, Mese, Giorno);
                List<Comunicazione> list = ServiceLocator.GetServiceFactory().EventoService.GetComunicazionebyDataEvento(CodiceEvento, today.ToString("dd/MM/yyyy"), today.AddDays(1).ToString("dd/MM/yyyy"));
                List<string> l = (from x in list
                                  select x.XmlDocument).ToList();
                for (int j = 0; j < l.Count; j++)
                {

                    string x = l[j].Replace("<ns0:", "<ap5:");
                    x = x.Replace("/ns0:", "/ap5:");
                    XElement xel = XElement.Parse(x);
                    xdoc.Root.Add(xel);
                }               
                using (var xmlReader = xdoc.CreateReader())
                {
                    xml.Load(xmlReader);
                }                
            }
            catch (Exception erro)
            {
                _log.Debug(erro.Message);
                _log.Debug(erro.StackTrace);
                _log.Debug(erro.Source);
                _log.Debug(erro.TargetSite);
                _log.Debug(erro.InnerException);
                throw new SoapException(erro.Message, null);
            }
            return xml;
        }


    }
}
