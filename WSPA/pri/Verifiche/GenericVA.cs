using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unisys.CdR.RefreshCounters;

namespace WSPA.pri.Verifiche
{
    public class GenericVA : System.Web.Services.WebService
    {

        private Ricerca _tipoRicerca;
        private string _codiceIndividuale;
        private string _codiceFiscale;
        //Private _sesso As Char
        private string _cognome;
        private string _nome;
        private Int32 _giornoNascita;
        private Int32 _meseNascita;
        private Int32 _annoNascita;
        // doc x parametri Mapper
        private System.Xml.XmlDocument XmlDocIN;
        private string _codiceVA;


        public enum Ricerca : int
        {
            CodiceIndividuale = 1,
            CodiceFiscale,
            CognomeNome
        }


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
                    Condivise.traccia("Profilo utente corrotto o anomalo", ex.Message, "Unisys.CdR.WS.Verifiche.GenericVA.checkRights");
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




        public GenericVA()
            : base()
        {

        }


        private System.ComponentModel.IContainer components;


        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


    }
}