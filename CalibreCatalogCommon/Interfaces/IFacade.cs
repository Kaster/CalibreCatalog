
namespace CalibreCatalogCommon {
    public interface IFacade {
        /// <summary>
        /// Generate PDF catalog from exported XML data.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="targetDirectory"></param>
        void generatePdfCatalog(string filename, string targetDirectory);
    }
}
