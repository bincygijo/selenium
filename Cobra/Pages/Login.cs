using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class Login
    {
        // Initializing the web elements 
        internal Login()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
                
         // Finding the Login hyperlink
         [FindsBy(How = How.XPath, Using = "//a[@href='/Account/Login']")]
        private IWebElement LoginHL { get; set; }


        // Finding the Username Field   //html/body/div/div[2]/div/div/div/div/div/div/div[1]/div[2]/form/div/div[1]/input
        [FindsBy(How = How.XPath, Using = "//input[@name='emailAddress']")]
        private IWebElement Username { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement Password { get; set; }


        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Login Now']")]
        private IWebElement loginButton { get; set; }

        public void LoginStep()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "LoginPage");

            //Navigate to test env
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "url"));
            Global.GlobalDefinitions.wait(500);

            //Click on Login hyperlink
           // LoginHL.Click();
            Global.GlobalDefinitions.wait(500);

            //Enter the username
            Username.SendKeys(Global.ExcelLib.ReadData(2, "username"));
            Global.GlobalDefinitions.wait(500);
            //Enter the username
            Password.SendKeys(Global.ExcelLib.ReadData(2, "password"));
            Global.GlobalDefinitions.wait(500);

            Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinitions.driver, "Login Page");
            //Click on Login button
            loginButton.Click();
            Global.GlobalDefinitions.wait(500);

            
            
        }

    }
}
