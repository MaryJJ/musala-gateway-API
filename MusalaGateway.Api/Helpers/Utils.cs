using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MusalaGateway.Api.Helpers
{
    public static class Utils
    {
        public static bool ValidateIPv4(string strIP)
        {
            if (String.IsNullOrWhiteSpace(strIP))
            {
                return false;
            }
            string[] splitValues = strIP.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }
            return splitValues.All(r => byte.TryParse(r, out byte tempForParsing));
        }
    }
}