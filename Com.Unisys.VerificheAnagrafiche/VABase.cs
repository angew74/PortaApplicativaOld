using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using Unisys.CdR.CacheAnagrafe;
using Unisys.CdR.CustomApplicationCache;
using Unisys.CdR.CustomProfile;
using Unisys.CdR.OpenTI;
using Unisys.CdR.XSLTUtility;

namespace Com.Unisys.VerificheAnagrafiche
{
    public abstract class VABase : IDisposable
    {

        // Private ReadOnly _log As log4net.ILog = log4net.LogManager.GetLogger("VABase")
        private bool _disposed = false;

        protected internal MapperWrapper _myWrapper;

        private Mapper _myMapper;

        private MapperWrapper.Ricerca ricerca;

        public const string APPSETTINGSMAPPERCACHEKEY = "MapperCache";

        public const string APPSETTINGSXSLTCRYPTEDKEY = "XSLTCRYPTED";

        public enum ResponseType : byte
        {

            ForceXSLTTransformation = 0,

            AllowOriginalXML,

            OriginalXMLWithoutXSLT,
        }

        public VABase()
        {
        }

        // '<remarks> Valore che indica il tipo di ricerca da effettuare</remarks>
        // Protected WriteOnly Property TipoRicerca() As Byte
        //     Set(ByVal Value As Byte)
        //         If Value > 3 OrElse Value < 1 Then
        //             Throw New Exception("I codici ricerca ammessi sono: 1 = codice individuale, 2 = codice fiscale, 3 = anagrafica. Specificare un codice valido.")
        //         End If
        //         _tipoRicerca = CType(Value, Unisys.CdR.OpenTI.MapperWrapper.Ricerca)
        //     End Set
        // End Property
        // <remarks> Effettua la chiamata al componente di integrazione e provvede 
        //  a formattare i dati secondo uno schema predefinito
        //  ResponseType consente di recuperare lo stream XML di Mapper senza
        //  applicare i fogli si stile XSLT. 
        //  ForceXSLTTransformation   = 0 --> applica per forza almeno 1 foglio
        //  AllowOriginalXML          = 1 --> applica i fogli se previsti altrimenti torna l'XML di Mapper
        //  OriginalXMLWithoutXSLT    = 2 --> non applicare nulla e ritorna l'XML di Mapper
        // </remarks>
        protected XmlDocument SearchOnBIS(ResponseType XMLResponseType)
        {
            _myMapper = new Mapper();
            XmlDocument xmlDoc;
            XslTransform[] xsltDocs;
            string servCode = _myWrapper.Servizio;
            //  mi servir� dopo
            string[] xsltFiles;
            if (this.DoLog())
            {
                xmlDoc = _myMapper.CallServices(_myWrapper.ToString(true));
                if (!(xmlDoc == null))
                {
                    if ((XMLResponseType == ResponseType.OriginalXMLWithoutXSLT))
                    {
                        return xmlDoc;
                        //  ritorno i dati di Mapper senza elaborazioni
                    }
                    else
                    {
                        XSLTApplier xUtil = new XSLTApplier();
                        Cache cache = Cache.Instance;
                        //  Verifico se ho gi� in cache il foglio
                        string cachespecialname = ("xsltcdr" + servCode);
                        //  xsltcdr x maggiore sicurezza di univocit� in cache
                        object tmpObj = cache.Get(cachespecialname);
                        //  xsltcdr x maggiore sicurezza di univocit� in cache
                        if (!(tmpObj == null))
                        {
                            tmpObj;
                            Xml.Xsl.XslTransform();
                        }
                        else
                        {
                            string[] t = this.getXSLTFilenames(servCode);
                            if (!(t == null))
                            {
                                xsltDocs = xUtil.GetXSLTFile(t, XsltCrypted);
                                cache.Insert(cachespecialname, xsltDocs, CacheItemLifetime.Permanent);
                            }

                        }

                        //  Applico i fogli, se ne ho......
                        if ((xsltDocs == null))
                        {
                            if ((XMLResponseType == ResponseType.AllowOriginalXML))
                            {
                                return xmlDoc;
                                //  ritorno i dati di Mapper senza elaborazioni
                            }
                            else
                            {
                                throw new Exception("Nessun foglio di trasformazione configurato per il servizio richiesto. Dati non disponibili (Unisys.C" +
                                    "dR.VerificheAnagrafiche.VABase[Search])");
                            }

                        }
                        else
                        {
                            //  Applico tutti i fogli sul doc........
                            return xUtil.Apply(xmlDoc, xsltDocs);
                        }

                    }

                }
                else
                {
                    throw new Exception("Nessun dato di ritorno dal componenete di integrazione con il sistema centrale: anomalia imprevista! " +
                        "(Unisys.CdR.VerificheAnagrafiche.VABase[Search])");
                }

            }

        }

