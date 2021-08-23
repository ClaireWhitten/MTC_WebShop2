using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Bussiness
{
    public static  class InvoiceConverter
    {
        //================================================================= extention method
        private static Object thisLock = new Object();
        public static string ConvertToInvoice(this int aOrderOutId)
        {
            lock (thisLock)
            {
                return aOrderOutId.ToString("D8");
            }
        }
        //=================================================================================
    }
}
