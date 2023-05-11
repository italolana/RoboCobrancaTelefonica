using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RoboContaTelefonica.Pipes.Pdf
{
    public class TratarPDF : IPipe
    {
        public object Run(dynamic input)
        {

             string filePath = "example.pdf"; // path to your PDF file

            // create a StringBuilder to store the extracted text
            StringBuilder textBuilder = new StringBuilder();

            // open the PDF document
            using (PdfReader reader = new PdfReader(filePath))
            {
                // loop through each page of the PDF
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    // extract text from the page using the PdfTextExtractor
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, i);

                    // append the extracted text to the StringBuilder
                    textBuilder.Append(pageText);
                }
            }

            // extract the desired part of the text
            string desiredText = textBuilder.ToString().Substring(1, 5);









       
















            return input;
        }
     }
}
