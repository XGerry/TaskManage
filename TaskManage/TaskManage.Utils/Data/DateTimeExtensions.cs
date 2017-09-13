using System;

namespace TaskManage.Utils.Data
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 返回Unix時間戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long UnixTicks(this DateTime dt)
        {
            var unixTimestampOrigin = new DateTime(1970, 1, 1);
            return (long)new TimeSpan(dt.Ticks - unixTimestampOrigin.Ticks).TotalMilliseconds;
        }
    }
}
