using System.Web.Services;
using System.Xml;
using Unisys.CdR.Servizi;
using System.Web.Services.Protocols;
using System.Diagnostics;
using System.Web.Services.Description;
using System;
using Unisys.CdR.WS.StradarioPrivato;
namespace Unisys.CdR.WS.Stradario
{

    [WebService(Description = "Interrogazione stradario comunale", Namespace = "http://servizi.comune.roma.it/stradario"), SoapDocumentService(SoapBindingUse.Literal, SoapParameterStyle.Wrapped, RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    public class Stradario : Unisys.CdR.WS.StradarioPrivato.GenericStradario
    {


        // nr 06/2008
        public Unisys.CdR.Servizi.Log.LogHeader LogHash;


        private string pattern = "^[A-Z_a-z]{1,20}[']{0,1}\\s{0,1}[A-Z_a-z_'_ ]{0,20}$";
        //Private _dataSwitch As New System.Diagnostics.BooleanSwitch("DataSwitch", Nothing)
        //Private _codeSwitch As New System.Diagnostics.TraceSwitch("CodeSwitch", Nothing)

        Unisys.CdR.WS.StradarioPrivato.NStradBusinessLayer a = new Unisys.CdR.WS.StradarioPrivato.NStradBusinessLayer();


        #region " Web Services Designer Generated Code "

        public Stradario()
            : base()
        {

            //This call is required by the Web Services Designer.
            InitializeComponent();

            //Add your own initialization code after the InitializeComponent() call

        }

        //Required by the Web Services Designer
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Web Services Designer
        //It can be modified using the Web Services Designer. 
        //Do not modify it using the code editor.
        internal System.Windows.Forms.StatusBarPanel StatusBarPanel1;

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.StatusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)this.StatusBarPanel1).BeginInit();
            //
            //StatusBarPanel1
            //
            this.StatusBarPanel1.Text = "StatusBarPanel1";
            ((System.ComponentModel.ISupportInitialize)this.StatusBarPanel1).EndInit();

        }

