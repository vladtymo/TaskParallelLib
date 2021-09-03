using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_async_await
{
    public class Utils
    {
        public static double BytesToKilobytes(long bytes)
        {
            return bytes / 1024d;
        }
        public static double BytesToMegabytes(long bytes)
        {
            return bytes / 1024d / 1024d;
        }
        public static double BytesToGigabytes(long bytes)
        {
            return bytes / 1024d / 1024d / 1024d;
        }

        static string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        const int kilo = 1024;
        public static string BytesToReadableFormat(long bytes)
        {
            double len = bytes;
            int order = 0;
            while (len >= kilo && order < sizes.Length - 1)
            {
                order++;
                len = len / kilo;
            }
            
            return $"{Math.Round(len, 2)}{sizes[order]}";
        }
    }
}
