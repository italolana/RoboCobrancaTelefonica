using System;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace RoboContaTelefonica
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var input = new ExpandoObject();
            Pipelines.Pipeline pipeline = new Pipelines.Pipeline();





            try
            {
                pipeline["Navegador"].Run(input);
                pipeline["Vivo"].Run(input);
                pipeline["ColetarDownload"].Run(input);
                pipeline["VarreduraPDF"].Run(input);


            }
            catch (Exception)
            {




                throw;
            }













        }
    }
}
