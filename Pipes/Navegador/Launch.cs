using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboContaTelefonica.Pipes.Navegador
{
    public class Launch : IPipe
    {
        public object Run(dynamic input)
        {


            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://mve.vivo.com.br/oauth?logout=true");








            input.Driver = driver;

            return input;
        }
    }
}