        // '<remarks> Valore che indica il tipo di ricerca da effettuare</remarks>
        // Protected WriteOnly Property TipoRicerca() As Byte
        //     Set(ByVal Value As Byte)
        //         If Value > 3 OrElse Value < 1 Then
        //             Throw New Exception("I codici ricerca ammessi sono: 1 = codice individuale, 2 = codice fiscale, 3 = anagrafica. Specificare un codice valido.")
        //         End If
        //         _tipoRicerca = CType(Value, Unisys.CdR.OpenTI.MapperWrapper.Ricerca)
        //     End Set
        // End Property
        // <remarks> Effettua la chiamata al componente di integrazione e provvede 
        //  a formattare i dati secondo uno schema predefinito
        // 
        //  OriginalXMLWithoutXSLT consente di recuperare lo stream XML senza
        //  applicare i fogli si stile XSLT.
        // 
        // </remarks>
        protected XmlDocument SearchOnCache(ResponseType XMLResponseType)
        {
            DB _dbCache = new DB();
            XmlDocument xmlDoc;
            XslTransform[] xsltDocs;
            string servCode = _myWrapper.Servizio;
            //  mi servir� dopo
            string[] xsltFiles;
            //  If DoLog() Then
            if ((1 == 1))
            {
                xmlDoc = _dbCache.ReadAnagXML(_myWrapper);
                if (!(xmlDoc == null))
                {
                    if ((XMLResponseType == ResponseType.OriginalXMLWithoutXSLT))
                    {
                        return xmlDoc;
                        //  ritorno i dati di Mapper senza elaborazioni
                    }
                    else
                    {
                        XSLTApplier xUtil = new XSLTApplier();
                        Cache cache = Cache.Instance;
                        //  Verifico se ho gi� in cache il foglio
                        string cachespecialname = ("xsltcdr" + servCode);
                        //  xsltcdr x maggiore sicurezza di univocit� in cache
                        object tmpObj = cache.Get(cachespecialname);
                        //  xsltcdr x maggiore sicurezza di univocit� in cache
                        if (!(tmpObj == null))
                        {
                            tmpObj;
                            Xml.Xsl.XslTransform();
                        }
                        else
                        {
                            string[] t = this.getXSLTFilenames(servCode);
                            if (!(t == null))
                            {
                                xsltDocs = xUtil.GetXSLTFile(t, XsltCrypted);
                                cache.Insert(cachespecialname, xsltDocs, CacheItemLifetime.Permanent);
                            }

                        }

                        //  Applico i fogli, se ne ho......
                        if ((xsltDocs == null))
                        {
                            if ((XMLResponseType == ResponseType.AllowOriginalXML))
                            {
                                return xmlDoc;
                                //  ritorno i dati di Mapper senza elaborazioni
                            }
                            else
                            {
                                throw new Exception("Nessun foglio di trasformazione configurato per il servizio richiesto. Dati non disponibili (Unisys.C" +
                                    "dR.VerificheAnagrafiche.VABase[Search])");
                            }

                        }
                        else
                        {
                            //  Applico tutti i fogli sul doc........
                            return xUtil.Apply(xmlDoc, xsltDocs);
                        }

                    }

                }
                else
                {
                    throw new Exception("Nessun dato di ritorno dal componenete di integrazione con il sistema centrale: anomalia imprevista! " +
                        "(Unisys.CdR.VerificheAnagrafiche.VABase[Search])");
                }

            }

        }

