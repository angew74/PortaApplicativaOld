using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Com.Unisys.VerificheAnagrafiche
{
    public interface IVerifiche
    {

        XmlDocument VerificaAnagrafica(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaAnagraficaSuper(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaAnagraficaCached(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaLeggeRutelli(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaAnagraficaEstesa(string Sesso, string Cognome, string Nome, Int16 AnnoIniziale, Int16 AnnoFinale, string Patern, string Matern, string Domicilio, string ComuneNascita, byte ServiceLevel);

        XmlDocument VerificaCartaIdent(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaDocumenti(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaStoricoFamigliaXData(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte GiornoRif, byte MeseRif, Int16 AnnoRif, byte ServiceLevel);

        XmlDocument VerificaElettorale(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaSezioneElettorale(byte TipoInterr, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, string Carta, byte ServiceLevel);

        XmlDocument VerificaCI(string Carta, byte ServiceLevel);

        XmlDocument VerificaDomXRangeCivici(byte TipoInterr, byte TipoRange, Int32 CodiceVia, string DenominazioneVia, Int16 NumeroDa, Int16 NumeroA, string LottoDa, string LottoA, string PalazzinaDa, string PalazzinaA, string KmDa, string KmA, byte ServiceLevel);

        XmlDocument VerificaDomiciliatiperIndirizzo(byte TipoInterr, Int32 CodiceVia, string DenominazioneVia, Int16 Numero, string Lettera, string Lotto, string Palazzina, string Km, string Scala, string Piano, string Interno, byte ServiceLevel);

        XmlDocument VerificaDomiciliatiperIndirizzoeFamiglia(byte TipoInterr, Int32 CodiceVia, string DenominazioneVia, Int16 Numero, string Lettera, string Lotto, string Palazzina, string Km, string Scala, string Piano, string Interno, byte ServiceLevel);

        XmlDocument VerificaVaccinazioni(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaLevaMilitare(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaStatoFamigliaConv(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaSitFamigliaConv(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaStoricaDocumenti(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaStoricaIndividuo(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

        XmlDocument VerificaCri(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, Int16 AnnoPratica, Int32 NumeroPratica, byte ServiceLevel);

        XmlDocument VerificaPerm(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, Int16 AnnoPratica, Int32 NumeroPratica, string NumAttestato, string NumPermesso, byte ServiceLevel);

        XmlDocument VerificaNullaOstaCI(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);

       XmlDocument VerificaPatente(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, string NumeroPatente, string NumeroTarga, byte ServiceLevel);

        XmlDocument VerificaAutoCertificazione(byte TipoInterr, string CodiceIndividuale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte GiornoRiferimento, byte MeseRiferimento, Int16 AnnoRiferimento, byte ServiceLevel);

       XmlDocument VerificaVABIS(byte TipoInterr, byte TipoRange, Int32 CodiceVia, string DenominazioneVia, Int32 NumeroDa, Int32 NumeroA, string LottoDa, string LottoA, string PalazzinaDa, string PalazzinaA, string KmDa, string KmA, byte ServiceLevel);

       XmlDocument VerificaVABIS2(byte TipoInterr, Int32 CodiceVia, string DenominazioneVia, Int32 Numero, string Lettera, string Esponente, byte ServiceLevel);

       XmlDocument VerificaNetTerr(string DataInizio, string DataFine);

        XmlDocument VerificaAutSepoltura(byte TipoInterr, string CodiceIndividuale, string CodiceFiscale, string Sesso, string Cognome, string Nome, byte GiornoNascita, byte MeseNascita, Int16 AnnoNascita, byte ServiceLevel);
    }
}
