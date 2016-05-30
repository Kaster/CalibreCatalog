using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasterUtil {
    public class FileUtil {
        public static List<String> readFile(String fileName) {
            List<String> result = new List<String>();
            // Open the selected file to read.
            System.IO.Stream fileStream = File.OpenRead(fileName);

            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream)) {
                while (!reader.EndOfStream) {
                    // Read the next line from the file and write it to the list.
                    String readLine = reader.ReadLine();
                    result.Add(readLine);
                    //MessageBox.Show(readLine);
                }
            }
            fileStream.Close();
            return result;
        }

    }
}
