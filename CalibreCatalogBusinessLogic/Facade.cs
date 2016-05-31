using CalibreCatalogCommon;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KasterUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibreCatalogBusinessLogic {
    /// <summary>
    /// Singletone facade.
    /// </summary>
    public class Facade : IFacade {
        private static Facade instance;
        /// <summary>
        /// Private constructor.
        /// </summary>
        private Facade() { }
        /// <summary>
        /// Only one instance.
        /// </summary>
        public static Facade Instance {
            get {
                if (instance == null) {
                    instance = new Facade();
                }
                return instance;
            }
        }
        /// <inheritDoc/>
        public void generatePdfCatalog(string filename, string targetDirectory) {
            PdfService.generatePdfCatalog(filename, targetDirectory);
        }
    }
}
