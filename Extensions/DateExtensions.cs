using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiCenterBaseProject.Extensions
{
    public static class DateExtensions
    {
        //TODO: uppdatera detta så attförändring av tråden CurrentCulture inte förändrar beteende på applikationen.
        const string DATE_AND_SHORT_TIME = "yyyy-MM-dd HH.mm";
        const string SHORT_DATE = "yyyy-MM-dd";
        const string SHORT_TIME = "HH.mm";
        const string SHORT_TIME_MAINTENANCE = "HH:mm";
        const string DATE_FANCY = "d MMMM yyyy";
        /// <returns>eg. 2012-12-12 10.12</returns>
        public static string ToDateAndShortTimeStr(this DateTime date)
        {
            return date.ToString(DATE_AND_SHORT_TIME);
        }

        /// <returns>eg. 2012-12-12</returns>
        public static string ToShortDateStr(this DateTime date)
        {
            return date.ToString(SHORT_DATE);
        }

        /// <returns>eg. 10.12</returns>
        public static string ToShortTimeStr(this DateTime date)
        {
            return date.ToString(SHORT_TIME);
        }

        /// <returns>eg. 10:12</returns>
        public static string ToShortMaintenanceTimeStr(this DateTime date)
        {
            return date.ToString(SHORT_TIME_MAINTENANCE);
        }

        /// <returns>eg. 30 augusti 2012</returns>
        public static string ToDateFancyStr(this DateTime date)
        {
            return date.ToString(DATE_FANCY);
        }

        /// <summary>
        /// Used in "data-timestamp" for notices and such
        /// </summary>
        /// <param name="date"></param>
        /// <returns>eg. 1377775069390</returns>
        public static string ToUnixEpochTimeStr(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalMilliseconds).ToString();
        }
    }
}