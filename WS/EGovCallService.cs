using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

/// <summary>
/// Summary description for EGovCallService
/// </summary>
/// 

namespace Unisys.CdR.WS.ServiziAnagrafici.EGOV
{

    public class EGovCallService
    {
        public EGovCallService()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public XmlDocument VerificaAnagrafica(XmlDocument xmlRequest, string logid)
        {

            EGovUtility egovu = new EGovUtility();
            string nome = "";
            string cognome = "";
            short anno = 0;
            byte giorno = 0;
            byte mese = 0;
            string cf = "";
            string cind = "0";
            string errori = null;
            byte level = 0;
            string sesso = "";
            XmlDocument docNav = new XmlDocument();
            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
            nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
            XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
            byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
            if (TipoInterr.ToString() == "3")
            {
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                nome = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                cognome = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                sesso = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                giorno = Byte.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                mese = Byte.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                anno = Int16.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                level = Byte.Parse(nodelist[0].InnerText);
            
            }

            if (TipoInterr.ToString() == "2")
            {

                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                cf = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                level = Byte.Parse(nodelist[0].InnerText);
            

            }

            if (TipoInterr.ToString() == "1")
            {
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                cind = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagrafica/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                level = Byte.Parse(nodelist[0].InnerText);
            

            }

            // errori = egovu.CheckCampi(cognome, sesso, anno);
            System.Web.HttpContext.Current.Items.Add("logheader", logid);
            Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
            docNav = _verifiche.VerificaAnagrafica(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
            return docNav;
          
        }


     public XmlDocument VerificaStoricaDocumenti(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                byte level = 0;
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaStoricaDocumenti(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }


        public XmlDocument VerificaCri(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                byte level = 0;
                short annprt = 0;
                int numprt = 0;
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "10")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerPratica/AnnoPratica";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    annprt = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerPratica/NumeroPratica";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    numprt = Int32.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaCri(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, annprt, numprt, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;
        }

        public XmlDocument VerificaAnagraficaStorica(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                byte level = 0;
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaStorica/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaStoricaIndividuo(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


           

        }

        public XmlDocument VerificaAnagraficaSuper(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                byte level = 0;
                string sesso = "";
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaSuper/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaAnagraficaSuper(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;
               

        }

        public XmlDocument VerificaAnagraficaCached(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                byte level = 0;
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaCached/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaAnagraficaCached(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;



        }

        public XmlDocument VerificaLeggeRutelli(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                byte level = 0;
                string sesso = "";
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLeggeRutelli/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaLeggeRutelli(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;




        }

        public XmlDocument VerificaAnagraficaEstesa(XmlDocument xmlRequest, string logid)
        {

            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short annoda = 0;
                short annoa = 0;
                string pat = "";
                string mat = "";
                string dom = "";
                string comnsc = "";
                string sesso = "";
                string errori = null;
                byte level = 0;
                 XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/Nome";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                nome = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/Cognome";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                cognome = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/Sesso";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                sesso = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/AnnoDa";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                annoda = Int16.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/AnnoA";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                annoa = Int16.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/Paternita";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                pat = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/Maternita";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                mat = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/TipoRicerca/RicercaPerDatiAnagraficiEstesi/Domicilio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                dom = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaAnagraficaEstesa/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                level = Byte.Parse(nodelist[0].InnerText);

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaAnagraficaEstesa(sesso, cognome, nome, annoda, annoa, pat, mat, dom, comnsc, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;

        }

        public XmlDocument VerificaCartaIdent(XmlDocument xmlRequest, string logid)
        {

            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                byte level = 0;
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCartaIdent/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaCartaIdent(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;



        }

        public XmlDocument VerificaDocumenti(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string sesso = "";
                string cind = "";
                byte level = 0;
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDocumenti/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaDocumenti(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;



        }

        public XmlDocument VerificaStoricoFamigliaXData(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                short annorif = 0;
                byte giornorif = 0;
                byte meserif = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                byte level = 0;
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/DataRiferimento/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giornorif = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/DataRiferimento/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    meserif = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerDatiAnagraficiStorica/DataRiferimento/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    annorif = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceFiscaleStorica/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceFiscaleStorica/DataRiferimento/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giornorif = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceFiscaleStorica/DataRiferimento/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    meserif = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceFiscaleStorica/DataRiferimento/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    annorif = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceIndividualeStorica/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceIndividualeStorica/DataRiferimento/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giornorif = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceIndividualeStorica/DataRiferimento/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    meserif = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/TipoRicerca/RicercaPerCodiceIndividualeStorica/DataRiferimento/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    annorif = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStoricoFamigliaXData/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaStoricoFamigliaXData(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, giornorif, meserif, annorif, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }

        public XmlDocument VerificaElettorale(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                byte level = 0;
                string sesso = "";
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaElettorale/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaElettorale(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;




        }

     //   public XmlDocument VerificaSezioneElettorale(XmlDocument xmlRequest)
       // {
            // XmlDocument docNav = _verifiche.VerificaCri(TipoInterr, codiceindividuale.ToString(), codicefiscale, sesso, cognome, nome, giorno, mese, anno, 0,0, level);

      //  }

        public XmlDocument VerificaCI(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string ci = "";
                string errori = null;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCI/TipoRicerca/RicercaPerCI/NumeroCartaIdentita";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                ci = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaCI/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte level = Byte.Parse(nodelist[0].InnerText);
                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaCI(ci, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }

        public XmlDocument VerificaDomXRangeCivici(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                int codicevia = 0;
                string denominazionevia = "";
                short civda = 0;
                short civa = 0;
                string lottoda = "";
                string lottoa = "";
                string palazzinada = "";
                string palazzinaa = "";
                string kmda = "";
                string kma = "";
                byte level = 0;
                byte TipoRange = 0;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "14")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/CodiceVIA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    codicevia = Int32.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/NumeroCivicoDa";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civda = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/NumeroCivicoA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civa = Int16.Parse(nodelist[0].InnerText);
                    if (civda.ToString() != "")
                    {
                        TipoRange = 1;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/LottoDA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lottoda = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/LottoA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lottoa = nodelist[0].InnerText;
                    if (lottoda.ToString() != "")
                    {
                        TipoRange = 2;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/PalazzinaDA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzinada = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/PalazzinaA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzinaa = nodelist[0].InnerText;
                    if (palazzinada.ToString() != "")
                    {
                        TipoRange = 4;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/KilometroDA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    kmda = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerCodiceVIARange/KilometroA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    kma = nodelist[0].InnerText;
                    if (kmda.ToString() != "")
                    {
                        TipoRange = 4;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);
                    TipoInterr = 1;

                }

                if (TipoInterr.ToString() == "15")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/DenominazioneVIA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    denominazionevia = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/NumeroCivicoDa";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civda = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/NumeroCivicoA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civa = Int16.Parse(nodelist[0].InnerText);
                    if (civda.ToString() != "" && civda.ToString() != "0")
                    {
                        TipoRange = 1;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/LottoDA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lottoda = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/LottoA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lottoa = nodelist[0].InnerText;
                    if (lottoda.ToString() != "")
                    {
                        TipoRange = 2;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/PalazzinaDA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzinada = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/PalazzinaA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzinaa = nodelist[0].InnerText;
                    if (palazzinada.ToString() != "")
                    {
                        TipoRange = 3;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/KilometroDA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    kmda = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/TipoRicerca/RicercaPerDenominazioneVIARange/KilometroA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    kma = nodelist[0].InnerText;
                    if (kmda.ToString() != "")
                    {
                        TipoRange = 4;
                    }
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomXRangeCivici/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);
                    TipoInterr = 2;
                }



                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaDomXRangeCivici(TipoInterr, TipoRange, codicevia, denominazionevia, civda, civa, lottoda, lottoa, palazzinada, palazzinaa, kmda, kma, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }


        public XmlDocument VerificaDomiciliatiperIndirizzo(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                int codicevia = 0;
                string denominazionevia = "";
                short civ = 0;
                string lotto = "";
                string palazzina = "";
                string km = "";
                string piano = "";
                string interno = "";
                string scala = "";
                string lettera = "";
                byte level = 0;
                byte TipoRange = 0;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "11")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/CodiceVIA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    codicevia = Int32.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/NumeroCivico";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civ = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Lotto";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lotto = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Palazzina";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzina = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Kilometro";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    km = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Lettera";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lettera = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Piano";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    scala = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Scala";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    piano = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Interno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    interno = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);
                    TipoRange = 1;

                }

                if (TipoInterr.ToString() == "12")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/DenominazioneVIA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    denominazionevia = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/NumeroCivico";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civ = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Lotto";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lotto = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Palazzina";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzina = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Kilometro";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    km = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Lettera";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lettera = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Piano";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    piano = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Scala";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    scala = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Interno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    interno = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);
                    TipoRange = 2;

                }
                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaDomiciliatiperIndirizzo(TipoRange, codicevia, denominazionevia, civ, lettera, lotto, palazzina, km, scala, piano, interno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }

        public XmlDocument VerificaDomiciliatiperIndirizzoeFamiglia(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                int codicevia = 0;
                string denominazionevia = "";
                short civ = 0;
                string lotto = "";
                string palazzina = "";
                string km = "";
                string piano = "";
                string interno = "";
                string scala = "";
                string lettera = "";
                byte level = 0;
                byte TipoRange = 0;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "11")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/CodiceVIA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    codicevia = Int32.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/NumeroCivico";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civ = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Lotto";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lotto = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Palazzina";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzina = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Kilometro";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    km = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Lettera";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lettera = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Piano";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    scala = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Scala";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    piano = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerCodiceVIA/Interno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    interno = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);
                    TipoRange = 1;

                }

                if (TipoInterr.ToString() == "12")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/DenominazioneVIA";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    denominazionevia = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/NumeroCivico";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    civ = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Lotto";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lotto = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Palazzina";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    palazzina = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Kilometro";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    km = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Lettera";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    lettera = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Piano";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    piano = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Scala";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    scala = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/TipoRicerca/RicercaPerDenominazioneVIA/Interno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    interno = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaDomiciliatiperIndirizzo/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);
                    TipoRange = 2;

                }
                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaDomiciliatiperIndirizzoeFamiglia(TipoRange, codicevia, denominazionevia, civ, lettera, lotto, palazzina, km, scala, piano, interno, level);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }

        public XmlDocument VerificaVaccinazioni(XmlDocument xmlRequest, string logid)
        {

            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                string errori = null;
                byte level = 0;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaVaccinazioni/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaVaccinazioni(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;
          

        }

        public XmlDocument VerificaLevaMilitare(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string errori = null;
                string sesso = "";
                byte level = 0;
                 XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaLevaMilitare/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaLevaMilitare(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;

        }

        public XmlDocument VerificaStatoFamigliaConv(XmlDocument xmlRequest, string logid)
        {

            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string sesso = "";
                string errori = null;
                byte level = 0;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaStatoFamigliaConv/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaStatoFamigliaConv(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }

        public XmlDocument VerificaSitFamigliaConv(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();
            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string cf = "";
                string cind = "";
                string errori = null;
                string sesso = "";
                byte level = 0;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind =nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaSitFamigliaConv/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaSitFamigliaConv(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;

        }
        public XmlDocument VerificaPerm(XmlDocument xmlRequest, string logid)
        {
            XmlDocument docNav = new XmlDocument();

            try
            {
                EGovUtility egovu = new EGovUtility();
                string nome = "";
                string cognome = "";
                short anno = 0;
                byte giorno = 0;
                byte mese = 0;
                string sesso = "";
                string cf = "";
                string cind = "";
                string errori = null;
                string permsog = "";
                string temp = "";
                int numprt = 0;
                short annprt = 0;
                byte level = 0;
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
                nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
                XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
                if (TipoInterr.ToString() == "3")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    nome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cognome = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    sesso = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    giorno = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    mese = Byte.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    anno = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                if (TipoInterr.ToString() == "2")
                {

                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cf = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "1")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    cind = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }


                if (TipoInterr.ToString() == "7")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerPermesso/NumeroPermessoSogg";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    permsog = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "8")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerAttestato/NumeroAttestato";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    temp = nodelist[0].InnerText;
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);


                }

                if (TipoInterr.ToString() == "10")
                {
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerPratica/AnnoPratica";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    annprt = Int16.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/TipoRicerca/RicercaPerPratica/NumeroPratica";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    numprt = Int32.Parse(nodelist[0].InnerText);
                    strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaPerm/LivelloServizio";
                    nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                    level = Byte.Parse(nodelist[0].InnerText);

                }

                // errori = egovu.CheckCampi(cognome, sesso, anno);
                System.Web.HttpContext.Current.Items.Add("logheader", logid);
                Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
                docNav = _verifiche.VerificaPerm(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, annprt, numprt, temp, permsog, level);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return docNav;


        }

        public XmlDocument VerificaNullaOstaCI(XmlDocument xmlRequest, string logid)
        {

            EGovUtility egovu = new EGovUtility();
            string nome = "";
            string cognome = "";
            short anno = 0;
            byte giorno = 0;
            byte mese = 0;
            string cf = "";
            string cind = "0";
            string errori = null;
            byte level = 0;
            string sesso = "";
            XmlDocument docNav = new XmlDocument();
            XmlNamespaceManager nsmanager = new XmlNamespaceManager(xmlRequest.NameTable);
            nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            string strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/TipoRichiestaCodice";
            XmlNodeList nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
            byte TipoInterr = Byte.Parse(nodelist[0].InnerText);
            if (TipoInterr.ToString() == "3")
            {
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerDatiAnagrafici/Nome";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                nome = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerDatiAnagrafici/Cognome";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                cognome = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerDatiAnagrafici/Sesso";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                sesso = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Giorno";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                giorno = Byte.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Mese";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                mese = Byte.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerDatiAnagrafici/DataDiNascita/Anno";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                anno = Int16.Parse(nodelist[0].InnerText);
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                level = Byte.Parse(nodelist[0].InnerText);

            }

            if (TipoInterr.ToString() == "2")
            {

                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerCodiceFiscale/CodiceFiscale";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                cf = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                level = Byte.Parse(nodelist[0].InnerText);


            }

            if (TipoInterr.ToString() == "1")
            {
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/TipoRicerca/RicercaPerCodiceIndividuale/CodiceIndividuale";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                cind = nodelist[0].InnerText;
                strExpression = "Risposta/contenutoApplicativo/contenuto/Richiesta/RichiestaServizio/VerificaNullaOstaCI/LivelloServizio";
                nodelist = xmlRequest.SelectNodes(strExpression, nsmanager);
                level = Byte.Parse(nodelist[0].InnerText);


            }

            // errori = egovu.CheckCampi(cognome, sesso, anno);
            System.Web.HttpContext.Current.Items.Add("logheader", logid);
            Unisys.CdR.VerificheAnagrafiche.VA _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
            docNav = _verifiche.VerificaAnagrafica(TipoInterr, cind, cf, sesso, cognome, nome, giorno, mese, anno, level);
            return docNav;

        }


    }

}
