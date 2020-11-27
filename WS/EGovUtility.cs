using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Italy.EASI;

/// <summary>
/// Summary description for EGovUtility
/// </summary>
/// 
namespace Unisys.CdR.WS.ServiziAnagrafici.EGOV
{

public class EGovUtility
{
	public EGovUtility()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public bool ValidateIntestazione()
    {
        return false;
    }

    public bool CheckServizio(string NomeServizio)
    {
        bool vero = false;
        switch (NomeServizio)
        {
            case "VerificaAnagrafica":
             vero = true;
             break;
         case "VerificaStoricaDocumenti":
             vero = true;
             break;
         case "VerificaCri":
             vero = true;
             break;
         case "VerificaAnagraficaStorica":
             vero = true;
             break;
         case "VerificaAnagraficaSuper":
             vero = true;
             break;
         case "VerificaAnagraficaCached":
             vero = true;
             break;
         case "VerificaLeggeRutelli":
             vero = true;
             break;
         case "VerificaAnagraficaEstesa":
             vero = true;
             break;
         case "VerificaCartaIdent":
             vero = true;
             break;
         case "VerificaDocumenti":
             vero = true;
             break;
         case "VerificaStoricoFamigliaXData":
             vero = true;
             break;
         case "VerificaElettorale":
             vero = true;
             break;
        // case "VerificaSezioneElettorale":
          //   vero = true;
           //  break;
         //case "VerificaLibrettiLavoro":
           //  vero = true;
            // break;
         case "VerificaCI":
             vero = true;
             break;
         case "VerificaDomXRangeCivici":
             vero = true;
             break;
         case "VerificaDomiciliatiperIndirizzo":
             vero = true;
             break;
         case "VerificaDomiciliatiperIndirizzoeFamiglia":
             vero = true;
             break;
         case "VerificaVaccinazioni":
             vero = true;
             break;
         case "VerificaLevaMilitare":
             vero = true;
             break;
         case "VerificaStatoFamigliaConv":
             vero = true;
             break;
         case "VerificaSitFamigliaConv":
             vero = true;
             break;
         case "VerificaPerm":
             vero = true;
             break;
         case "VerificaNullaOstaCI":
             vero = true;
             break;
         }
         return vero;
    }


      

    protected string CheckCampi(string cognome, string sesso, short annonascita)
    {
        string errore = "";
        if (cognome == "" || cognome.Length < 2)
        {
            errore = "Cognome  ERRATO";

        }
        if ((sesso == "") && (sesso.ToUpper() != "M" || sesso.ToUpper() != "F"))
        {
            errore = errore + " Sesso ERRATO";
        }
        if (annonascita.ToString() == "" || annonascita.ToString().Length < 4 || annonascita.ToString().Length > 4)
        {
            errore = errore + "Anno nascita ERRATO";
        }
        return errore;

    }


}

}