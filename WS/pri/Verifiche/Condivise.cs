using System;
using System.Diagnostics;
namespace Unisys.CdR.WS.Verifiche
{

    public static class Condivise
    {


        public static bool IsDateCorrect(Int32 gg, Int32 mm, Int32 aa)
        {

            return IsDate(String.Concat(gg.ToString(), "/", mm.ToString(), "/", aa.ToString()));

        }

        public static void traccia(string Problem, string Detail, string RoutineName)
        {
            string logDetails = Problem + " - " + "Unisys.CdR.WS.Verifiche.Condivise - routine:" + RoutineName + " - " + Detail;
            if ((logDetails.Length > 500))
            {
                logDetails = logDetails.Substring(0, 500);
            }
            Unisys.CdR.Servizi.Log.Logger myLogger = new Unisys.CdR.Servizi.Log.Logger("NULL", 0, 0, "0000", "0.0.0.0", 0, 0, "0000", (byte)Unisys.CdR.Servizi.Log.Logger.AppCode.PortaApplicativaERRORS);
            myLogger.EnqueueError((byte)Unisys.CdR.Servizi.Log.Logger.LogTypeCode.Errors, "ERR", logDetails);
        }

        public static bool IsDate(string strDate)
        {
            
            DateTime data;
            try
            {
                if (DateTime.TryParse(strDate, out data))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}