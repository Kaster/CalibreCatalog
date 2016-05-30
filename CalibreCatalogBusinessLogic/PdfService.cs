using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;

namespace CalibreCatalogBusinessLogic {
    public class PdfService {
        public static Image getPicture(string cover, float width, float height) {
            string imageURL = cover;
            Image img = Image.GetInstance(imageURL);
            //Resize image depend upon your need
            img.ScaleToFit(width, height);
            //Give space before image
            img.SpacingBefore = 0;
            //Give some space after the image
            img.SpacingAfter = 0;
            img.Alignment = Element.ALIGN_MIDDLE;
            return img;
        }
    }
}
