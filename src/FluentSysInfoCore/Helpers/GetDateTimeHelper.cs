/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo.Core


---------------------------------------------------------------------------------------------*/



using System;

namespace FluentSysInfo.Core.Helpers
{
    internal sealed class GetDateTimeHelper
    {

        private int NumberOfProperties => 7;

        public string GetInfo()
        {
            return new JsonHelper().ConvertDateTimeResultToJsonFormat(
                                              $"{GetDateTime()}" +
                                              $",{GetDateTimeUTC()}" +
                                              $",{GetDate()},{GetTime()}" +
                                              $",{GetLongDate()}" +
                                              $",{GetDayOfWeek()}," +
                                              $"{GetFullDateTime()}",
                                              NumberOfProperties);
        }



        // Note 👉 We replaced the ',' character with a normal space because ',' character will interfere with spliting operation further ⬇

        private string GetDateTime() => DateTime.Now.ToString().Replace(',', ' ');

        private string GetDateTimeUTC() => DateTime.UtcNow.ToString().Replace(',', ' ');



        private string GetDate() => DateTime.Now.ToShortDateString().Replace(',', ' ');
        private string GetLongDate() => DateTime.Now.ToLongDateString().Replace(',', ' ');



        private string GetTime() => DateTime.Now.ToLongTimeString().Replace(',', ' ');

        private string GetDayOfWeek() => DateTime.Now.DayOfWeek.ToString().Replace(',', ' ');


        private string GetFullDateTime() => $"{GetLongDate().Replace(',', ' ')}  {GetTime().Replace(',', ' ')}";


    }
}
