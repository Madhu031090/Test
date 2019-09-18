using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static Test.Helpers.TestBaseHelper;
using static Test.SharedHelper;

namespace Test.ControlSteps
{
    [Binding]
    public sealed class TransferFundsSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;


        public TransferFundsSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        //[Given(@"I am on the transfer funds page")]
        //public void GivenIAmOnTheTransferFundsPage()
        //{

        //}
        [Given(@"I am on the transfer funds page")]
        public void GivenIAmOnTheTransferFundsPage()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I click on transfer funds link")]
        public void WhenIClickOnTransferFundsLink()
        {
            _driver.FindElement(By.LinkText("Transfer Funds")).Click();
        }

        [Then(@"I should land on the transfer funds page")]
        public void ThenIShouldLandOnTheTransferFundsPage()
        {
            string title = _driver.Title;
            Assert.AreEqual("ParaBank | Transfer Funds", title);

        }
        [When(@"I enter an amount in the amount Field")]
        public void WhenIEnterAnAmountInTheAmountField()
        {
            _driver.FindElement(By.Id("amount")).SendKeys("500");
        }
        [When(@"then I select a From Account and a To Account")]
        public void WhenThenISelectAFromAccountAndAToAccount()
        {

            //SelectElement _fromAccountDropDown = new SelectElement(_driver.FindElement(By.Id("type")));
            //_fromAccountDropDown.SelectByValue(FromAccountID);
            //SelectElement _toAccountDropDown = new SelectElement(_driver.FindElement(By.Id("type")));
            //_toAccountDropDown.SelectByValue(ToAccountID);
        }
        [When(@"I click transfer to transfer the funds")]
        public void WhenIClickTransferToTransferTheFunds()
        {
            _driver.FindElement(By.ClassName("button")).Click();

        }

        [Then(@"the transfer happens successfully")]
        public void ThenTheTransferHappensSuccessfully()
        {
            //string _msgtext = _driver.FindElement(By.ClassName("title")).Text;
           // string _msgtext =_driver.FindElement(By.ClassName("ng-binding")).Text;
            //ToDo CheckAlertMessage
          //  Assert.AreEqual("Transfer Complete!", _msgtext);

        }

    }
}
