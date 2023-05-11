using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V110.Network;
using System.Runtime.CompilerServices;

namespace RoboContaTelefonica.Pipes.Pdf
{
    public class ColetarUltimoPDF : IPipe
    {

        public object Run(dynamic input)
        {




            Thread.Sleep(15000); 

            //coleta o ultimo pdf baixado 
            string downloadFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            DirectoryInfo downloadFolder = new DirectoryInfo(downloadFolderPath);
            FileInfo[] files = downloadFolder.GetFiles();
            FileInfo lastDownloadedFile = null;

            foreach (FileInfo file in files)
            {
                if (lastDownloadedFile == null || file.LastWriteTime > lastDownloadedFile.LastWriteTime)
                {
                    lastDownloadedFile = file;
                }
            }

          

            input.PDFName = lastDownloadedFile.ToString();



            Thread.Sleep(2000);
             //coleta a primeira ocorrencia da palavra   
            string filePath = lastDownloadedFile.ToString();
            string searchSentence = "DETALHAMENTO";
            int FirstLoc = 0;

            using (PdfReader reader = new PdfReader(filePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string pageText = PdfTextExtractor.GetTextFromPage(reader, i);
                    if (pageText.Contains(searchSentence))
                    {
                       FirstLoc = i;
                        break;
                    }

                }
            }

            input.FirstLoc=FirstLoc;
            Thread.Sleep(2000);














            return input;
        }
    }
}
