using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static Test.SharedHelper;
using static Test.Helpers.TestBaseHelper;


namespace Test.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        

        [BeforeFeature()]
       
        public static void BeforeFeature()
        {

            TestBase();
            
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            _driver.Quit();
        }
    }
}
