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
    public class Facade : IFacade {
        private static Facade instance;

        private Facade() { }

        public static Facade Instance {
            get {
                if (instance == null) {
                    instance = new Facade();
                }
                return instance;
            }
        }

        public void generatePdfCatalog(string filename, string targetDirectory) {
            List<Book> books = CalibreXmlParser.getBooks(filename);
            String pdfDocName = Path.Combine(targetDirectory,"Catalog.pdf");
            KasterLog.Write("\nCreating " + pdfDocName + "...");
            float margin = Utilities.MillimetersToPoints(Convert.ToSingle(20));
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, margin, margin, margin, margin);
            PdfWriter writer = null;
            try {
                // TODO: we need decision where to save the pdf doc (stream, db or file)
                writer = PdfWriter.GetInstance(pdfDoc, new FileStream(pdfDocName, FileMode.Create));
            } catch (System.UnauthorizedAccessException) {
                KasterLog.WriteError("\nAccess to file '" + pdfDocName + "' is denied and file can not be overwritten. Please release the file and try again.\n");
                return;
            } catch (System.IO.IOException) {
                KasterLog.WriteError("\nFile '" + pdfDocName + "' is in use and can not be overwritten. Please release the file and try again.\n");
                return;
            }
            ColumnHeaderFooterUtil pageEventHandler = new ColumnHeaderFooterUtil();
            pageEventHandler.FooterFont = PdfUtil.DEFAULT_FONT;
            String title = "Calibre Catalog\n\r";
            pageEventHandler.Title = title;
            writer.PageEvent = pageEventHandler;
            //
            writer.CloseStream = false;

            pdfDoc.Open();
            //pdfDoc = addPageHeaderContent(pdfDoc, title);
            pdfDoc = addPageBodyContent(pdfDoc, books);
            pdfDoc.Close();
            KasterLog.Write("\nCreated " + pdfDocName + ".");
        }

        /// <summary>
        /// Create and add page content to pdf document.
        /// </summary>
        /// <param name="pdfDoc"></param>
        /// <param name="books">list of books</param>
        /// <returns>PdfPTable content table</returns>
        private static iTextSharp.text.Document addPageBodyContent(iTextSharp.text.Document pdfDoc, List<Book> books) {
            // extrusions table
            iTextSharp.text.pdf.PdfPTable aTable = new iTextSharp.text.pdf.PdfPTable(3);
            aTable.WidthPercentage = 100;
            aTable.SetWidths(new int[] { 2, 3, 20
                //, 3, 7, 5, 16
            });
            // header
            PdfPCell hcellNo = PdfUtil.getHeaderCell("#", Element.ALIGN_CENTER);
            PdfPCell hcellCover = PdfUtil.getHeaderCell("Cover");
            PdfPCell hcellName = PdfUtil.getHeaderCell("Title");

            //PdfPCell hcellQuantity = PdfUtil.getHeaderCell("QTY", Element.ALIGN_CENTER);
            //PdfPCell hcellLength = PdfUtil.getHeaderCell("LENGTH");
            //PdfPCell hcellPanel = PdfUtil.getHeaderCell("PCMK");
            //PdfPCell hcellNote = PdfUtil.getHeaderCell("NOTES");
            PdfPCell[] hcells = new PdfPCell[] { hcellNo, hcellCover, hcellName
                //, hcellQuantity, hcellLength, hcellPanel, hcellNote
            };
            PdfPRow hrow = new PdfPRow(hcells);
            aTable.Rows.Add(hrow);
            // body
            int counter = 0;
            foreach (Book book in books) {
                counter++;
                // no
                PdfPCell cellNo = PdfUtil.getStandardCell(counter.ToString(), Element.ALIGN_RIGHT);
                // name
                String content = book.name;
                content += "\n";
                StringBuilder authors = new StringBuilder();
                int z = 0;
                foreach (String author in book.authors) {
                    authors.Append(author);
                    if (z < book.authors.Count - 1) {
                        authors.Append(", ");
                    }
                    z++;
                }
                content += authors;
                //content += "\n";
                //content += book.publisher;
                PdfPCell cellName = PdfUtil.getStandardCell(content);
                //Image coverImg = PdfService.getPicture(book.cover, 60f, 80f);
                Image coverImg = PdfService.getPicture(book.cover, 45f, 65f);
                PdfPCell cellCover = new PdfPCell(coverImg);
                PdfPCell[] cells = new PdfPCell[] { cellNo, cellCover, cellName};
                PdfPRow row = new PdfPRow(cells);
                aTable.Rows.Add(row);
            }
            pdfDoc.Add(aTable);
            return pdfDoc;
        }
        /// <summary>
        /// Create and get page title.
        /// </summary>
        /// <param name="pdfDoc"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static iTextSharp.text.Document addPageHeaderContent(iTextSharp.text.Document pdfDoc, string text) {
            PdfPTable tTable = new PdfPTable(1);
            tTable.WidthPercentage = 100;
            PdfPCell titleCell = PdfUtil.getTitleCell(text);
            PdfPCell[] tcells = new PdfPCell[] { titleCell };
            PdfPRow trow = new PdfPRow(tcells);
            tTable.Rows.Add(trow);
            pdfDoc.Add(tTable);
            return pdfDoc;
        }
    }
}
