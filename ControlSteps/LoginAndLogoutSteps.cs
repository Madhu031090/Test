using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using static Test.SharedHelper;


namespace Test.ControlSteps
{
    [Binding]
    public sealed class LoginAndLogoutSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        IWebDriver _driver = new ChromeDriver();

        string userName1 = "UserForTest";
        string lastName1 = "LastNameUser";
        string randomText = "TestText";
        string phoneNumber = "1234567890";

        public LoginAndLogoutSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            _driver.Manage().Window.Maximize();
        }

        [When(@"I click on Register for the user to login")]
        public void WhenIClickOnRegisterForTheUserToLogin()
        {
            _driver.FindElement(By.LinkText("Register")).Click();
        }

        [Then(@"I can successfully register and login to the application")]
        public void ThenICanSuccessfullyRegisterAndLoginToTheApplication()
        {

            _driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            _driver.FindElement(By.LinkText("Register")).Click();
            Random random = new Random();
            int number = random.Next(200, 300);
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
            _driver.FindElement(By.XPath("//*[@id='customerForm']/table/tbody/tr[13]/td[2]/input")).Click();
            Thread.Sleep(1000);
            string _welcomeMessage = _driver.FindElement(By.ClassName("smallText")).Text;
            Assert.IsNotEmpty(_welcomeMessage);
            
        }

        [When(@"When I click on Logout")]
        public void WhenWhenIClickOnLogout()
        {
            _driver.FindElement(By.LinkText("Log Out")).Click();
        }

        [Then(@"I should be logged out of the application")]
        public void ThenIShouldBeLoggedOutOfTheApplication()
        {
            //Return to the Login page
           string pageTitleText = _driver.FindElement(By.Id("leftPanel")).Text;
           Assert.IsTrue(pageTitleText.Contains("Customer Login"));
            _driver.Close();

        }


    }
}