        //  Imposta le propriet� a seconda del tipo di interrogazione
        //  Utilizzata dai metodi per le ricerche anagrafiche
        protected internal void SetMyValues(string Servizio, byte LivelloServizio, byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita)
        {
            _myWrapper = new MapperWrapper(true, Servizio, LivelloServizio.ToString());
            string reason;
            _myWrapper.TipoRicerca = ((MapperWrapper.Ricerca)(TipoInterr));
            switch (TipoInterr)
            {
                case 2:
                    if (DataValidation.Generic.CheckCF(CodiceFiscale, reason))
                    {
                        _myWrapper.CodiceFiscale = CodiceFiscale;
                    }
                    else
                    {
                        throw new Exception(("Specificare un codice fiscale valido. " + reason));
                    }

                    break;
                case 1:
                    if (DataValidation.Generic.CheckCI(CodiceIndividuale, reason))
                    {
                        _myWrapper.CodiceIndividuale = CodiceIndividuale.ToString;
                    }
                    else
                    {
                        throw new Exception(("Specificare un codice individuale valido. " + reason));
                    }

                    break;
                case 3:
                    if (DataValidation.Generic.CheckCognome(Cognome, reason))
                    {
                        _myWrapper.Cognome = Cognome;
                        _myWrapper.Nome = Nome;
                        if (DataValidation.Generic.CheckSex(Sesso, reason))
                        {
                            _myWrapper.Sesso = Sesso.ToString;
                            if (DataValidation.Generic.CheckYear(AnnoNascita, reason))
                            {
                                _myWrapper.Giorno = GiornoNascita.ToString;
                                _myWrapper.Mese = MeseNascita.ToString;
                                _myWrapper.Anno = AnnoNascita.ToString;
                            }
                            else
                            {
                                throw new Exception(("Specificare un anno. " + reason));
                            }

                        }
                        else
                        {
                            throw new Exception(("Specificare un codice sesso valido. " + reason));
                        }

                    }
                    else
                    {
                        throw new Exception(("Specificare un cognome valido. " + reason));
                    }

                    break;
                case ricerca.DatiParziali:
                    if (DataValidation.Generic.CheckCognome(Cognome, reason))
                    {
                        _myWrapper.Cognome = Cognome;
                        _myWrapper.Nome = Nome;
                        if (DataValidation.Generic.CheckSex(Sesso, reason))
                        {
                            _myWrapper.Sesso = Sesso.ToString;
                        }
                        else
                        {
                            throw new Exception(("Specificare un codice sesso valido. " + reason));
                        }

                    }
                    else
                    {
                        throw new Exception(("Specificare un cognome valido. " + reason));
                    }

                    break;
            }
        }

        // 
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            //  Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                //  If disposing equals true dispose all managed and unmanaged resources.
                if (disposing)
                {
                    //  Dispose managed resources.
                    if (!(_myMapper == null))
                    {
                        _myMapper.Dispose();
                    }

                }

