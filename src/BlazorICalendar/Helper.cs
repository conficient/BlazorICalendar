using Ical.Net;
using Ical.Net.Serialization;
using System;

namespace BlazorICalendar
{
    public static class Helper
    {
        /// <summary>
        /// Creates a data url for an ICalendar .ics download
        /// </summary>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static string GetDataUrl(Calendar calendar)
        {
            var serializer = new CalendarSerializer();
            var text = serializer.SerializeToString(calendar);
            var data = System.Text.Encoding.UTF8.GetBytes(text);
            var base64 = Convert.ToBase64String(data);
            return $"data:text/calendar;base64,{base64}";
        }
    }
}
