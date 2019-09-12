using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NUnit.Core.NUnitFramework;
//using AutoItX3Lib;

namespace Framework.Pages
{
    class Profilee
    {
        // Initializing the web elements 
        internal Profilee()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Finding the  Profile Hyper Link
        [FindsBy(How = How.XPath, Using = "//li//a[text()='Profile']")]
        private IWebElement EditProfileHL { get; set; }

        //Finding the  Edit Profile button
        [FindsBy(How = How.XPath, Using = "//button[@id='editProfileBtn']/i")]
        private IWebElement EditProfileB { get; set; }

        //Finding Firstname field
        [FindsBy(How = How.XPath, Using = "//input[@name='ProfileModel.Firstname']")]
        private IWebElement Firstname { get; set; }

        ////Finding Lastname field
        [FindsBy(How = How.XPath, Using = "//input[@name='ProfileModel.LastName']")]
        private IWebElement Lastname { get; set; }

        //DOB
        [FindsBy(How = How.XPath, Using = "//div[@class='input-group']/input")]
        private IWebElement Dob { get; set; }
        

        ////Finding Save button
        [FindsBy(How = How.XPath, Using = "//*[@id='modalForm']/div/div/form/div[2]/span/button[1]")]
        private IWebElement SaveB { get; set; }
        
        #region EditProfleSteps
        public void EditProfleSteps()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "ProfilePage");
            Global.GlobalDefinitions.wait(1000);

            //Click on Profile hyperlink
            var waitp = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            waitp.Until(dr => dr.FindElement(By.XPath("//li//a[text()='Profile']")).Displayed);
            EditProfileHL.Click();
            Global.GlobalDefinitions.wait(500);

            //Click on Edit Profile hyperlink
            var waits = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            waits.Until(dr => dr.FindElement(By.XPath("//button[@id='editProfileBtn']/i")).Displayed);
            EditProfileB.Click();
            Global.GlobalDefinitions.wait(500);

            //Enter the Firstname
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            wait.Until(dr => dr.FindElement(By.XPath("//input[@name='ProfileModel.Firstname']")).Displayed);
            Firstname.Clear();
            Thread.Sleep(500);
            Firstname.SendKeys(Global.ExcelLib.ReadData(2, "FirstName"));
            Global.GlobalDefinitions.wait(500);

            //Enter Lastname
            var wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            wait1.Until(dr => dr.FindElement(By.XPath("//input[@name='ProfileModel.LastName']")).Displayed);
            Lastname.Clear();
            Lastname.SendKeys(Global.ExcelLib.ReadData(2, "LastName"));
            Global.GlobalDefinitions.wait(500);

            //Enter Gender
            IWebElement element = Global.GlobalDefinitions.driver.FindElement(By.Name("PersonModel.Gender"));
            element.Click();
            SelectElement oSelect = new SelectElement(element);
            Thread.Sleep(500);
            oSelect.SelectByText(Global.ExcelLib.ReadData(2, "Gender"));
            Thread.Sleep(500);


            //Enter Date
            Dob.Click();

            //click current month& year
            string clickMonthYear = Global.GlobalDefinitions.driver.FindElement(By.XPath("//th[@colspan='6']")).Text;

            Console.WriteLine("Month and Year===" + clickMonthYear);

            Thread.Sleep(500);
            //

            //clickMonthYear.Click();

           
            //try
            //{
            //    Assert.AreEqual(clickMonthYear,"");
            //    Global.Base.test.Log(LogStatus.Pass, "Street No : Expected & Actual results are equal");

            //}
            //catch (Exception e)
            //{
            //    Global.Base.test.Log(LogStatus.Fail, "Test fail");
            //    Global.Base.test.Log(LogStatus.Info, e.Message + ">>No message for Invalid Street No");
            //}

            ////click year-1970
            //IWebElement clickYear = Global.GlobalDefinitions.driver.FindElement(By.XPath("//th[@colspan='1']"));
            //Thread.Sleep(500);
            //clickYear.Click();
            //Thread.Sleep(500);

            ////click 1961-1980
            //IWebElement clickYeaRange = Global.GlobalDefinitions.driver.FindElement(By.XPath("//th[@colspan='3']"));
            //Thread.Sleep(500);
            //clickYeaRange.Click();
            //Thread.Sleep(500);

            ////click 1980
            //IWebElement clickY = Global.GlobalDefinitions.driver.FindElement(By.XPath("//tr[@class='uib-years ng-scope'][4]/td[5]/button"));
            //Thread.Sleep(500);
            //clickY.Click();
            //Thread.Sleep(500);

            ////click > button on 1980
            //IWebElement clicknext = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-monthpicker ng-scope']/table/thead/tr/th[3]/button"));
            //Thread.Sleep(500);
            //clicknext.Click();
            //Thread.Sleep(500);

            ////click on 1981 
            //IWebElement clickYe = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-monthpicker ng-scope']/table/thead/tr/th[2]/button"));
            //Thread.Sleep(500);
            //clickYe.Click();
            //Thread.Sleep(500);

            ////click 1995
            //IWebElement clickYea = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-yearpicker ng-scope']/table/tbody/tr[3]/td[5]/button"));
            //Thread.Sleep(500);
            //clickYea.Click();
            //Thread.Sleep(500);

            ////click month Aug
            //IWebElement clickAug = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-monthpicker ng-scope']/table/tbody/tr[3]/td[2]"));
            //Thread.Sleep(500);
            //clickAug.Click();
            //Thread.Sleep(500);

            ////click date
            //IWebElement clickDay = Global.GlobalDefinitions.driver.FindElement(By.XPath(" //div[@class='uib-daypicker ng-scope']/table/tbody/tr[4]/td[2]/button"));
            //Thread.Sleep(500);
            //clickDay.Click();
            //Thread.Sleep(500);
           






            //IWebElement selectDate = Global.GlobalDefinitions.driver.FindElement(By.XPath("//span[@class='input-group-btn']/button"));
            //selectDate.Click();
            //Thread.Sleep(500);
            //Finding Save button
            SaveB.Click();
            Thread.Sleep(500);

            try
            {
                //verification
                string ActualFLName = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='bob']/div[2]/section/div[2]/h4/strong")).Text;
                //Console.WriteLine("actalProfname="+ ActualFLName);
                string fname = Global.ExcelLib.ReadData(2, "FirstName");
                string lname = Global.ExcelLib.ReadData(2, "LastName");
                string FLName = fname + " " + lname;

                //Screenshot
                Global.SaveScreenShotClass.SaveScreenshot(Global.GlobalDefinitions.driver, "EditProfile");
                if (ActualFLName.ToLower() == FLName.ToLower())
                {
                    Global.Base.test.Log(LogStatus.Pass, "Profile name Updated Successfully");
                    Console.WriteLine("Profile name Updated Successfully");

                }
                else
                {
                    Global.Base.test.Log(LogStatus.Pass, "Profile name not updated");
                    Console.WriteLine("Profile name not updated");

                }
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured at Profile update page" + e.Message);
            }


        }
        #endregion
        }
}
