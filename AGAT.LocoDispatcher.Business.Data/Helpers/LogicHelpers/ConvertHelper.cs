using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Data.Helpers.LogicHelpers
{
    public class ConvertHelper
    {
        public static DateTime TimestampToDateTime(int timestamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
