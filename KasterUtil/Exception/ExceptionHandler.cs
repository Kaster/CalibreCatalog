using KasterUtil.Exception;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KasterUtil {
    /// <summary>
    /// Exception handler
    /// </summary>
    public class ExceptionHandler {
        /// <summary>
        /// Gets path of the next dump file
        /// </summary>
        /// <returns></returns>
        public static string AcquireDumpPath() {
            string dumpFolder = null;
            try {
                dumpFolder = Path.Combine(Application.ExecutablePath,"ErrorDump");
                if (!Directory.Exists(dumpFolder)) {
                    Directory.CreateDirectory(dumpFolder);
                }
            } catch {
            }
            if (string.IsNullOrEmpty(dumpFolder)) {
                dumpFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            DateTime dt = DateTime.Now;
            string fname = string.Concat(
                dt.Year, "-",
                dt.Month, "-",
                dt.Day, "-",
                dt.Hour, "-",
                dt.Minute, "-",
                dt.Second, "-",
                dt.Millisecond,
                ".exceptiondump"
            );

            string dumpPath = null;
            int attempts = 0;
            do {
                if (attempts == 0) {
                    dumpPath = Path.Combine(dumpFolder, fname);
                } else if (attempts == 3) {
                    break;
                } else {
                    dumpPath = Path.Combine(dumpFolder, fname + attempts);
                }
                attempts++;
            } while (File.Exists(dumpPath));

            return dumpPath;
        }

        /// <summary>
        /// Passes a message to user
        /// </summary>
        /// <param name="info"></param>
        public static void Inform(string info, string exceptionDumpFolderPath) {
            if (!string.IsNullOrEmpty(info) && !string.IsNullOrEmpty(exceptionDumpFolderPath)) {
                MessageBox.Show(info.Trim(), "Exception Handler", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                bool error = false;
                string msg = "";
                string dumpFolder = System.IO.Path.GetDirectoryName(exceptionDumpFolderPath);
                string edf = @"" + dumpFolder;
                try {
                    if (Directory.Exists(edf)) {
                        Process.Start("explorer.exe", edf);
                    }
                } catch (InvalidOperationException ex) {
                    error = true;
                    msg = ex.Message;
                } catch (Win32Exception ex) {
                    error = true;
                    msg = ex.Message;
                } catch (FileNotFoundException ex) {
                    error = true;
                    msg = ex.Message;
                }
                if (error) {
                    MessageBox.Show("\nExceptions dump folder opening was not successful.\n\n\n" + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles an exception
        /// </summary>
        /// <param name="e"></param>
        public static void Handle(System.Exception e) {
            string contents = null;
            string dumpPath = AcquireDumpPath();
            if (!string.IsNullOrEmpty(dumpPath)) {
                if (e != null && e is BaseException && !((BaseException)e).toDump) {
                    Inform(((BaseException)e).message, dumpPath);
                } else if (
                    (e is System.Data.SqlClient.SqlException && e.Message != null && e.Message.Contains("error: 26"))
                ) {
                    Inform("System unable to connect to a database.\nERROR: " + e.Message + "\n", dumpPath);
                } else {
                    try {
                        StringBuilder sb = new StringBuilder();
                        System.Exception coreException = null;
                        if (e is BaseException) {
                            BaseException be = (BaseException)e;
                            sb.Append("A exception has been thrown [name=");
                            sb.Append(be.name);
                            sb.Append("].\n\nThe message is:\n");
                            sb.Append(be.message);
                            sb.Append("\n\n");
                            sb.Append("Stack trace:\n");
                            sb.Append(be.StackTrace);
                            sb.Append("\n\n");
                            coreException = be.originalException;
                        } else {
                            coreException = e;
                        }

                        if (coreException != null) {
                            sb.Append("Core exception:\n");
                            sb.Append("Type: ");
                            sb.Append(coreException.GetType().ToString());
                            sb.Append("\n");
                            sb.Append("Message:\n");
                            sb.Append(coreException.Message);
                            sb.Append("\n\n");
                            sb.Append("Stack trace:\n");
                            sb.Append(coreException.StackTrace);
                            sb.Append("\n\n");
                        }

                        contents = sb.ToString().Trim();

                        TextWriter tw = new StreamWriter(dumpPath);
                        tw.WriteLine(contents);
                        tw.Close();
                        Inform(string.Concat("An exception occured. The dump can be found at: ", dumpPath, "\n\n"), dumpPath);
                    } catch (System.Exception ee) {
                        string info = string.Concat(
                            "Failed to dump an exception report. The ExceptionHandler has thrown an exception: ",
                            ee.Message, "\n\n", "The contents were: ", contents);
                        Inform(info, dumpPath);
                    }
                }
            } else {
                string info = string.Concat(
                    "An exception was caight, but the system was unable to allocate file for the dump.\n\n",
                    contents, "\n\n");
                Inform(info, null);
            }
        }
    }
}
