using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace RoboContaTelefonica.Pipes.Pdf
{
    public class VarreduraPDF : IPipe
    {

        public object Run(dynamic input)
        {
            Thread.Sleep(2000);

            string path = input.PDFName;



           
            string pattern = @"(\d{2}-\d{5}-\d{4})\sSMART EMPRESAS (3|12)GB TE\s(\d{1,2},\d{2})";
            List<string> NumberVet = new List<string>();
            List<string> ValueVet = new List<string>();

            PdfReader pdfReader = new PdfReader(path);

            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                string pageText = PdfTextExtractor.GetTextFromPage(pdfReader, page);
                MatchCollection matches = Regex.Matches(pageText, pattern);

                foreach (Match match in matches)
                {
                    string phone = match.Groups[1].Value;
                    string value = match.Groups[3].Value;
                    NumberVet.Add(phone);
                    ValueVet.Add(value);
                   
                }
            }



            for (int i = 0; i < ValueVet.Count; i++)
            {

                Console.WriteLine(NumberVet[i]+ " Valor: "+ ValueVet[i]);



            }
           




            return input;
        }
    }
}
