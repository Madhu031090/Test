using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Test
{
   
   public class SharedHelper
    {
        public static IWebDriver _driver { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string CustomerId { get; set; }
        public static string FromAccountID { get; set;}
        public static string NewAccountType { get; set; }
        public static string ToAccountID { get; set; }

       
    }
}
