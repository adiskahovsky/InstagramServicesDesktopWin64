using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Instagram
{
    public class NumberChangeClass
    {
        private IWebDriver _driver;

        public NumberChangeClass()
        {
            _driver = new PhantomJSDriver();
        }

        public void AddNewInstagramNumber(string number, string login, string password)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/?source=auth_switcher");

            _driver.FindElement(By.Name("username")).SendKeys(login);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _driver.FindElement(By.XPath("//*[@id=\"react-root\"]/section/main/div/article/div/div[1]/div/form/div[3]/button")).Click();

            _driver.Navigate().GoToUrl("https://www.instagram.com/accounts/edit/"); //need sleep
            _driver.SwitchTo().Frame(_driver.FindElement(By.ClassName("kWXsT"))); //need to find
            IWebElement phoneTab = _driver.FindElement(By.Id("pepPhone")); //uncorrect id
            phoneTab.Clear(); phoneTab.SendKeys(number);

            _driver.FindElement(By.XPath("//*[@id=\"react-root\"]/section/main/div/article/form/div[10]/div/div/button[1]")).Click();
        }

        public void RemoveInstagramNumber()
        {
            IWebElement phoneTab = _driver.FindElement(By.XPath("//*[@id=\"pepPhone Number\"]"));
            phoneTab.Clear(); phoneTab.SendKeys("375445553535");

            _driver.FindElement(By.XPath("//*[@id=\"react-root\"]/section/main/div/article/form/div[10]/div/div/button[1]")).Click();
            _driver.Close();
        }
    }
}