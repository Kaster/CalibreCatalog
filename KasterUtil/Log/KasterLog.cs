using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasterUtil {
    public class KasterLog {
        /// <summary> Controls whether the log are being printed or not. </summary>
        public static bool on = true;
        private static readonly string logFile = "KasterLog.txt";

        /// <summary>
        /// Write a simple log line.
        /// </summary>
        /// <param name="str"></param>
        public static void Write(string str) {
            if (on) {
                using (StreamWriter w = File.AppendText(logFile)) {
                    w.WriteLine(DateTime.Now + ": " + str);
                }
            }
        }

        /// <summary>
        /// Write an error log line.
        /// </summary>
        /// <param name="str"></param>
        public static void WriteError(string str) {
            using (StreamWriter w = File.AppendText(logFile)) {
                w.WriteLine(DateTime.Now + ": " + str);
            }
        }
    }
}
