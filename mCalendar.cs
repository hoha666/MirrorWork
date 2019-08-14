using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace MirrorWork
{
    public class mCalendar
    {
        public static DateTime untilNow(TimeSpan ts)
        {
            DateTime original = DateTime.Now;
            DateTime updated = original.Add(ts);
            return updated;
        }
        public static DateTime persianNow()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(pc.GetYear(now), pc.GetMonth(now), pc.GetDayOfMonth(now), pc.GetHour(now), pc.GetMinute(now), pc.GetSecond(now));

            return dt;

        }
        public static DateTime jalaliTogorgorian(int year, int month, int day, int hour, int minute, int second)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }
        public static DateTime jalaliTogorgorian(string persianDateFormat)
        {
            if (persianDateFormat.Contains("."))
            {
                string[] dates = new string[3];
                dates = persianDateFormat.Split('.');
                PersianCalendar pc = new PersianCalendar();
                try
                {
                    return pc.ToDateTime(int.Parse("13" + dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), 6, 0, 0, 0);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
            else
            {
                string[] dates = new string[3];
                dates = persianDateFormat.Split('/');
                if (dates[0].Length == 2)
                {
                    PersianCalendar pc = new PersianCalendar();
                    try
                    {
                        return pc.ToDateTime(int.Parse("13" + dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), 6, 0, 0, 0);
                    }
                    catch
                    {
                        return DateTime.Now;
                    }


                }
                else
                {

                    PersianCalendar pc = new PersianCalendar();
                    try
                    {
                        return pc.ToDateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]), 6, 0, 0, 0);
                    }
                    catch
                    {
                        return DateTime.Now;
                    }
                }
            }
        }
        public static DateTime gorgorianTojalali(long Ticks)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime now = new DateTime(Ticks);
            DateTime dt = new DateTime(pc.GetYear(now), pc.GetMonth(now), pc.GetDayOfMonth(now), pc.GetHour(now), pc.GetMinute(now), pc.GetSecond(now));
            return dt;
        }
        public static DateTime gorgorianTojalali(string anyKnownFormatDate)
        {
            try
            {
                long tic = long.Parse(anyKnownFormatDate);
                return gorgorianTojalali(tic);
            }
            catch (Exception e)
            {
                return DateTime.Now;
            }
        }

        public static string persianTostring()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime now = DateTime.Now;
            int y = pc.GetYear(now);
            int m = pc.GetMonth(now);
            int d = pc.GetDayOfMonth(now);
            // DateTime dt = new DateTime(y,m ,d, pc.GetHour(now), pc.GetMinute(now), pc.GetSecond(now));
            return persian_day(d) + " " + persian_month(m) + " " + y.ToString();

        }
        public static string persianTostring(long ticks)
        {

            PersianCalendar pc = new PersianCalendar();
            DateTime now = new DateTime(ticks);
            int y = pc.GetYear(now);
            int m = pc.GetMonth(now);
            int d = pc.GetDayOfMonth(now);
            //  DateTime dt = new DateTime(pc.GetYear(now), pc.GetMonth(now), pc.GetDayOfMonth(now), pc.GetHour(now), pc.GetMinute(now), pc.GetSecond(now));
            //  return persian_day(dt.Day) + " " + persian_month(dt.Month) + " " + dt.Year.ToString();
            return persian_day(d) + " " + persian_month(m) + " " + y.ToString();
        }
        public static string persianTostringwithclock(long ticks)
        {

            PersianCalendar pc = new PersianCalendar();
            DateTime now = new DateTime(ticks);
            int y = pc.GetYear(now);
            int m = pc.GetMonth(now);
            int d = pc.GetDayOfMonth(now);
            //  DateTime dt = new DateTime(pc.GetYear(now), pc.GetMonth(now), pc.GetDayOfMonth(now), pc.GetHour(now), pc.GetMinute(now), pc.GetSecond(now));
            //  return persian_day(dt.Day) + " " + persian_month(dt.Month) + " " + dt.Year.ToString();
            return persian_day(d) + " " + persian_month(m) + " " + y.ToString() + "        " + now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second.ToString();
        }
        public static string persian_month(int month)
        {
            switch (month)
            {
                case 1:
                    {
                        return "فروردین";
                    }
                case 2:
                    {
                        return "اردیبهشت";
                    }
                case 3:
                    {
                        return "خرداد";
                    }
                case 4:
                    {
                        return "تیر";
                    }
                case 5:
                    {
                        return "مرداد";
                    }
                case 6:
                    {
                        return "شهریور";
                    }
                case 7:
                    {
                        return "مهر";
                    }
                case 8:
                    {
                        return "آبان";
                    }
                case 9:
                    {
                        return "آذر";
                    }
                case 10:
                    {
                        return "دی";
                    }
                case 11:
                    {
                        return "بهمن";
                    }
                case 12:
                    {
                        return "اسفند";
                    }
            }
            return "خطا";

        }
        public static string persian_day(int day)
        {
            switch (day)
            {
                case 1:
                    {
                        return "یکم";
                    }
                case 2:
                    {
                        return "دوم";
                    }
                case 3:
                    {
                        return "سوم";
                    }
                case 4:
                    {
                        return "چهارم";
                    }
                case 5:
                    {
                        return "پنجم";
                    }
                case 6:
                    {
                        return "ششم";
                    }
                case 7:
                    {
                        return "هفتم";
                    }
                case 8:
                    {
                        return "هشتم";
                    }
                case 9:
                    {
                        return "نهم";
                    }
                case 10:
                    {
                        return "دهم";
                    }
                case 11:
                    {
                        return "یازدهم";
                    }
                case 12:
                    {
                        return "دوازدهم";
                    }
                case 13:
                    {
                        return "سیزدهم";
                    }
                case 14:
                    {
                        return "چهاردهم";
                    }
                case 15:
                    {
                        return "پانزدهم";
                    }
                case 16:
                    {
                        return "شانزدهم";
                    }
                case 17:
                    {
                        return "هفدهم";
                    }
                case 18:
                    {
                        return "هجدهم";
                    }
                case 19:
                    {
                        return "نوزدهم";
                    }
                case 20:
                    {
                        return "بیستم";
                    }
                case 21:
                    {
                        return "بیست و یکم";
                    }
                case 22:
                    {
                        return "بیست و دوم";
                    }
                case 23:
                    {
                        return "بیست و سوم";
                    }
                case 24:
                    {
                        return "بیست و چهارم";
                    }
                case 25:
                    {
                        return "بیست و پنجم";
                    }
                case 26:
                    {
                        return "بیست و ششم";
                    }
                case 27:
                    {
                        return "بیست و هفتم";
                    }
                case 28:
                    {
                        return "بیست و هشتم";
                    }
                case 29:
                    {
                        return "بیست و نهم";
                    }
                case 30:
                    {
                        return "سی ام";
                    }
                case 31:
                    {
                        return "سی و یکم";
                    }
            }
            return "خطا";

        }
        /// <summary>
        /// yek tarikhe farsi ra az txtbox migirad va pas az tabdil vahede yeksane ticks an ra pas midahad
        /// </summary>
        /// <param name="mytext"></param>
        /// <returns></returns>
        public static string textboxToTicks(string mytext)
        {
            string day = "", month = "", year = "";
            string t = "";
            int i = 0;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    day = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    month = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {


                t += mytext[i].ToString();
            }
            year = t;

            return jalaliTogorgorian(int.Parse(year), int.Parse(month), int.Parse(day), 12, 0, 0).Ticks.ToString();

        }
        public static string textboxToTicksfarsiorder(string mytext)
        {
            string day = "", month = "", year = "";
            string t = "";
            int i = 0;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    year = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    month = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {


                t += mytext[i].ToString();
            }
            day = t;

            return jalaliTogorgorian(int.Parse(year), int.Parse(month), int.Parse(day), 0, 0, 0).Ticks.ToString();

        }
        public static string textboxToTicksfarsiorder2(string mytext)
        {
            string day = "", month = "", year = "";
            string t = "";
            int i = 0;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    year = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    month = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {


                t += mytext[i].ToString();
            }
            day = t;

            return jalaliTogorgorian(int.Parse("13" + year), int.Parse(month), int.Parse(day), 0, 0, 0).Ticks.ToString();

        }
        public static string textboxToTicksfarsiorder3(string mytext)
        {
            string day = "", month = "", year = "";
            string t = "";
            int i = 0;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    year = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {
                if (mytext[i].ToString() == "/")
                {
                    month = t;
                    break;
                }
                t += mytext[i].ToString();
            }
            t = "";
            i++;
            for (; i < mytext.Length; i++)
            {


                t += mytext[i].ToString();
            }
            day = t;

            return jalaliTogorgorian(int.Parse("13" + year) + 1, int.Parse(month), int.Parse(day), 0, 0, 0).Ticks.ToString();

        }
        public static string TicksToTextbox(long ticks)
        {
            string output = "";
            DateTime dt = gorgorianTojalali(ticks);
            //output = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + ;
            output = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString();
            return output;

        }
        public static string TicksToTextbox(string ticks2)
        {
            long ticks = long.Parse(ticks2);
            string output = "";
            DateTime dt = gorgorianTojalali(ticks);
            //output = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + ;
            output = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString();
            return output;

        }

        private static string[] formats = new string[]
        {
            "MM/dd/yyyy HH:mm:ss tt",
            "MM/dd/yyyy HH:mm:ss",
            "M/dd/yyyy H:mm:ss tt",
            "M/dd/yyyy H:mm:ss"        
        };

        public static DateTime ParseDate(string input)// 5/20/2014  3:21:30 PM
        {
            string month = "";
            string day = "";
            string year = "";
            string hour = "";
            string minute = "";
            string second = "";
            bool isPM = false;
            int ct = 0;
            int ct2 = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == "/" || input[i].ToString() == ":")
                    ct++;
                if (ct == 0 && input[i].ToString() != "/")
                {
                    month += input[i];

                }
                if (ct == 1 && input[i].ToString() != "/")
                {
                    day += input[i];

                }
                if (ct == 2 && input[i].ToString() != "/")
                {
                    if (input[i].ToString() == " ")
                        ct++;
                    else
                        year += input[i];

                }
                if (ct == 3 && input[i].ToString() != ":" && input[i].ToString() != " ")
                {
                    hour += input[i];

                }
                if (ct == 4 && input[i].ToString() != ":" && input[i].ToString() != " ")
                {
                    minute += input[i];

                }
                if (ct == 5 && input[i].ToString() != ":")
                {
                    if (input[i].ToString() == " ")
                        ct++;
                    else
                    {
                        second += input[i];

                    }

                }
                if (ct == 6 && input[i].ToString() != ":" && input[i].ToString() != " ")
                {
                    if (input[i].ToString() == "p" || input[i].ToString() == "P")
                        isPM = true;
                }

            }
            //month = mDecoder.Reverse(month);
            //day = mDecoder.Reverse(day);
            //year = mDecoder.Reverse(year);
            //hour = mDecoder.Reverse(hour);
            //minute = mDecoder.Reverse(minute);
            //second = mDecoder.Reverse(second);
            if (isPM)
            {
                int hou = int.Parse(hour);
                hou += 12;
                hour = hou.ToString();
            }
            DateTime result = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), int.Parse(second));

            return result;
        }
    }
}
