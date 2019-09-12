using Framework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections;

namespace Framework.Pages
{
    class WelcomeInfo
    {
        internal WelcomeInfo()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //*---------- Created By Bincy Gijo on 25/10/2017................*

        //Clicking Welcome Link
        [FindsBy(How = How.XPath, Using = "//div[@class='tabmenu-right ng-scope'][5]/a")]
        private IWebElement WelcomeLink { get; set; }

         //Finding First Name
         [FindsBy(How =How.XPath,Using = "//input[@name='fName']")]
         private IWebElement FirstName { get; set; }

        //Finding Last Name
        [FindsBy(How = How.XPath, Using = "//input[@name='lName']")]
        private IWebElement LastName { get; set; }

        //Finding Calender button
        [FindsBy(How = How.XPath, Using = "//button[@class='form-control btn btn-default btn-sm']/i")]
        private IWebElement Calender { get; set; }

        //Enter phoneNumber
        [FindsBy(How = How.XPath, Using = " //input[@name='phoneNumber']")]
        private IWebElement PhoneNu { get; set; }
        

        //Finding Next button
        [FindsBy(How = How.XPath, Using = " //button[text()='Next']")]
        private IWebElement NextBu { get; set; }

        //Finding Emergencycontact link
        [FindsBy(How = How.XPath, Using = "//button[@data-target='#addEmergencyContactModal']")]
        private IWebElement EmerLink { get; set; }

        //Enter First Name
        [FindsBy(How = How.XPath, Using = "//input[@ng-model='newContact.Firstname']")]
        private IWebElement Fname { get; set; }

        //Enter Last Name
        [FindsBy(How = How.XPath, Using = "//input[@ng-model='newContact.Lastname']")]
        private IWebElement Lname { get; set; }

       

        #region Personal Info
        public void ValidatePersonalInfo()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "PersonalInfo");
            Global.GlobalDefinitions.wait(1000);

            //Click Welcome
            WelcomeLink.Click();
            Global.GlobalDefinitions.wait(500);
           
            //Enter First Name
            FirstName.SendKeys(Global.ExcelLib.ReadData(2,"FirstName"));
            Global.GlobalDefinitions.wait(1000);

            //Enter Last Name
            LastName.SendKeys(Global.ExcelLib.ReadData(2, "LastName"));
            Global.GlobalDefinitions.wait(1000);

            //Select Gender
            IWebElement Gender = Global.GlobalDefinitions.driver.FindElement(By.Name("gender"));
            Gender.Click();
            Global.GlobalDefinitions.wait(500);
            SelectElement GenderList = new SelectElement(Gender);
            GenderList.SelectByText(Global.ExcelLib.ReadData(2, "Gender"));
            Global.GlobalDefinitions.wait(500);

            //Select DateOfBirth
            Calender.Click();
            Global.GlobalDefinitions.wait(500);
           
            //Click backword
           IWebElement ClickFirst = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-daypicker ng-scope']/table/thead/tr/th/button/i"));
           ClickFirst.Click();
           Global.GlobalDefinitions.wait(500);

            //Click September 1999
            IWebElement ClickSep = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-daypicker ng-scope']/table/thead/tr/th[2]/button"));
            ClickSep.Click();
            Global.GlobalDefinitions.wait(500);

            //Click  1999
            IWebElement ClickYear = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-monthpicker ng-scope']/table/thead/tr/th[2]/button"));
            ClickYear.Click();
            Global.GlobalDefinitions.wait(500);

            //Click  1981-2000
            IWebElement ClickYearRange = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-yearpicker ng-scope']/table/tbody/tr[1]/td[5]"));
            ClickYearRange.Click();
            Global.GlobalDefinitions.wait(500);

            //click month August
            IWebElement ClickMonth = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-monthpicker ng-scope']/table/tbody/tr[3]/td[2]"));
            ClickMonth.Click();
            Global.GlobalDefinitions.wait(500);

            //click Day 20
            IWebElement ClickDay = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-daypicker ng-scope']/table/tbody/tr[4]/td[3]"));
            ClickDay.Click();
            Global.GlobalDefinitions.wait(2000);

            //screenshot for clicking calender and add extend report
            string screenShotPath = Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Calender");
            Base.test.Log(LogStatus.Fail, "Calender Pop Up: " + Base.test.AddScreenCapture(screenShotPath));
            Global.GlobalDefinitions.wait(1000);

            //Dateof birth
            string Dateof = (Global.ExcelLib.ReadData(2, "DateOfBirth"));
            string[] data = Dateof.Split('-');

