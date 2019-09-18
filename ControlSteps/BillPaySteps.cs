using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static Test.SharedHelper;

namespace Test.ControlSteps
{
    [Binding]
    public sealed class BillPaySteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
      

        public BillPaySteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I click on BillPay link")]
        public void WhenIClickOnBillPayLink()
        {
            _driver.FindElement(By.LinkText("Bill Pay")).Click();
        }

        [Then(@"I should land on the BillPay Page")]
        public void ThenIShouldLandOnTheBillPayPage()
        {
            string title = _driver.Title;
            Assert.AreEqual("ParaBank | Bill Pay", title);
        }

        [Then(@"I enter the Payee Information")]
        public void ThenIEnterThePayeeInformation()
        {
            Random random = new Random();
            int number = random.Next(200, 300);
            string userName1 = "TestUser1";
            string userName = userName1 + number;
            string randomText = "TestText";
            string phoneNumber = "1234567890";
            _driver.FindElement(By.CssSelector("input[ng-model='payee.name']")).SendKeys(userName);
            _driver.FindElement(By.CssSelector("input[ng-model='payee.address.street']")).SendKeys(randomText);
            _driver.FindElement(By.CssSelector("input[ng-model='payee.address.city']")).SendKeys(randomText);
            _driver.FindElement(By.CssSelector("input[ng-model='payee.address.state']")).SendKeys(randomText);
            _driver.FindElement(By.CssSelector("input[ng-model='payee.address.zipCode']")).SendKeys(number.ToString());
            _driver.FindElement(By.CssSelector("input[ng-model='payee.phoneNumber']")).SendKeys(phoneNumber);
            _driver.FindElement(By.CssSelector("input[ng-model='payee.accountNumber']")).SendKeys(number.ToString());
            _driver.FindElement(By.CssSelector("input[ng-model='verifyAccount']")).SendKeys(number.ToString());
            _driver.FindElement(By.CssSelector("input[ng-model='amount']")).SendKeys(number.ToString());

        }
        [Then(@"Submit the payee information")]
        public void ThenSubmitThePayeeInformation()
        {
            _driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div[1]/form/table/tbody/tr[14]/td[2]/input")).Click();
        }
        [Then(@"I should the bill pay service should be successful")]
        public void ThenIShouldTheBillPayServiceShouldBeSuccessful()
        {
            
            string _msgtext = _driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div[2]/h1")).Text;
            Assert.AreEqual("Bill Payment Complete", _msgtext);
        }





    }
}