                _disposed = true;
            }

        }
       

        protected internal string[] getXSLTFilenames(string XSLTCode)
        {
            string appo;
            string configfile = this.getConfigPathname();
            ConfigurationReader ccs = new ConfigurationReader(configfile);
            string tmp = ccs.Get(XSLTCode);
            if ((tmp == null))
            {
                throw new Exception(string.Concat("Errore: impossibile trovare la chiave di configurazione \'", XSLTCode, "\' nel file \'", configfile, "\'"));
            }
            else
            {
                tmp;
                String;
                if ((appo == null))
                {
                    return null;
                }
                else
                {
                    return appo.Split(",", c);
                }

            }

        }

        //  Legge da registry il percorso al file di configurazione
        //  Se assente, restituisce un percorso standard
        public const string XMLConfigurationFile = "c:\\VABaseConfiguration.xml";

        public const string XMLConfigurationFileRegistrySection = "SOFTWARE\\Unisys.CdR\\VABase";

        public const string XMLConfigurationFileRegistryKey = "ConfigurationFile";

        private string getConfigPathname()
        {
            return RegistryReader.FromLocalMachine(XMLConfigurationFileRegistrySection, XMLConfigurationFileRegistryKey, XMLConfigurationFile);
        }

        //  lettura nel file di configurazione del flag corrispondente all'ambiente dove effettuare l'interrogazione
        //  mapper - cache
        protected string selezioneAmbiente()
        {
            string mc;
            try
            {
                mc = System.Configuration.ConfigurationSettings.AppSettings.Get(APPSETTINGSMAPPERCACHEKEY);
                if ((mc == ""))
                {
                    throw new Exception("Scelta ambiente interrogazione vuota");
                }

            }
            catch (Exception e)
            {
                throw new Exception(("Errore durante l\'accesso all\'ambiente di interrogazione [dettaglio per il supporto tecnico: "
                                + (e.Message + "]")));
            }

            return mc;
        }

        //  lettura nel file di configurazione del flag fogli xslt criptati o no
        protected bool XsltCrypted()
        {
            bool crypted = false;
            string cr;
            try
            {
                cr = System.Configuration.ConfigurationSettings.AppSettings.Get(APPSETTINGSXSLTCRYPTEDKEY);
                if ((cr == ""))
                {
                    throw new Exception("Configurazione fogli di trasformazione criptati mancante");
                }

                if ((cr == "1"))
                {
                    crypted = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception(("Errore durante l\'accesso all\'ambiente di interrogazione [dettaglio per il supporto tecnico: "
                                + (e.Message + "]")));
            }

            return crypted;
        }

        // scrittura dei log
        protected bool DoLog()
        {
            string[,] parametri;
            object lobj;
            object uobj = HttpRuntime.Cache.Get(HttpContext.Current.User.Identity.Name);
            UserProfile upro;
            string logguid;
            if ((HttpContext.Current.Application.Get("IBM") == null))
            {
                if ((uobj == null))
                {
                    throw new Exception("Errore nel recuperare il profilo utente in cache");
                }
                else
                {
                    uobj;
                    UserProfile;
                }

                lobj = HttpContext.Current.Items.Item["logheader"];
                if ((lobj == null))
                {
                    throw new Exception("Errore nel recuperare l\'identificativo del log in cache");
                }
                else
                {
                    logguid = ((string)(lobj));
                }

            }

            // preparazione array con i parametri della ricerca
            switch (_myWrapper.TipoRicerca)
            {
                case ricerca.CodiceIndividuale:
                    parametri[0] = string.Concat("Codice individuale: ", _myWrapper.CodiceIndividuale);
                    break;
                case ricerca.CodiceFiscale:
                    parametri[0] = string.Concat("Codice fiscale: ", _myWrapper.CodiceFiscale);
                    break;
                case ricerca.CognomeNome:
                    byte gg;
                    byte mm;
                    if ((_myWrapper.Giorno != ""))
                    {
                        gg = ((byte)(_myWrapper.Giorno));
                    }

                    if ((_myWrapper.Mese != ""))
                    {
                        mm = ((byte)(_myWrapper.Mese));
                    }

                    parametri[0] = ("Cognome: " + _myWrapper.Cognome);
                    parametri[1] = ("Nome: " + _myWrapper.Nome);
                    parametri[2] = string.Concat("Data di nascita: ", gg.ToString.PadLeft(2, "0", c), "/", mm.ToString.PadLeft(2, "0", c), "/", _myWrapper.Anno);
                    parametri[3] = ("Sesso: " + _myWrapper.Sesso);
                    break;
            }
            parametri[(parametri.Length - 1)] = _myWrapper.Servizio;
            switch (_myWrapper.Servizio)
            {
                case "NETVA2":
                    parametri[(parametri.Length - 1)] = "Verifica anagrafica";
                    break;
                case "NETSEPP":
                    parametri[(parametri.Length - 1)] = "Verifica Autorizzazione Sepoltura";
                    break;
                case "SUPERNETVA":
                    parametri[(parametri.Length - 1)] = "Verifica anagrafica super";
                    break;
                case "NETVSTO":
                    parametri[(parametri.Length - 1)] = "Verifica anagrafica storica";
                    break;
                case "NETVANB2":
                    parametri[0] = ("Cognome: " + _myWrapper.Cognome);
                    parametri[1] = ("Nome: " + _myWrapper.Nome);
                    parametri[2] = ("Sesso: " + _myWrapper.Sesso);
                    parametri[3] = ("Anno Iniziale: " + _myWrapper.AnnoNascitaIniziale);
                    parametri[4] = ("Anno Finale: " + _myWrapper.AnnoNascitaFinale);
                    parametri[5] = ("Padre: " + _myWrapper.Padre);
                    parametri[6] = ("Madre: " + _myWrapper.Madre);
                    parametri[7] = ("Indirizzo: " + _myWrapper.Domicilio);
                    // parametri(8) = "Comune di Nascita: " & _myWrapper.ComuneNascita
                    parametri[(parametri.Length - 1)] = "Verifica Anagrafica Estesa";
                    break;
                case "NETCRI":
                    if (!(_myWrapper.CodiceIndividuale == null))
                    {
                        parametri[0] = ("Codice Individuale: " + _myWrapper.CodiceIndividuale);
                    }

                    if (!(_myWrapper.CodiceFiscale == null))
                    {
                        parametri[0] = ("Codice Fiscale: " + _myWrapper.CodiceFiscale);
                    }

                    if (!(_myWrapper.Sesso == null))
                    {
                        parametri[0] = ("Sesso: " + _myWrapper.Sesso);
                        parametri[1] = ("Cognome: " + _myWrapper.Cognome);
                        parametri[2] = ("Nome: " + _myWrapper.Nome);
                        parametri[3] = ("GiornoNascita: " + _myWrapper.Giorno);
                        parametri[4] = ("MeseNascita: " + _myWrapper.Mese);
                        parametri[5] = ("AnnoNascita: " + _myWrapper.Anno);
                    }

                    if (!(_myWrapper.AnnoPratica == null))
                    {
                        parametri[0] = ("AnnoPratica: " + _myWrapper.AnnoPratica);
                        parametri[1] = ("NumeroPratica: " + _myWrapper.NumeroPratica);
                    }

                    parametri[(parametri.Length - 1)] = "Verifica Cambi Residenza";
                    break;
                case "NETPERM":
                    if (!(_myWrapper.CodiceIndividuale == null))
                    {
                        parametri[0] = ("Codice Individuale: " + _myWrapper.CodiceIndividuale);
                    }

                    if (!(_myWrapper.CodiceFiscale == null))
                    {
                        parametri[0] = ("Codice Fiscale: " + _myWrapper.CodiceFiscale);
                    }

                    if (!(_myWrapper.Sesso == null))
                    {
                        parametri[0] = ("Sesso: " + _myWrapper.Sesso);
                        parametri[1] = ("Cognome: " + _myWrapper.Cognome);
                        parametri[2] = ("Nome: " + _myWrapper.Nome);
                        parametri[3] = ("GiornoNascita: " + _myWrapper.Giorno);
                        parametri[4] = ("MeseNascita: " + _myWrapper.Mese);
                        parametri[5] = ("AnnoNascita: " + _myWrapper.Anno);
                    }

                    if (!(_myWrapper.AnnoPratica == null))
                    {
                        parametri[0] = ("AnnoPratica: " + _myWrapper.AnnoPratica);
                        parametri[1] = ("NumeroPratica: " + _myWrapper.NumeroPratica);
                    }

                    if (!(_myWrapper.NumAttestato == null))
                    {
                        parametri[0] = ("NumeroAttestato: " + _myWrapper.NumAttestato);
                    }

                    if (!(_myWrapper.NumPermesso == null))
                    {
                        parametri[0] = ("NumeroPermesso: " + _myWrapper.NumPermesso);
                    }

                    parametri[(parametri.Length - 1)] = "Verifica Documenti Soggiorno";
                    break;
                case "NETIATT":
                    parametri[(parametri.Length - 1)] = "Verifica Atto Stato Civile";
                    break;
                case "NETVCI2":
                    parametri[(parametri.Length - 1)] = "Verifica Carta d\'Identit�";
                    break;
                case "NETVDOC2":
                    parametri[(parametri.Length - 1)] = "Verifica Documenti";
                    break;
                case "NETATER":
                    if (!(_myWrapper.CodiceVia == null))
                    {
                        parametri[0] = ("Codice Via: " + _myWrapper.CodiceVia);
                    }
                    else if (!(_myWrapper.DenominazioneVia == null))
                    {
                        parametri[0] = ("Denominazione Via: " + StrConv(_myWrapper.DenominazioneVia, VbStrConv.ProperCase));
                    }

                    parametri[1] = ("Numero: " + _myWrapper.NumeroCivico);
                    parametri[2] = ("Lettera: " + _myWrapper.Lettera);
                    parametri[3] = ("Lotto: " + _myWrapper.Lotto);
                    parametri[4] = ("Palazzina: " + _myWrapper.Palazzina);
                    parametri[5] = ("KM: " + _myWrapper.KM);
                    parametri[6] = ("Scala: " + _myWrapper.Scala);
                    parametri[7] = ("Piano: " + _myWrapper.Piano);
                    parametri[8] = ("Interno: " + _myWrapper.Interno);
                    parametri[(parametri.Length - 1)] = "Verifica Domiciliati per Indirizzo e Famiglia";
                    break;
                case "NETVABI":
                    if (!(_myWrapper.CodiceVia == null))
                    {
                        parametri[0] = ("Codice Via: " + _myWrapper.CodiceVia);
                    }
                    else if (!(_myWrapper.DenominazioneVia == null))
                    {
                        parametri[0] = ("Denominazione Via: " + StrConv(_myWrapper.DenominazioneVia, VbStrConv.ProperCase));
                    }

                    parametri[1] = ("Numero: " + _myWrapper.NumeroCivico);
                    parametri[2] = ("Lettera: " + _myWrapper.Lettera);
                    parametri[3] = ("Lotto: " + _myWrapper.Lotto);
                    parametri[4] = ("Palazzina: " + _myWrapper.Palazzina);
                    parametri[5] = ("KM: " + _myWrapper.KM);
                    parametri[6] = ("Scala: " + _myWrapper.Scala);
                    parametri[7] = ("Piano: " + _myWrapper.Piano);
                    parametri[8] = ("Interno: " + _myWrapper.Interno);
                    parametri[(parametri.Length - 1)] = "Verifica Domiciliati per Indirizzo";
                    break;
                case "NETVABIR":
                    if (!(_myWrapper.CodiceVia == null))
                    {
                        parametri[0] = ("Codice Via: " + _myWrapper.CodiceVia);
                    }
                    else if (!(_myWrapper.DenominazioneVia == null))
                    {
                        parametri[0] = ("Denominazione Via: " + StrConv(_myWrapper.DenominazioneVia, VbStrConv.ProperCase));
                    }

                    parametri[1] = ("Numero Da: " + _myWrapper.NumeroCivicoIniziale);
                    parametri[2] = ("Numero A: " + _myWrapper.NumeroCivicoFinale);
                    parametri[3] = ("Lotto Da: " + _myWrapper.LottoIniziale);
                    parametri[4] = ("Lotto A: " + _myWrapper.LottoFinale);
                    parametri[5] = ("Palazzina Da: " + _myWrapper.PalazzinaIniziale);
                    parametri[6] = ("Palazzina A: " + _myWrapper.PalazzinaFinale);
                    parametri[7] = ("KM Da: " + _myWrapper.KMIniziale);
                    parametri[8] = ("KM A: " + _myWrapper.KMFinale);
                    parametri[(parametri.Length - 1)] = "Verifica Domiciliati per Range di Civici";
                    break;
                case "NETVELE":
                    parametri[(parametri.Length - 1)] = "Verifica Elettorale";
                    break;
                case "NETICID":
                    parametri[0] = ("Numero Carta Id: " + _myWrapper.NumeroCartaId);
                    parametri[(parametri.Length - 1)] = "Verifica Carta Id";
                    break;
                case "NETRUTE":
                    parametri[(parametri.Length - 1)] = "Verifica Legge Rutelli";
                    break;
                case "NETILEM":
                    parametri[(parametri.Length - 1)] = "Verifica Leva Militare";
                    break;
                case "NETIFC":
                    parametri[(parametri.Length - 1)] = "Verifica Situazione Famiglia o Convivenza";
                    break;
                case "NETVFC2":
                    parametri[(parametri.Length - 1)] = "Verifica Stato Famiglia o Convivenza";
                    break;
                case "NETVDOC12":
                    parametri[(parametri.Length - 1)] = "Verifica Storica Documenti";
                    break;
                case "NETVSTF":
                    switch (_myWrapper.TipoRicerca)
                    {
                        case ricerca.CodiceIndividuale:
                            parametri[0] = string.Concat("Codice individuale: ", _myWrapper.CodiceIndividuale);
                            break;
                        case ricerca.CodiceFiscale:
                            parametri[1] = string.Concat("Codice fiscale: ", _myWrapper.CodiceFiscale);
                            break;
                        case ricerca.CognomeNome:
                            byte gg;
                            byte mm;
                            if ((_myWrapper.Giorno != ""))
                            {
                                gg = ((byte)(_myWrapper.Giorno));
                            }

                            if ((_myWrapper.Mese != ""))
                            {
                                mm = ((byte)(_myWrapper.Mese));
                            }

                            parametri[2] = ("Cognome: " + _myWrapper.Cognome);
                            parametri[3] = ("Nome: " + _myWrapper.Nome);
                            parametri[4] = string.Concat("Data di nascita: ", gg.ToString.PadLeft(2, "0", c), "/", mm.ToString.PadLeft(2, "0", c), "/", _myWrapper.Anno);
                            parametri[5] = ("Sesso: " + _myWrapper.Sesso);
                            break;
                    }
                    parametri[1] = string.Concat("Data di Riferimento : ", _myWrapper.GiornoDataRiferimento.PadLeft(2, "0", c), "/", _myWrapper.MeseDataRiferimento.PadLeft(2, "0", c), "/", _myWrapper.AnnoDataRiferimento);
                    parametri[(parametri.Length - 1)] = "Verifica Storico Famiglia per Data";
                    break;
                case "NETSTO":
                    parametri[(parametri.Length - 1)] = "Verifica Storico Individuo";
                    break;
                case "NETIVAC":
                    parametri[(parametri.Length - 1)] = "Verifica Vaccinazioni";
                    break;
                case "NETNOCI":
                    parametri[(parametri.Length - 1)] = "Verifica Nulla Osta CartaID";
                    break;
                case "NETVABIS":
                    parametri[(parametri.Length - 1)] = "Verifica VABIS";
                    break;
                case "NETVABIS2":
                    parametri[(parametri.Length - 1)] = "Verifica VABIS";
                    break;
                case "NETTERR":
                    parametri[(parametri.Length - 1)] = "Verifica VABIS";
                    break;
            }
            Int32 i;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(parametri.Length);
            for (i = 0; (i
                        <= (parametri.Length - 2)); i++)
            {
                if ((parametri[i] != null))
                {
                    sb.Append(parametri[i]);
                    sb.Append(" - ");
                }

            }

            string logDetails = string.Concat(parametri[(parametri.Length - 1)], " - ", sb.ToString);
            if ((logDetails.Length > 500))
            {
                logDetails = logDetails.Substring(0, 500);
            }

            Unisys.CdR.Servizi.Log.Logger log;
            if ((HttpContext.Current.Application.Get("IBM") == null))
            {
                log = new Unisys.CdR.Servizi.Log.Logger(logguid, upro.Principal.UniqueID, upro.Principal.IdGruppo, upro.Principal.ParentCode, HttpContext.Current.Request.UserHostAddress, 0, 0, "0000", Unisys.CdR.Servizi.Log.Logger.AppCode.PortaApplicativaLOGS);
            }
            else
            {
                log = new Unisys.CdR.Servizi.Log.Logger("NULL", 11422, 6201, "0104", HttpContext.Current.Request.UserHostAddress, 0, 0, "0000", Unisys.CdR.Servizi.Log.Logger.AppCode.PortaApplicativaLOGS);
            }

            log.EnqueueError(Unisys.CdR.Servizi.Log.Logger.LogTypeCode.Actions, "QRY", logDetails);
            return true;
        }
    }   

}