        protected override void Dispose(bool disposing)
        {
            //CODEGEN: This procedure is required by the Web Services Designer
            //Do not modify it using the code editor.
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        //<remarks> Cerca una strada a partire dalla denominazione</remarks>
        [WebMethod(Description = "Cerca una strada a partire dalla denominazione", BufferResponse = true, CacheDuration = 60, EnableSession = false, MessageName = "CercaStradaDalNome"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public XmlDocument CercaStradaDalNome(string Nome, byte Tipo)
        {
            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            string errstring = null;
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (expr.Match(Nome).Success == false)
            {
                SoapExcepGest costr = new SoapExcepGest("formato dei parametri non valido", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                throw costr.Exception;
            }

            XmlDocument xmldoc = new XmlDocument();

            bool @bool = false;
            try
            {
                if (a.Request(Nome.ToUpper(), Tipo, ref xmldoc, ref errstring) == false)
                {
                    SoapExcepGest costr = new SoapExcepGest(errstring, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                    @bool = true;
                    throw costr.Exception;
                }
                else
                {
                    return xmldoc;
                }
            }
            catch (Exception e)
            {
                SoapExcepGest costr = new SoapExcepGest("Errore", SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                throw costr.Exception;
            }

        }


        //<remarks> Cerca una strada a partire dalla denominazione e dal civico definizione puntuale</remarks>
        [WebMethod(Description = "Cerca una strada a partire dalla denominazione e dal civico definizione puntuale", BufferResponse = true, CacheDuration = 60, EnableSession = false, MessageName = "CercaStradaDalNomeeDalCivico"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public XmlDocument CercaStradaDalNomeeDalCivico(string Nome, Int32 Civico, byte Tipo)
        {
            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            string errstring = null;
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (expr.Match(Nome).Success == false)
            {
                SoapExcepGest costr = new SoapExcepGest("formato dei parametri non valido", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                throw costr.Exception;
            }

            if (Civico == 0)
            {
                SoapExcepGest costr = new SoapExcepGest("formato dei parametri non valido", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
            }
            string civ = Civico.ToString();
            if (civ.Length > 5)
            {
                SoapExcepGest costr = new SoapExcepGest("Civico deve essere minore di 6 cifre.", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, "0000");
                throw costr.Exception;
            }

            XmlDocument xmldoc = new XmlDocument();

            bool @bool = false;
            try
            {
                if (a.RequestPuntuale(Nome.ToUpper(), Civico, Tipo, ref xmldoc, ref errstring) == false)
                {
                    SoapExcepGest costr = new SoapExcepGest(errstring, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                    @bool = true;
                    throw costr.Exception;
                }
                else
                {
                    if (string.IsNullOrEmpty(xmldoc.InnerXml))
                    {
                        //Dim nsmanager As XmlNamespaceManager = New XmlNamespaceManager(xmldoc.NameTable)
                        //nsmanager.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema")
                        //nsmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
                        //nsmanager.AddNamespace("xsi", "http://servizi.comune.roma.it/stradario/namespace")
                        xmldoc.InnerXml = "<Strade><StradaNonLocalizzata>Codice 001: Strada e Civico non localizzati</StradaNonLocalizzata></Strade>";
                        xmldoc.DocumentElement.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
                        xmldoc.DocumentElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        xmldoc.DocumentElement.SetAttribute("xmlns", "http://servizi.comune.roma.it/stradario/namespace");
                    }
                    return xmldoc;
                }
            }
            catch (Exception e)
            {
                SoapExcepGest costr = new SoapExcepGest("Errore", SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                throw costr.Exception;
            }

        }



        //<remarks> Cerca una strada a partire dalla denominazione</remarks>
        [WebMethod(Description = "Ricerca su stradario per il Portale comunale [ricerca parziale: inserire inizio della denominazione]", BufferResponse = true, CacheDuration = 60, EnableSession = false, MessageName = "ElencoStrade"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public XmlDocument ElencoStrade(string DescrizioneParziale)
        {
            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            string errstring = null;
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (expr.Match(DescrizioneParziale).Success == false)
            {
                SoapExcepGest costr = new SoapExcepGest("Dati errati: indicare la strada completa o la parte iniziale con almeno due lettere", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, "");
                throw costr.Exception;
            }

            XmlDocument xmldoc = new XmlDocument();
            bool @bool = false;

            try
            {
                if (a.Request(DescrizioneParziale.ToUpper(), 0,ref xmldoc,ref errstring) == false)
                {
                    SoapExcepGest costr = new SoapExcepGest(errstring, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "");
                    @bool = true;
                    //Trace.WriteLineIf(_codeSwitch.Level > TraceLevel.Off, errstring.Replace(Chr(13), "/"))
                    throw costr.Exception;
                }
                else
                {
                    return xmldoc;
                }
            }
            catch (Exception e)
            {
                SoapExcepGest costr = new SoapExcepGest("Errore imprevisto e non gestibile", SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "");
                //Trace.WriteLineIf(_codeSwitch.Level > TraceLevel.Off, e.Message.Replace(Chr(13), "/"))
                throw costr.Exception;
            }

        }




        //<remarks> Cerca una strada a partire dal codice di classificazione comunale (per uso interno)</remarks>
        [WebMethod(Description = "Cerca una strada a partire dal codice di classificazione comunale [codice a 6 cifre]", BufferResponse = true, CacheDuration = 60, EnableSession = false, MessageName = "CercaStradaDalCodice"), SoapHeader("LogHash", Direction = SoapHeaderDirection.In)]
        public XmlDocument CercaStradaDalCodice(string Codice)
        {
            System.Web.HttpContext.Current.Items.Add("logheader", LogHash.LogGuid);
            if (Codice.Length != 6)
            {
                SoapExcepGest costr = new SoapExcepGest("Il codice di classificazione della strada deve essere di 6 cifre.", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, "0000");
                throw costr.Exception;
            }

            XmlDocument xmldoc = new XmlDocument();
            string errstring = null;
            string pattern = null;
            pattern = "^[0-9]{1,10}$";
            System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(pattern);

            if (expr.Match(Codice).Success == false)
            {
                SoapExcepGest costr = new SoapExcepGest("formato dei parametri non valido", SoapException.ClientFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                throw costr.Exception;
            }

            bool @bool = false;
            try
            {
                if (a.Request1(Codice,ref xmldoc, ref errstring) == false)
                {
                    SoapExcepGest costr = new SoapExcepGest(errstring, SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                    @bool = true;
                    throw costr.Exception;
                }
                else
                {
                    return xmldoc;
                }
            }

            catch (Exception e)
            {
                SoapExcepGest costr = new SoapExcepGest("Errore", SoapException.ServerFaultCode, Context.Request.Url.AbsoluteUri, "xyz");
                throw costr.Exception;
            }
            return xmldoc;
        }
    }
}