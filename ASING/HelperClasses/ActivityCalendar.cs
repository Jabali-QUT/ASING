using ASING.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASING.HelperClasses
{
    public static class ActivityCalendar
    {
        public static string DownloadCalendar(List<GroupActivity>groupActivities)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetFileHeader());

            foreach (var gorupActivity in groupActivities)
            {
                sb.AppendLine(GetEventDetails(gorupActivity)); 
            }

            sb.AppendLine("END:VCALENDAR");
            string CalendarItem = sb.ToString();

            return CalendarItem;


            //send the calendar item to the browser
            //HttpContext.Response.ClearHeaders();
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "text/calendar";
            //Response.AddHeader("content-length", CalendarItem.Length.ToString());
            //Response.AddHeader("content-disposition", "attachment; filename=\"" + groupName + ".ics\"");
            //Response.Write(CalendarItem);
            //Response.Flush();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public static string GetFileHeader()
        {
            //create a new stringbuilder instance
            StringBuilder sb = new StringBuilder();

            //start the calendar item
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("PRODID:asing.com.au");
            sb.AppendLine("CALSCALE:GREGORIAN");
            sb.AppendLine("METHOD:PUBLISH");

            //create a time zone if needed, TZID to be used in the event itself
            sb.AppendLine("BEGIN:VTIMEZONE");
            sb.AppendLine("TZID:Australia/Sydney");
            sb.AppendLine("BEGIN:STANDARD");
            sb.AppendLine("TZOFFSETTO:+1000");
            sb.AppendLine("TZOFFSETFROM:+1000");
            sb.AppendLine("END:STANDARD");
            sb.AppendLine("END:VTIMEZONE");

            return sb.ToString(); 
        }

        public static string GetEventDetails(GroupActivity groupActivity)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BEGIN:VEVENT");
            sb.AppendLine("DTSTART:" + groupActivity.StartTime.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("DTEND:" + groupActivity.EndTime.ToString("yyyyMMddTHHmm00"));
            if (groupActivity.Isrecurring)
            {
                sb.AppendLine(String.Concat("RRULE:", "FREQ=", groupActivity.FrequencyName.ToUpper(), ";", "UNTIL=20210731T000000Z"));
            }
            sb.AppendLine("UID:" + (Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddTHHmm00")));
            sb.AppendLine("DTSTAMP:" + DateTime.Now.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("SUMMARY:" + groupActivity.Summary + "");
            sb.AppendLine("LOCATION:" + groupActivity.Location + "");
            sb.AppendLine("DESCRIPTION:" + groupActivity.Description + "");
            sb.AppendLine("PRIORITY:3");
            sb.AppendLine("END:VEVENT");

            return sb.ToString();
        }

    }
}
