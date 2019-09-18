using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Test.SharedHelper;

namespace Test.Helpers
{
   public static class TestBaseHelper
    {
        public static void TestBase()

        {
            string userName1 = "UserForTest";
            Password = "xyz";
            string lastName1 = "LastNameUser";
            string randomText = "TestText";
            string phoneNumber = "1234567890";
            _driver = new ChromeDriver();

            //_driver = new ChromeDriver(Directory.GetCurrentDirectory());

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            _driver.FindElement(By.LinkText("Register")).Click();
            Random random = new Random();
            int number = random.Next(10, 3000);
            UserName = userName1 + number;
            _driver.FindElement(By.Id("customer.firstName")).SendKeys(userName1 + number);
            _driver.FindElement(By.Id("customer.lastName")).SendKeys(lastName1 + number);
            _driver.FindElement(By.Id("customer.address.street")).SendKeys(randomText);
            _driver.FindElement(By.Id("customer.address.city")).SendKeys(randomText);
            _driver.FindElement(By.Id("customer.address.state")).SendKeys(randomText);
            _driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(randomText);
            _driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(phoneNumber);
            _driver.FindElement(By.Id("customer.ssn")).SendKeys(randomText);
            _driver.FindElement(By.Id("customer.username")).SendKeys(userName1 + number);
            _driver.FindElement(By.Id("customer.password")).SendKeys(Password);
            _driver.FindElement(By.Id("repeatedPassword")).SendKeys(Password);

            //_driver.FindElement(By.TagName("form")).Submit();
            _driver.FindElement(By.XPath("//*[@id='customerForm']/table/tbody/tr[13]/td[2]/input")).Click();

        }


    }
}
