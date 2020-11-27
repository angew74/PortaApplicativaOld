using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using Microsoft.Italy.EASI;
using System.Xml;
using System.Configuration;


namespace Unisys.CdR.WS.Verifiche
{



    [WebService(Namespace = "http://servizi.comune.roma.it/verificheanagrafiche")]
    [SoapDocumentService(System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped, RoutingStyle = SoapServiceRoutingStyle.SoapAction)]
    public class nvaegov : Microsoft.Italy.EASI.Wse.PortaApplicativaSec
    {

        
        public nvaegov() : base() {

           
           
            string configFile = ConfigurationManager.AppSettings["PortaConfig"];
            this.LoadConfig(configFile);
            
        }


        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "WebMethod", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        [return: System.Xml.Serialization.XmlText]
        [return: System.Xml.Serialization.XmlAnyElement]
        public override XmlNode[] WebMethod([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            
            return base.WebMethod(richiesta);
        }


     
        // Verifica Anagrafica 
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaAnagrafica", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaAnagrafica([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
           return base.WebMethod(richiesta);
        }
        

        // Verifica Anagrafica Estesa
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaAnagraficaEstesa", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaAnagraficaEstesa([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Documenti
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaDocumenti", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaDocumenti([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Carta Identita
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaCartaIdent", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaCartaIdent([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Leva Militare 
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaLevaMilitare", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
         public XmlNode[] VerificaLevaMilitare([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Stato Famiglia Convivenza
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaStatoFamigliaConv", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaStatoFamigliaConv([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Storica Documenti
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaStoricaDocumenti", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaStoricaDocumenti([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Storica Individuo
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaAnagraficaStorica", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaAnagraficaStorica([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Vaccinazioni
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaVaccinazioni", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaVaccinazioni([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Domiciliati per Indirizzo
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaDomiciliatiperIndirizzo", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaDomiciliatiperIndirizzo([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Domiciliati per Indirizzo
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaDomiciliatiperIndirizzoeFamiglia", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaDomiciliatiperIndirizzoeFamgilia([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }


        // Verifica Domiciliati per Range Civici
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaDomXRangeCivici", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaDomXRangeCivici([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }



        // Verifica per Carta d'Identità
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaCI", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaCartaId([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica Elettorale
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaElettorale", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaElettorale([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }


        // Verifica storico Famiglia per Data
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaStoricoFamigliaXData", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        //[return: System.Xml.Serialization.XmlText]
        // [return: System.Xml.Serialization.XmlAnyElement]
        public XmlNode[] VerificaStoricoFamigliaXData([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica permesso di soggiorno
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaPerm", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        //[return: System.Xml.Serialization.XmlText]
        // [return: System.Xml.Serialization.XmlAnyElement]
        public XmlNode[] VerificaPerm([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica situazione famiglia o convivenza
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaSitFamigliaConv", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        //[return: System.Xml.Serialization.XmlText]
        //[return: System.Xml.Serialization.XmlAnyElement]
        public XmlNode[] VerificaSitFamigliaConv([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }

        // Verifica cambi di residenza
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaCRI", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        //[return: System.Xml.Serialization.XmlText]
        //[return: System.Xml.Serialization.XmlAnyElement]
        public XmlNode[] VerificaCRI([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }


        // Verifica Nulla osta CartaID 
        [WebMethod]
        [SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
        [SoapDocumentMethodAttribute(Action = "VerificaNullaOstaCI", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [PortaApplicativaAttribute(Priority = 10)]
        public XmlNode[] VerificaNullaOstaCI([System.Xml.Serialization.XmlText][System.Xml.Serialization.XmlAnyElement] XmlNode[] richiesta)
        {
            return base.WebMethod(richiesta);
        }



        [WebMethod(),
       SoapHeader("IntestazioneValue", Direction = SoapHeaderDirection.InOut | SoapHeaderDirection.Fault),
       SoapDocumentMethodAttribute(Action = "WebMethodOneWay", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare),
       PortaApplicativaAttribute(Priority = 2)]

        public override void WebMethodOneWay(XmlNode[] richiesta)
        {
            base.WebMethod(richiesta);
        }



        protected override MessaggioEGovernment Receive(MessaggioEGovernment richiesta)
        {
            // leggo il servizio chiamato
            // string Azione = richiesta.Intestazione.Azione;
            string NomeServizio = richiesta.Intestazione.Servizio.Value;
            string errori = null;
            // leggo i campi per la creazione del messaggio di risposta
            nvaegov porta = new nvaegov();
            MessaggioEGovernment risposta = porta.GetDefaultMessaggioEGovernment();
            string profilocollaborazione = richiesta.Intestazione.ProfiloCollaborazione.Value.ToString();
            risposta.Intestazione.Destinatario = richiesta.Intestazione.Mittente[0];
            risposta.Intestazione.Messaggio.RiferimentoMessaggio = richiesta.Intestazione.Messaggio.Identificatore;
            string logid = richiesta.Intestazione.Messaggio.Identificatore;
            string Azione = richiesta.Intestazione.Azione;
            // carico lo schema per validare la richiesta
            // porta.SchemaContenutoApplicativo.LoadFromFile(ConfigurationManager.AppSettings["XSDSchema"]);
            // porta.ValidateRequest();
            Unisys.CdR.WS.ServiziAnagrafici.EGOV.EGovUtility egovu = new Unisys.CdR.WS.ServiziAnagrafici.EGOV.EGovUtility();
            Unisys.CdR.WS.ServiziAnagrafici.EGOV.EGovCallService egos = new Unisys.CdR.WS.ServiziAnagrafici.EGOV.EGovCallService();
            if (egovu.CheckServizio(Azione) == false)
            {
                errori = "Servizio non riconosciuto";
                Eccezione eccezione = new Eccezione("Azione non riconosciuta", Eccezione.CodiceEccezioneEnum.EGOV_IT_105, Eccezione.EccezioneRilevanzaEnum.GRAVE, "prova");
                risposta.Intestazione.ListaEccezioni.Add(eccezione);

            }
            
            if (Azione != NomeServizio)
            {
                errori = "Azione diversa dal Servizio";
                Eccezione eccezione = new Eccezione("Azione diversa dal Servizio richiesto", Eccezione.CodiceEccezioneEnum.EGOV_IT_105, Eccezione.EccezioneRilevanzaEnum.GRAVE, "prova");
                risposta.Intestazione.ListaEccezioni.Add(eccezione);
            }
            
            if (egovu.CheckServizio(NomeServizio) == false)
            {
                errori = "Servizio non riconosciuto";
                Eccezione eccezione = new Eccezione("Servizio non riconosciuto", Eccezione.CodiceEccezioneEnum.EGOV_IT_105, Eccezione.EccezioneRilevanzaEnum.GRAVE, "prova");
                risposta.Intestazione.ListaEccezioni.Add(eccezione);
            }
            // il profilo di collaborazione
            if (profilocollaborazione != ProfiloCollaborazione.ProfiloEnum.EGOV_IT_ServizioSincrono.ToString())
            {
                errori = errori + " Profilo Collaborazione errato";
                Eccezione eccezione = new Eccezione("Profilo Collaborazione errato", Eccezione.CodiceEccezioneEnum.EGOV_IT_103, Eccezione.EccezioneRilevanzaEnum.GRAVE, "prova");
                risposta.Intestazione.ListaEccezioni.Add(eccezione);

            }
            // l'intestazione del destinatario
            if (richiesta.Intestazione.Destinatario.Tipo != "058091" || richiesta.Intestazione.Destinatario.Value != "Comune di Roma")
            {
                errori = errori + " Destinatario Errato";
                Eccezione eccezione = new Eccezione("Destinatario Errato", Eccezione.CodiceEccezioneEnum.EGOV_IT_102, Eccezione.EccezioneRilevanzaEnum.GRAVE, "prova");
                risposta.Intestazione.ListaEccezioni.Add(eccezione);
            }
            XmlDocument xmlRequest = new XmlDocument();
            XmlDocument xmlResp = new XmlDocument();
            // spacchetto la richiesta
            XmlElement Risposta = xmlRequest.CreateElement("Risposta");
            xmlRequest.AppendChild(Risposta);
            XmlNode xnode = richiesta.ContenutoApplicativo[0];
            XmlNode xnodeReqRoot = xmlRequest.DocumentElement;
            XmlNode xnodeImp = xmlRequest.ImportNode(xnode, true);
            xnodeReqRoot.AppendChild(xnodeImp);
            // verifico il body 
            if (xmlRequest.InnerText == null)
            {
                errori = " Body Vuoto";
                Eccezione eccezione = new Eccezione("Body vuoto", Eccezione.CodiceEccezioneEnum.EGOV_IT_003, Eccezione.EccezioneRilevanzaEnum.GRAVE, "prova");
                risposta.Intestazione.ListaEccezioni.Add(eccezione);
            }
            // se non ci sono errori chiamo servizio
            if (errori == null)
            {

                switch (NomeServizio)
                {
                    case "VerificaAnagrafica":
                        xmlResp = egos.VerificaAnagrafica(xmlRequest, logid);
                        break;
                    case "VerificaStoricaDocumenti":
                        xmlResp = egos.VerificaStoricaDocumenti(xmlRequest, logid);
                        break;
                    case "VerificaCri":
                        xmlResp = egos.VerificaCri(xmlRequest, logid);
                        break;
                    case "VerificaAnagraficaStorica":
                        xmlResp = egos.VerificaAnagraficaStorica(xmlRequest, logid);
                        break;
                    case "VerificaAnagraficaSuper":
                        xmlResp = egos.VerificaAnagraficaSuper(xmlRequest, logid);
                        break;
                    case "VerificaAnagraficaCached":
                        xmlResp = egos.VerificaAnagraficaCached(xmlRequest, logid);
                        break;
                    case "VerificaLeggeRutelli":
                        xmlResp = egos.VerificaLeggeRutelli(xmlRequest, logid);
                        break;
                    case "VerificaAnagraficaEstesa":
                        xmlResp = egos.VerificaAnagraficaEstesa(xmlRequest, logid);
                        break;
                    case "VerificaCartaIdent":
                        xmlResp = egos.VerificaCartaIdent(xmlRequest, logid);
                        break;
                    case "VerificaDocumenti":
                        xmlResp = egos.VerificaDocumenti(xmlRequest, logid);
                        break;
                    case "VerificaStoricoFamigliaXData":
                        xmlResp = egos.VerificaStoricoFamigliaXData(xmlRequest, logid);
                        break;
                    case "VerificaElettorale":
                        xmlResp = egos.VerificaElettorale(xmlRequest, logid);
                        break;
                    // case "VerificaSezioneElettorale":
                    //   xmlResp = egos.VerificaSezioneElettorale(xmlRequest);
                    //  break;
                    //case "VerificaLibrettiLavoro":
                    //  xmlResp = egos.VerificaLibrettiLavoro(xmlRequest);
                    // break;
                    case "VerificaCI":
                        xmlResp = egos.VerificaCI(xmlRequest, logid);
                        break;
                    case "VerificaDomXRangeCivici":
                        xmlResp = egos.VerificaDomXRangeCivici(xmlRequest, logid);
                        break;
                    case "VerificaDomiciliatiperIndirizzo":
                        xmlResp = egos.VerificaDomiciliatiperIndirizzo(xmlRequest, logid);
                        break;
                    case "VerificaDomiciliatiperIndirizzoeFamiglia":
                        xmlResp = egos.VerificaDomiciliatiperIndirizzoeFamiglia(xmlRequest, logid);
                        break;
                    case "VerificaVaccinazioni":
                        xmlResp = egos.VerificaVaccinazioni(xmlRequest, logid);
                        break;
                    case "VerificaLevaMilitare":
                        xmlResp = egos.VerificaLevaMilitare(xmlRequest, logid);
                        break;
                    case "VerificaStatoFamigliaConv":
                        xmlResp = egos.VerificaStatoFamigliaConv(xmlRequest, logid);
                        break;
                    case "VerificaSitFamigliaConv":
                        xmlResp = egos.VerificaSitFamigliaConv(xmlRequest,logid);
                        break;
                    case "VerificaPerm":
                        xmlResp = egos.VerificaPerm(xmlRequest, logid);
                        break;
                    case "VerificaNullaOstaCI":
                        xmlResp = egos.VerificaNullaOstaCI(xmlRequest, logid);
                        break;

                }
                try
                {
                    //Response
                    risposta.Intestazione.Servizio = richiesta.Intestazione.Servizio;
                    risposta.Intestazione.Azione = richiesta.Intestazione.Azione;
                    // richiesta.Intestazione.Messaggio = new Messaggio(portaDelegata1.NewIdentificatore(), new OraRegistrazione(DateTime.Now, OraRegistrazione.TempoDiRiferimentoEnum.EGOV_IT_Locale));
                    risposta.ContenutoApplicativo.Add(xmlResp.OuterXml);

                }

                catch (Exception ex)
                {
                    throw new EccezioneEGovernment(ex.Message, Eccezione.CodiceEccezioneEnum.EGOV_IT_001, Eccezione.EccezioneRilevanzaEnum.GRAVE, ex.StackTrace);
                }
            }

            return risposta;
        }

        // override del LoadConfig per pescarlo in cache
        public override void LoadConfig(string fileName)
        {
            Unisys.CdR.CustomApplicationCache.Cache cache = Unisys.CdR.CustomApplicationCache.Cache.Instance;
            string portaconfig = "PortaCdr";
            object configObject = new object();
            configObject = cache.Get(portaconfig);
            string fileconfig = (string)configObject;
            if (configObject != null && configObject != "")
            {
                base.LoadConfig(fileconfig);
            }
            else
            {
                string fileperc = System.Configuration.ConfigurationSettings.AppSettings["PortaConfig"];
                cache.Insert(portaconfig, fileperc, CustomApplicationCache.CacheItemLifetime.Permanent);
                base.LoadConfig(fileperc);
            }
        }


        protected override void ReceiveOneWay(MessaggioEGovernment richiesta) { }

    }
}
