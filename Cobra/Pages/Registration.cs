using Framework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static NUnit.Core.NUnitFramework;

namespace Framework.Pages
{
    class Registration
    {
        internal Registration()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //*---------- Created By Bincy Gijo on 15/10/2017................*

        //Finding Create Account
        [FindsBy(How =How.XPath,Using = "//div[@class='creat-an-account']/a")]
        private IWebElement ClickCreateAccount { get; set; }

        //Enter Email address
        [FindsBy(How =How.XPath,Using = "//input[@name='emailAddress']")]
        private IWebElement Email { get; set; }

        //Enter Password
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement Password { get; set; }

        //Enter Re typepassword
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        private IWebElement RePassword { get; set; }

        //checkbox checking
        [FindsBy(How =How.XPath,Using = "//input[@type='checkbox']")]
        private IWebElement Checkbox { get; set; }

        //Clicking RegisterNow
        [FindsBy(How =How.XPath,Using = "//input[@type='button']")]
        private IWebElement Register { get; set; }

        #region EmailValidation
        public void ValidateEmailAlreadyExixts()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Registration");
            Global.GlobalDefinitions.wait(1000);

            //Navigate to test env
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.ExcelLib.ReadData(2, "Url"));
            Global.GlobalDefinitions.wait(500);

            //Clicking CreateAccount
            ClickCreateAccount.Click();
            Global.GlobalDefinitions.wait(1000);

            //Enter Email
            Email.SendKeys(Global.ExcelLib.ReadData(2, "Email"));
            Global.GlobalDefinitions.wait(1000);

            //Enter Password
            Password.SendKeys(Global.ExcelLib.ReadData(2, "Password"));
            Global.GlobalDefinitions.wait(1000);

            //Enter Confirm pass
            RePassword.SendKeys(Global.ExcelLib.ReadData(2, "ReTypePass"));
            Global.GlobalDefinitions.wait(1000);

            //Clicking agree/disagree
            Checkbox.Click();
            Global.GlobalDefinitions.wait(1000);

            //Click RegisterNow
            Register.Click();
            Global.GlobalDefinitions.wait(1000);

            string ActualErrormessage = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='alert alert-warning col-md-12 field']/ul/li")).Text;
            string ExpectedErrormsg = "Email 'bincy.gijok@gmail.com' is already taken.";
           
            if(ActualErrormessage.ToLower()== ExpectedErrormsg.ToLower())
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Error message found  with duplicate email Id");
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Found Added Address");
                //Adding screenshot in extendReport
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EmailValidation");
                string screenShotPath = Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Validating Error message");
                Base.test.Log(LogStatus.Fail, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));
                GlobalDefinitions.driver.Close();
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Error message not found");
            }
            
        }
        #endregion
    }
}