            try
            {
                string ActualMsg = "Welcome to Alex Swift Emergency Contact";
                string ExpMsg = Global.GlobalDefinitions.driver.FindElement(By.XPath("//h4[text()='Welcome to Alex Swift Emergency Contact']")).Text;
               
                Assert.AreEqual(ActualMsg, ExpMsg);
                Base.test.Log(LogStatus.Pass, "Welcome Page : Expected & Actual results are equal");
            }
            catch (Exception e)
            {
                Global.Base.test.Log(LogStatus.Fail, "Test fail");
                Global.Base.test.Log(LogStatus.Info, e.Message + ">>No message captured in welcome page");
            }
            Global.GlobalDefinitions.wait(2000);
            try
            {
                string ErrmsgFname = "Only Alphabet Accepted";
                string ExpFname = Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='fName']//following::span[text()='Only Alphabet Accepted'][1]")).Text;

                Assert.AreEqual(ErrmsgFname, ExpFname);
                Base.test.Log(LogStatus.Pass, "First Name : Expected & Actual results are equal");
            }
            catch (Exception e)
            {
                Global.Base.test.Log(LogStatus.Fail, "Test fail");
                Global.Base.test.Log(LogStatus.Info, e.Message + ">>No message captured for Invalid First name");
            }
            Global.GlobalDefinitions.wait(2000);
            //scroll a page
            IJavaScriptExecutor js = Global.GlobalDefinitions.driver as IJavaScriptExecutor;
            Global.GlobalDefinitions.wait(5000);
            js.ExecuteScript("window.scrollBy(0,500);");
            IWebElement NextButton = Global.GlobalDefinitions.driver.FindElement(By.XPath("//button[text()='Next']"));
           
            NextButton.Click();

           
            try
            {
                string Amesg = Global.GlobalDefinitions.driver.FindElement(By.XPath("//h4[text()='Please add your personal contact details here']")).Text;
                string Expmeg = "Please add your personal contact details here";
                Assert.AreEqual(Expmeg, Amesg);
                Base.test.Log(LogStatus.Pass, "Contact details page validation, Pass");
                Base.test.Log(LogStatus.Info, "Expected err: '" + Expmeg + " ' is displayed");
                string screenShotPath1 = Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "contactdetail");
                Base.test.Log(LogStatus.Fail, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath1));
                //GlobalDefinitions.driver.Close();

            }
            catch (Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Fail");
                Base.test.Log(LogStatus.Info, e.Message + ">> No error captured for contact details page");
            }
            Thread.Sleep(1000);

            //Call Contact details method
            ValidateContactDetails();

            //call emergency contact
            AddEmergencyContact();

        }
        #endregion

        #region contactdetails
        public void ValidateContactDetails()
        {
            //Click AddressType
            IWebElement AddType = Global.GlobalDefinitions.driver.FindElement(By.Name("addressType"));
            AddType.Click();
            Global.GlobalDefinitions.wait(500);
            SelectElement GenderList = new SelectElement(AddType);
            GenderList.SelectByText(Global.ExcelLib.ReadData(2, "AddType"));
            Global.GlobalDefinitions.wait(1000);

            //Google Autofilling Address
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@id='address']")).SendKeys("75 Melrose Rd, Mount Roskill, Auckland 1041, New Zealand");
            Global.GlobalDefinitions.wait(5000);
            new Actions(Global.GlobalDefinitions.driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
            Thread.Sleep(5000);
            new Actions(Global.GlobalDefinitions.driver).SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
            Thread.Sleep(5000);
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            wait.Until(dr => dr.FindElement(By.XPath("//input[@id='address']")).Displayed);
            new Actions(Global.GlobalDefinitions.driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
            Thread.Sleep(5000);
            new Actions(Global.GlobalDefinitions.driver).SendKeys(OpenQA.Selenium.Keys.Return).Perform();
            Thread.Sleep(5000);

            //Enter PhoneNumber
            PhoneNu.SendKeys(Global.ExcelLib.ReadData(2, "PhoneNu"));
            Global.GlobalDefinitions.wait(2000);

            //Clicking Next button
            NextBu.Click();
            Thread.Sleep(1000);

            //Validate Emergency contact page or not
            try
            {
                string ErrmsgEmergency = "Please fill in your emergency contacts below";
                string MesgEmer = Global.GlobalDefinitions.driver.FindElement(By.XPath("//h4[text()='Please fill in your emergency contacts below']")).Text;
                Assert.AreEqual(ErrmsgEmergency, MesgEmer);
                Base.test.Log(LogStatus.Pass, "Emergency contacts validation, Pass");
                Base.test.Log(LogStatus.Info, "Expected err: '" + ErrmsgEmergency + " ' is displayed");
                string screenShotPath2 = Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EmergencyDetails");
                Base.test.Log(LogStatus.Fail, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath2));

            }
            catch(Exception e)
            {
                Base.test.Log(LogStatus.Fail, "Fail");
                Base.test.Log(LogStatus.Info, e.Message + ">> No error captured for emergency contact details page");
            }

            
        }
        #endregion

        #region Emergency Contact
        public void  AddEmergencyContact()
        {
            //Clicking EmergencyContact Link
            EmerLink.Click();
            Global.GlobalDefinitions.wait(1000);

            //Enter First name
            Fname.SendKeys(Global.ExcelLib.ReadData(2,"Fname"));
            Global.GlobalDefinitions.wait(1000);

            //Enter Last name
            Lname.Clear();
            Lname.SendKeys(Global.ExcelLib.ReadData(2,"Lname"));
            Global.GlobalDefinitions.wait(1000);

            //select relationship
            IWebElement Relation = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='col-md-9 col-sm-9']/select[@ng-model='newContact.RelationshipID']"));
            Relation.Click();
            Global.GlobalDefinitions.wait(1000);
            SelectElement RelationList = new SelectElement(Relation);
            RelationList.SelectByText(Global.ExcelLib.ReadData(2, "Relationship"));
            Global.GlobalDefinitions.wait(1000);


            // select Priority
            IWebElement Priority = Global.GlobalDefinitions.driver.FindElement(By.XPath("//select[@ng-model='newContact.Priority']"));
            var wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            wait1.Until(dr => dr.FindElement(By.XPath("//select[@ng-model='newContact.Priority']")).Displayed);
            Priority.Click();
            Global.GlobalDefinitions.wait(500);
            SelectElement PriorityList = new SelectElement(Priority);
            PriorityList.SelectByText(Global.ExcelLib.ReadData(2, "Priority"));
            Global.GlobalDefinitions.wait(1000);

            //screenshot
            Base.test.Log(LogStatus.Pass, "AddContactDetails, Pass");
            string screenShotPath3 = Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "AddContactDetails");
            Base.test.Log(LogStatus.Fail, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath3));

            //Click Next button
            IWebElement NextEmergency = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='modal-footer ng-scope']/a[@class='btn btn-info']"));
            NextEmergency.Click();
            Global.GlobalDefinitions.wait(2000);

            //Add Contact Type
            IList address = GlobalDefinitions.driver.FindElements(By.XPath("//div[@class='ng-pristine ng-untouched ng-valid ng-empty']//following::select"));
            int countadd = address.Count;

            Console.WriteLine("count==="+ countadd);

            IWebElement ConType1 = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ng-pristine ng-untouched ng-valid ng-empty']//following::select"));
            
            var wait5 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(60));
            wait5.Until(dr => dr.FindElement(By.XPath("//div[@class='ng-pristine ng-untouched ng-valid ng-empty']//following::select/option[2]")).Displayed);
            ConType1.Click();
            Global.GlobalDefinitions.wait(1000);
            SelectElement ConList = new SelectElement(ConType1);
            Console.WriteLine("val="+ ConList);
            ConList.SelectByValue("Email");
            Global.GlobalDefinitions.wait(2000);
            //SelectElement ss = new SelectElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ng-pristine ng-untouched ng-valid ng-empty']//following::select")));

            //Console.WriteLine(ss.Options);

            //foreach (IWebElement element in ss.Options)
            //{

            //    Thread.Sleep(1000);
            //    if (element.Text == "Email                         ")
            //    {
            //        Thread.Sleep(1000);
            //        element.Click();
            //        break;
            //    }

            //    else
            //    {
            //        Console.WriteLine("manga");
            //    }
                
            //}

            //string ContactType = Global.ExcelLib.ReadData(2,"ConType");
            //Console.WriteLine("contact"+ ContactType);
            //if(ContactType=="Email")
            //{
            IWebElement EmailC = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='addNewForm']/div/div/div[2]/div/div/select"));
            EmailC.SendKeys("test@test.com");
            Base.test.Log(LogStatus.Pass, "Successfully find email, Pass");
            //}
            //else
            //{
            //    Console.WriteLine("Cannot able to find email text box");
               
            //}


        }
        #endregion

    }
}
