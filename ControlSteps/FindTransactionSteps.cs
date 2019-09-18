using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static Test.SharedHelper;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Test.ControlSteps
{
    [Binding]
    public sealed class FindTransactionSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
       
        public FindTransactionSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [When(@"I click on Find transactions link")]
        public void WhenIClickOnFindTransactionsLink()
        {
            _driver.FindElement(By.LinkText("Find Transactions")).Click();
        }
        [Then(@"I should land on the Find transactions Page")]
        public void ThenIShouldLandOnTheFindTransactionsPage()
        {
            string title = _driver.Title;
            Assert.AreEqual("ParaBank | Find Transactions", title);
        }

        [When(@"I click on Find Transactions by Amount")]
        public void WhenIClickOnFindTransactionsByAmount()
        {
          
            IWebElement element = _driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/form/div[9]/button"));
            Actions action = new Actions(_driver);
            Action moveToElement = action.MoveToElement(element).Perform;
            action.MoveToElement(element).Click().Perform();

        }
        [When(@"I enter an amount in the Find Transaction's amount Field")]
        public void WhenIEnterAnAmountInTheFindTransactionSAmountField()
        {
            _driver.FindElement(By.Id("criteria.amount")).SendKeys("100");
        }

        [Then(@"I should see the Transaction Results")]
        public void ThenIShouldSeeTheTransactionResults()
        {
            Thread.Sleep(1000);
            var message =_driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/h1")).Text;
            Assert.IsTrue(message.Contains("Transaction Results"));
        }


    }
}
