using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;
using WSPA.pri.Verifiche;

namespace WSPA
{
    [WebService(Description = "Interrogazione Anagrafe comunale", Namespace = "http://servizi.comune.roma.it/verificheanagrafiche"), SoapDocumentService(SoapBindingUse.Literal, SoapParameterStyle.Wrapped, RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    public class NVA : GenericVA
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(NVA));

        private Unisys.CdR.VerificheAnagrafiche.VA _verifiche;
        public Unisys.CdR.Servizi.Log.LogHeader LogHash;

        private enum valid
        {
            valido,
            nonvalido,
            zero
        }

        public enum RicercaPerIndirizzo : short
        {
            NumeroCivico = 1,
            Lotto,
            Palazzina,
            Kilometro
        }

        public NVA()
            : base()
        {
            _verifiche = new Unisys.CdR.VerificheAnagrafiche.VA();
        }


        [WebMethod(Description = "Effettua una verifica anagrafica completa"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaAnagrafica(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            try
            {

                return _verifiche.VerificaAnagrafica(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETVA2", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                _log.Error(erro.Message + " " + erro.InnerException + " " + erro.StackTrace);
                throw new SoapException(erro.Message, null);
            }

        }

        [WebMethod(Description = "Effettua una verifica per Autorizzazione alla Sepoltura"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaAutSepoltura(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {
            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            try
            {
                return _verifiche.VerificaAutSepoltura(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETSEPP", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                _log.Error(erro.Message + " " + erro.InnerException + " " + erro.StackTrace);
                throw new SoapException(erro.Message, null);
            }
        }

        [WebMethod(Description = "Effettua una verifica anagrafica completa"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaAnagraficaSuper(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel)
        {
            _log.Info("entry metodo supernetva");
            try
            {

                System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
                _log.Info("dopo add header");
                return _verifiche.VerificaAnagraficaSuper(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("SUPERNETVA", ServiceLevel));
            }
            catch (Exception erro)
            {
                _log.Info("eccezione");
                _log.Info(erro.Message);
                _log.Info(erro.StackTrace);
                if (erro.InnerException != null)
                {
                    _log.Info(erro.InnerException.Message);
                }
                throw new SoapException(erro.Message + " ST." + erro.StackTrace, null);
            }

        }


        [WebMethod(Description = "Interrogazione Dati CRI"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaCRI(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, Int16 AnnoPratica,
        Int16 NumeroPratica, byte ServiceLevel)
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {

                return _verifiche.VerificaCri(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, AnnoNascita, AnnoPratica,
                NumeroPratica, checkRights("NETCRI", ServiceLevel));
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }
        [WebMethod(Description = "Interrogazione Dati Documenti di Soggiorno"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaPerm(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, Int16 AnnoPratica,
        Int32 NumeroPratica, string NumAttestato, string NumPermesso, byte ServiceLevel)
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {

                return _verifiche.VerificaPerm(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, AnnoNascita, AnnoPratica,
                NumeroPratica, NumAttestato, NumPermesso, checkRights("NETPERM", ServiceLevel));
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }



        [WebMethod(Description = "Interrogazione per Legge Rutelli"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaLeggeRutelli(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaLeggeRutelli(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETRUTE", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Ricerca x arco temporale"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaAnagraficaEstesa(string Sesso, string Cognome, string Nome, Int16 AnnoIniziale, Int16 AnnoFinale, string Patern, string Matern, string Domicilio, string ComuneNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);


            try
            {
                return _verifiche.VerificaAnagraficaEstesa(Sesso, Cognome, Nome, AnnoIniziale, AnnoFinale, Patern, Matern, Domicilio, ComuneNascita, checkRights("NETVANB2", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Interrogazione documenti"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaDocumenti(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaDocumenti(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETVDOC2", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Individuale Carta di Identità"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaCartaIdent(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaCartaIdent(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETVCI2", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Posizione Elettorale"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaElettorale(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaElettorale(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETVELE", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Posizione Servizio Militare"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaLevaMilitare(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaLevaMilitare(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETILEM", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Situazione Famiglia e Convivenza"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaSitFamigliaConv(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaSitFamigliaConv(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETIFC", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Stato di Famiglia e Convivenza"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaStatoFamigliaConv(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaStatoFamigliaConv(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETVFC2", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Storico Documenti"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaStoricaDocumenti(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaStoricaDocumenti(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETVDOC12", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Storico Individuo"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaStoricaIndividuo(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel)
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaStoricaIndividuo(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETVSTO", ServiceLevel));
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Vaccinazioni"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaVaccinazioni(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaVaccinazioni(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETIVAC", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Ricerca Domiciliati per indirizzo"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaDomiciliatiperIndirizzo(byte TipoInterr, Int32 CodiceVia, string DenominazioneVia, Int16 Numero, string Lettera, string Lotto, string Palazzina, string Km, string Scala, string Piano,
        string Interno, byte ServiceLevel)
        {

            // System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            System.Web.HttpContext.Current.Items.Add("logheader", "nico");
            _log.Debug("1");

            try
            {
                return _verifiche.VerificaDomiciliatiperIndirizzo(TipoInterr, CodiceVia, DenominazioneVia, Numero, Lettera, Lotto, Palazzina, Km, Scala, Piano, Interno, checkRights("NETVABI", ServiceLevel));
            }
            catch (Exception erro)
            {

                _log.Debug("Faccio Throw soap exception");
                _log.Debug(erro.Message);
                throw new Exception(erro.Message, null);
            }

        }

        [WebMethod(Description = "Ricerca Domiciliati per indirizzo e Famiglia"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaDomiciliatiperIndirizzoeFamiglia(byte TipoInterr, Int32 CodiceVia, string DenominazioneVia, Int16 Numero, string Lettera, string Lotto, string Palazzina, string Km, string Scala, string Piano,
        string Interno, byte ServiceLevel)
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaDomiciliatiperIndirizzoeFamiglia(TipoInterr, CodiceVia, DenominazioneVia, Numero, Lettera, Lotto, Palazzina, Km, Scala, Piano, Interno, checkRights("NETATER", ServiceLevel));
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }


        }


        [WebMethod(Description = "Ricerca Domiciliati per intervallo di civici, lotti, palazzi o kilometri"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaDomXRangeCivici(byte TipoInterr, byte TipoRange, Int32 CodiceVia, string DenominazioneVia, Int16 NumeroDa, Int16 NumeroA, string LottoDa, string LottoA, string PalazzinaDa, string PalazzinaA,
        string KmDa, string KmA, byte ServiceLevel)
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaDomXRangeCivici(TipoInterr, TipoRange, CodiceVia, DenominazioneVia, NumeroDa, NumeroA, LottoDa, LottoA, PalazzinaDa, PalazzinaA,
                KmDa, KmA, checkRights("NETVABIR", ServiceLevel));
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Carta di Identità (ricerca carta)"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaCartaId(string Carta, byte ServiceLevel)
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaCI(Carta, checkRights("NETICID", ServiceLevel));
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }


        [WebMethod(Description = "Verifica Storico di Famiglia con ricerca per data"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaStoricoFamigliaXData(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte GiornoRif,
        byte MeseRif, Int16 AnnoRif, byte ServiceLevel)
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                _log.Debug("LOG VerificaStoricoFamigliaXData");
                if (String.IsNullOrEmpty(Sesso))
                { Sesso = string.Empty; }
                if (String.IsNullOrEmpty(Cognome))
                { Cognome = string.Empty; }
                if (String.IsNullOrEmpty(Nome))
                { Nome = string.Empty; }
                if (String.IsNullOrEmpty(CodiceFiscale))
                { CodiceFiscale = string.Empty; }
                if (String.IsNullOrEmpty(CodiceIndividuale))
                { CodiceIndividuale = string.Empty; }
                XmlDocument v = _verifiche.VerificaStoricoFamigliaXData(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, GiornoRif,
                MeseRif, AnnoRif, checkRights("NETVSTF", ServiceLevel));
                _log.Debug(v.InnerXml);
                _log.Debug("dopo LOG VerificaStoricoFamigliaXData");
                return v;
            }
            catch (Exception erro)
            {
                _log.Debug(erro.Message);
                throw new SoapException(erro.Message, null);
            }
        }

        [WebMethod(Description = "Verifica Nulla Osta CartaID"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaNullaOstaCI(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {
                return _verifiche.VerificaNullaOstaCI(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, checkRights("NETNOCI", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                throw new SoapException(erro.Message, null);
            }

        }

        [WebMethod(Description = "Verifica Patente"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaPatente(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 annoNascita, string numeroPatente, string numeroTarga, byte ServiceLevel
        )
        {

            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);

            try
            {

                XmlDocument doc = new XmlDocument();
                return _verifiche.VerificaPatente(TipoInterr, CodiceIndividuale, CodiceFiscale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, annoNascita, numeroPatente, numeroTarga, checkRights("NETIPAT", ServiceLevel)
                );
            }
            catch (Exception erro)
            {
                _log.Error(erro);
                throw new SoapException(erro.Message, null);
            }

        }

        [WebMethod(Description = "Verifica AutoCertificazione"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaAutoCertificazione(byte TipoInterr, string CodiceIndividuale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte GiornoRiferimento, byte MeseRiferimento, Int16 AnnoRiferimento, byte ServiceLevel
        )
        {


            try
            {
                _log.Debug("1");
                System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
                _log.Debug("2");
                XmlDocument doc = new XmlDocument();
                doc = _verifiche.VerificaAutoCertificazione(TipoInterr, CodiceIndividuale, Sesso, Cognome, Nome, GiornoNascita, MeseNascita, AnnoNascita, GiornoRiferimento, MeseRiferimento, AnnoRiferimento, checkRights("NETVAUT", ServiceLevel));
                _log.Debug(doc.InnerXml);
                return doc;

            }
            catch (Exception erro)
            {
                _log.Error(erro.Source);
                _log.Error(erro.StackTrace);
                _log.Error(erro.Message + " " + erro.InnerException.Message);
                throw new SoapException(erro.Message, null);
            }

        }

        [WebMethod(Description = "Ricerca Domiciliati per Inidirizzo in range VABIS"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaVABIS(byte TipoInterr, byte TipoRange, Int32 CodiceVia, string DenominazioneVia, Int32 NumeroDa, Int32 NumeroA, string LottoDa, string LottoA, string PalazzinaDa, string PalazzinaA,
        string KmDa, string KmA, byte ServiceLevel)
        {

            // System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            System.Web.HttpContext.Current.Items.Add("logheader", "nico");
            _log.Debug("1");

            try
            {
                return _verifiche.VerificaVABIS(TipoInterr, TipoRange, CodiceVia, DenominazioneVia, NumeroDa, NumeroA, LottoDa, LottoA, PalazzinaDa, PalazzinaA, KmDa, KmA, checkRights("NETVABIS", ServiceLevel));
            }
            catch (Exception erro)
            {
                _log.Debug(erro.Message);
                throw new SoapException(erro.Message, null);
            }
        }

        [WebMethod(Description = "Ricerca Domiciliati per Inidirizzo Puntuale VABIS2"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaVABIS2(byte TipoInterr, Int32 CodiceVia, string DenominazioneVia, Int32 Numero, string lettera, string esponente, byte ServiceLevel)
        {

            // System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            System.Web.HttpContext.Current.Items.Add("logheader", "nico");
            _log.Debug("1");

            try
            {
                return _verifiche.VerificaVABIS2(TipoInterr, CodiceVia, DenominazioneVia, Numero, lettera, esponente, checkRights("NETVABIS2", ServiceLevel));
            }
            catch (Exception erro)
            {
                _log.Debug(erro.Message);
                throw new SoapException(erro.Message, null);
            }
        }

        [WebMethod(Description = "Ricerca Strade create dall'Anagrafe"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public System.Xml.XmlDocument VerificaNETTERR(string DataInizio, string DataFine)
        {

            // System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            System.Web.HttpContext.Current.Items.Add("logheader", "nico");
            _log.Debug("Netterr");

            try
            {
                _log.Debug("Netterr1");
                return _verifiche.VerificaNetTerr(DataInizio, DataFine);

            }
            catch (Exception erro)
            {
                _log.Error("NETTER" + erro.Message);
                throw new SoapException(erro.Message, null);
            }


        }


    }
}
