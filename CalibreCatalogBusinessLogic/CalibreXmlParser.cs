using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalibreCatalogCommon;
using KasterUtil;
using System.Xml;

namespace CalibreCatalogBusinessLogic {
    public class CalibreXmlParser {
        internal static List<Book> getBooks(string filename) {
            List<Book> result = new List<Book>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/calibredb/record");
            String publisher = "", size = "", isbn = "", title = "", timestamp = "", cover = "";
            foreach (XmlNode node in nodeList) {
                if (node.SelectSingleNode("publisher") != null) {
                    publisher = node.SelectSingleNode("publisher").InnerText;
                } else {
                    publisher = "";
                }
                if (node.SelectSingleNode("size") != null) {
                    size = node.SelectSingleNode("size").InnerText;
                } else {
                    size = "0";
                }
                if (node.SelectSingleNode("isbn") != null) {
                    isbn = node.SelectSingleNode("isbn").InnerText;
                } else {
                    isbn = "";
                }
                title = node.SelectSingleNode("title").InnerText;
                if (node.SelectSingleNode("timestamp") != null) {
                    timestamp = node.SelectSingleNode("timestamp").InnerText;
                } else {
                    timestamp = "";
                }
                cover = node.SelectSingleNode("cover").InnerText;
                List<String> authors = new List<String>();
                XmlNode authorsNode = node.SelectSingleNode("authors");
                KasterLog.Write(title);
                if (authorsNode.HasChildNodes) {
                    XmlNodeList children = authorsNode.ChildNodes;
                    foreach (XmlNode child in children) {
                        authors.Add(child.InnerText);
                    }
                }
                Book book = new Book();
                book.name = title;
                book.publisher = publisher;
                book.size = long.Parse(size);
                book.isbn = isbn;
                //book.timestamp = timestamp != null?DateTime.Parse(timestamp):"";
                book.cover = cover;
                book.authors = authors;
                result.Add(book);
            }
            return result;
        }
    }
}
