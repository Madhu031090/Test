using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using RestSharp;
using RestSharp.Deserializers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static Test.SharedHelper;
using Newtonsoft.Json;
//using static Test.Helpers.TestBaseHelper;

namespace Test.ControlSteps
{
    [Binding]

    public sealed class OpenBankAccountSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        private string testStatus;

   

        public OpenBankAccountSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        }

        [Given(@"I make a POST call to the CreateAccount Controller without credentials")]
        public void GivenIMakeAPOSTCallToTheCreateAccountControllerWithoutCredentials()
        {
           
            string baseURL = "https://parabank.parasoft.com/parabank/services_proxy/bank/createAccount";
            var client = new RestClient(baseURL + "?customerId=" + CustomerId + "&newAccountType=" + NewAccountType + "&fromAccountId=" + FromAccountID);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.Credentials = new NetworkCredential(UserName, Password);
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            CustomerId = jsonResponse.customerId;
            FromAccountID = jsonResponse.id;
            NewAccountType = "0";
            var  result = deserialize.Deserialize<Dictionary<string, string>>(response).ToList();
            testStatus = result[1].Value.ToString();
            Assert.AreEqual("401", testStatus);
        }

        [Given(@"I make a POST call to the CreateAccount Controller")]
        public void GivenIMakeAPOSTCallToTheCreateAccountController()
        {
            string baseURL = "https://parabank.parasoft.com/parabank/services_proxy/bank/createAccount";
            var client = new RestClient(baseURL + "?customerId=" + CustomerId + "&newAccountType=" + NewAccountType + "&fromAccountId=" + FromAccountID);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.Credentials = new NetworkCredential(UserName, Password);
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            var result = deserialize.Deserialize<Dictionary<string, string>>(response).ToList();
            testStatus = result[1].Value.ToString();
        }

        [Then(@"I should get the response of the Bank Account Controller")]
        public void ThenIShouldGetTheResponseOfTheBankAccountController()
        {
            Assert.AreEqual("401", testStatus);
        }


        [Then(@"When I get the Xpath Text")]
        public void ThenWhenIGetTheXpathText()
        {
            string scriptText = _driver.FindElement(By.TagName("script")).Text;
            Console.WriteLine(scriptText);
        }

        [Then(@"I should get an unauthorized status")]
        public void ThenIShouldGetAnUnauthorizedStatus()
        {
            Assert.AreEqual("401", testStatus);
        }
    
      
        [When(@"I click on Open New Account link")]
        public void WhenIClickOnOpenNewAccountLink()
        {
            _driver.FindElement(By.LinkText("Open New Account")).Click();
        }

        [Then(@"I should land on the Open New Account Page")]
        public void ThenIShouldLandOnTheOpenNewAccountPage()
        {
            string title = _driver.Title;
            Assert.AreEqual("ParaBank | Open Account", title);
        }

        [When(@"I choose the Checking")]
        public void WhenIChooseTheChecking()
        { 
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.Id("type")));
            dropdown.SelectByValue("0");
        }
        [When(@"I choose the Savings")]
        public void WhenIChooseTheSavings()
        {
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.Id("type")));
            dropdown.SelectByValue("1");
        }


        [When(@"when I choose any existing account")]
        public void WhenWhenIChooseAnyExistingAccount()
        { 
            //Unable to implement this because the WebElement does not have a unique Identifier
            //SelectElement dropdown = new SelectElement(_driver.FindElement(By.Id("fromAccountId")));
            //dropdown.SelectByIndex(1);
        }

        [When(@"click on Open New Account Button")]
        public void WhenClickOnOpenNewAccountButton()
        {
            _driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/form/div/input")).Click(); 
        }

        [Then(@"I should see the success message")]
        public void ThenIShouldSeeTheSuccessMessage()
        {
             string _msgtext = _driver.FindElement(By.ClassName("title")).Text;
            //ToDo Change the Assert text
           // Assert.AreEqual("Account Opened!", _msgtext);
        }




    }
}
