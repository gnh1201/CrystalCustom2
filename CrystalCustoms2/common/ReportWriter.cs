using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;

// pdf 작성

namespace CrystalCustoms2.common
{
    public class ReportWriter
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        private static string generateFileName(string extension)
        {
            string fileName = RandomString(15) + "." + extension;

            return fileName;
        }

        public static string write(DataTable dt)
        {
            string pdfname = "reports/" + generateFileName("pdf");
            Document document = new Document(PageSize.A4);
            iTextSharp.text.io.StreamUtil.AddToResourceSearch("iTextAsian.dll");

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfname, FileMode.Create));

            document.Open();

            PdfPTable tbl = new PdfPTable(dt.Columns.Count);
            float[] widths = new float[] { 200f, 400f, 700f };
            // HYGoThic-Medium, HYSMyeongJo-Medium, HYSMyeongJoStd-Medium | UniKS-UCS2-H, UniKS-UCS2-V
            iTextSharp.text.Font tfnt = new iTextSharp.text.Font(BaseFont.CreateFont("HYGoThic-Medium",
                "UniKS-UCS2-H", BaseFont.NOT_EMBEDDED), 14, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font pfnt = new iTextSharp.text.Font(BaseFont.CreateFont("HYGoThic-Medium",
                "UniKS-UCS2-H", BaseFont.NOT_EMBEDDED), 9, iTextSharp.text.Font.NORMAL);

            tbl.SetWidths(widths);
            tbl.WidthPercentage = 100;

            PdfPCell cell = new PdfPCell(new Phrase("견적서", tfnt));
            cell.Colspan = dt.Columns.Count;
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tbl.AddCell(cell);

            PdfPCell hcell = new PdfPCell();
            hcell.HorizontalAlignment = Element.ALIGN_CENTER;
            hcell.BorderWidthBottom = 2;
            hcell.Padding = 3;
            foreach (DataColumn c in dt.Columns)
            {
                hcell.Phrase = new Phrase(c.ColumnName, pfnt);

                tbl.AddCell(hcell);
            }

            foreach (DataRow r in dt.Rows)
            {
                tbl.AddCell(new Phrase(r[0].ToString(), pfnt));
                tbl.AddCell(new Phrase(r[1].ToString(), pfnt));
                tbl.AddCell(new Phrase(r[2].ToString(), pfnt));
                tbl.CompleteRow();
            }
            document.Add(tbl);
            document.Close();

            return pdfname;
        }
    }
}
