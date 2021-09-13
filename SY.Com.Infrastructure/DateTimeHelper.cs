using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SY.Com.Infrastructure
{
    /// <summary>
    /// DateTime帮助类
    /// </summary>
    public static class DateTimeEx
    {
        /// <summary>
        /// 把日期转换成“yyyy-MM-dd HH:mm:ss”的字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SToLongDateTimeStr(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 把日期转换成“yyyy-MM-dd HH:mm:ss”的DateTime类型
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime SToLongDateTime(this DateTime dt)
        {
            return Convert.ToDateTime(dt.SToLongDateTimeStr());
        }

        /// <summary>
        /// 两个时间的间隔天数
        /// </summary>
        /// <param name="DateTimeOld">开始时间</param>
        /// <param name="DateTimeNew">结束时间</param>
        /// <returns>相隔天数int[],0为天数、1为小时数、2为分钟数、3为秒数</returns>
        public static int[] DateTimeDiff(DateTime DateTimeOld, DateTime DateTimeNew)
        {
            TimeSpan ts1 = new TimeSpan(DateTimeOld.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTimeNew.Ticks);
            //TimeSpan ts = ts1.Subtract(ts2).Duration();
            TimeSpan ts = ts2.Subtract(ts1);
            int[] times = new int[4];
            times[0] = ts.Days;
            times[1] = ts.Hours;
            times[2] = ts.Minutes;
            times[3] = ts.Seconds;
            return times;
        }

        //时间戳转为C#格式时间
        public static DateTime StampToDateTime(string timeStamp)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);

            return dateTimeStart.Add(toNow);
        }

        //DateTime时间格式转换为Unix时间戳格式
        public static int DateTimeToStamp(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        //根据出生日期获取岁月日
        public static string GetAge(string csrq) {
            if (string.IsNullOrEmpty(csrq))
            {
                csrq = DateTime.Now.ToShortDateString();
            }
            DateTime dtNow = DateTime.Now;
            DateTime dtCSRQ = Convert.ToDateTime(csrq);
            string strAge = string.Empty;                         // 年龄的字符串表示
            int intYear = 0;                                    // 岁
            int intMonth = 0;                                    // 月
            int intDay = 0;                                    // 天


            // 计算天数
            intDay = dtNow.Day - dtCSRQ.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }
            // 计算月数
            intMonth = dtNow.Month - dtCSRQ.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }
            // 计算年数
            intYear = dtNow.Year - dtCSRQ.Year;
            if (intYear <= 0) { intYear = 0; }
            strAge = intYear.ToString() + "|" + intMonth.ToString() + "|" + intDay.ToString();
            return strAge;
        }

        //根据岁月日获取出生日期
        public static string GetCSRQ(int year, int month,int day)
        {
            DateTime dtNow = DateTime.Now;
            int itYear = 0;                                    // 岁
            int itMonth = 0;                                    // 月
            int itDay = 0;                                    // 天

            // 计算年
            itYear = dtNow.Year - year;
            // 计算月
            itMonth = dtNow.Month - month;
            // 计算日
            itDay = dtNow.Day - day;
           
            if (itDay < 0)
            {
                itMonth -= 1;
                itDay = itDay + 31;
            }
            if (itMonth < 0)
            {
                itYear -= 1;
                itMonth = itMonth + 12;
            }
            if (itMonth == 0) {
                itMonth = month;
            }
            if (itDay == 0)
            {
                itDay = day;
            }

            return itYear + "-" + itMonth + "-" + itDay;
        }
    }
}