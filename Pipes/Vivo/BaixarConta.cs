using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoboContaTelefonica.Pipes.Vivo
{
    public class BaixarConta : IPipe
    {

        public object Run(dynamic input)
        {
           

           
            ChromeDriver driver = input.Driver;


            //login
            driver.FindElement(By.XPath("//*[@id=\"login-input\"]")).SendKeys("aroldo@transmartins.com.br");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"form-login\"]/div[4]/button")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"input-document-id\"]")).SendKeys("653.389.876-00");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"form-document-id\"]/div[3]/button")).Click();  
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"form-login\"]/div[2]/div/div/input")).SendKeys("vivoETM2023");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"form-login\"]/div[4]/button")).Click();


            Thread.Sleep(4000);


            //NESSA PARTE VAI SER NECESSARIO USAR WAIT





            //esperar a pagina estar disponivel
            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//*[@id=\"main-content\"]/div[2]/main/section/div[1]/div/div/div/h1")));


            }
            catch (Exception)
            {

            }
           
            



            //fechar a aba de download
            try
            {
                driver.FindElement(By.XPath("/html/body/div[7]/div/div/div[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id=\"cancel-download-confirm-button\"]")).Click();
            }
            catch (Exception)
            {
                
                
            }
           



            Thread.Sleep(2000);

            //escolher filial
            driver.FindElement(By.XPath("//*[@id=\"customer-select-desktop\"]/p")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"customer-select-slider-list\"]/ul/li/ul/li[1]/div/h1")).Click();
            Thread.Sleep(2000);


            //abrir faturas
            driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div[2]/main/section/div[2]/div/div/div[1]/div/div[1]/div/div/div[2]/div/button[1]")).Click();
            Thread.Sleep(2000);

            //baixar fatura
            driver.FindElement(By.XPath("//*[@id=\"dropdown-right__BV_toggle_\"]/span")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@id='dropdown-right']/div/button")).Click();










            return input;
        }
    }
}
