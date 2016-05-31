using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibreCatalogCommon {
    public class Book {
        public String name { get; set; }
        public String cover { get; set; }
        public String publisher { get; set; }
        public long size { get; set; }
        public String isbn { get; set; }
        public DateTime timestamp { get; set; }
        public List<String> authors { get; set; }
    }
}
