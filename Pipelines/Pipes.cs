using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboContaTelefonica.Pipelines
{
    public class Pipeline : PipelineGroup
    {

        public Pipeline() : base()
        {

            Pipeline("Vivo")
            .Pipe<Pipes.Vivo.BaixarConta>()
            ;
            
            
            Pipeline("Navegador")
            .Pipe<Pipes.Navegador.Close>()
            .Pipe<Pipes.Navegador.Launch>()
            ;
            
            
            Pipeline("TratarPDF")
            .Pipe<Pipes.Pdf.TratarPDF>()
            ;
            
            
            Pipeline("ColetarDownload")
            .Pipe<Pipes.Pdf.ColetarUltimoPDF>()
            ;


            Pipeline("VarreduraPDF")
            .Pipe<Pipes.Pdf.VarreduraPDF>()
            ;







        }   
     }
}
