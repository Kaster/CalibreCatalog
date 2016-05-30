using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasterUtil {
    public class PdfUtil {
        /// <summary>
        /// Default font (font: HELVETICA, size: 11, style NORMAL, base color: DARK GRAY).
        /// </summary>
        public static Font DEFAULT_FONT = new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL, BaseColor.DARK_GRAY);

        /// <summary>
        /// Header font (font: HELVETICA, size: 11, style BOLD, base color: DARK GRAY).
        /// </summary>
        public static Font HEADER_FONT = new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD, BaseColor.DARK_GRAY);

        /// <summary>
        /// Title font (font: HELVETICA, size: 14, style BOLD, base color: DARK GRAY */
        /// </summary>
        public static Font TITLE_FONT = new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD, BaseColor.DARK_GRAY);

        /// <summary>
        /// Get table's cell and fill with given text in given font.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="horizontalAlignment"></param>
        /// <returns></returns>
        public static PdfPCell getCell(String text, Font font, int horizontalAlignment) {
            PdfPCell cell = new PdfPCell();
            cell.UseAscender = true;
            cell.UseDescender = true;
            Paragraph p = new iTextSharp.text.Paragraph(text, font);
            p.Alignment = horizontalAlignment;
            cell.AddElement(p);
            return cell;
        }

        /// <summary>
        /// Get default table's cell and fill with given text in default font.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static PdfPCell getStandardCell(String text) {
            PdfPCell cell = getBaseStandardCell(text, Element.ALIGN_LEFT);
            return cell;
        }

        /// <summary>
        /// Get default table's cell and fill with given text in default font.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="horizontalAlignment"></param>
        /// <returns></returns>
        public static PdfPCell getStandardCell(String text, int horizontalAlignment) {
            PdfPCell cell = getBaseStandardCell(text, horizontalAlignment);
            return cell;
        }

        /// <summary>
        /// Get default table's cell and fill with given text in default font.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="horizontalAlignment"></param>
        /// <returns></returns>
        private static PdfPCell getBaseStandardCell(String text, int horizontalAlignment) {
            PdfPCell cell = getCell(text, DEFAULT_FONT, horizontalAlignment);
            cell.BorderColor = BaseColor.LIGHT_GRAY;
            return cell;
        }

        /// <summary>
        /// Get header table's cell and fill with given text in header font in left alignment.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static PdfPCell getHeaderCell(String text) {
            PdfPCell cell = getBaseHeaderCell(text, Element.ALIGN_LEFT);
            return cell;
        }

        /// <summary>
        /// Get header table's cell and fill with given text in header font and given alignment.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="horizontalAlignment"></param>
        /// <returns></returns>
        public static PdfPCell getHeaderCell(String text, int horizontalAlignment) {
            PdfPCell cell = getBaseHeaderCell(text, horizontalAlignment);
            return cell;
        }

        /// <summary>
        /// Get header table's cell and fill with given text in header font and given alignment.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="horizontalAlignment"></param>
        /// <returns></returns>
        private static PdfPCell getBaseHeaderCell(String text, int horizontalAlignment) {
            PdfPCell cell = getCell(text, HEADER_FONT, horizontalAlignment);
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.BorderColor = BaseColor.GRAY;
            return cell;
        }

        /// <summary>
        /// Get title table's cell and fill with given text in header font and horizontaly centered.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static PdfPCell getTitleCell(String text) {
            PdfPCell cell = getCell(text, TITLE_FONT, Element.ALIGN_CENTER);
            cell.Border = 0;
            return cell;
        }
    }
}
