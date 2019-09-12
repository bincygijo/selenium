using Framework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class Welcome
    {
        internal Welcome()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click welcome link
        [FindsBy(How = How.XPath, Using = "//div[@class='tabmenu-right ng-scope']/a[text()='Welcome']")]
        private IWebElement WelcomeLink { get; set; }

        //Click Calender icon
        [FindsBy(How =How.XPath,Using = "//button[@class='form-control btn btn-default btn-sm']/i")]
        private IWebElement Icon { get; set; }

        //Enter dob
        [FindsBy(How =How.XPath,Using = "//input[@name='dob']")]
        private IWebElement dob { get; set; }

        public void ValidateCalender()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Welcome");
            Global.GlobalDefinitions.wait(1000);


            WelcomeLink.Click();
            Global.GlobalDefinitions.wait(1000);

            //string dateofbirth = Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='dob']"));
            //string dateofbirth = Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='dob']")).Text;

           // Console.WriteLine("dob=="+ dateofbirth);
           // string[] data = dateofbirth.Split('/');
            //        string streetNo = Regex.Match(data[0], @"\d+").Value;
            //        string streetName = Regex.Match(data[0], @"\D+").Value;
            //       
           // Global.GlobalDefinitions.wait(1000);



             Icon.Click();
            Global.GlobalDefinitions.wait(1000);

            try
            {
                //click january 1998
                IWebElement ClickFirst = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-daypicker ng-scope']/table/thead/tr[1]/th[2]"));
                ClickFirst.Click();
                 SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "clicking the exact date ");

            }
            catch(Exception e)
            {
                Console.WriteLine("Exception occured when clicking January 1998 " + e.Message);
            }

            try
            {
                //clicking 1998

                IWebElement clickYear = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-monthpicker ng-scope']/table/thead/tr/th[2]"));
                clickYear.Click();
            }
            catch(Exception e)
            {
                Console.WriteLine("Year not found"+e.Message);
            }

            try
            {
                //clicking 1981-2000
                IWebElement clickyears = Global.GlobalDefinitions.driver.FindElement(By.XPath("uib-yearpicker ng-scope"));
                clickyears.Click();
            }
            catch(Exception e)
            {
                Console.WriteLine("Cannot find the exact date"+e.Message);

            }
            
            try
            {
                //clicking
                IWebElement clickback = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-yearpicker ng-scope']/table/thead/tr/th[1]"));
                clickback.Click();
            }
            catch(Exception e)
            {
                Console.WriteLine("Element not clickable"+e.Message);
            }

            try
            {
                //clicking 1970
                IWebElement clickY = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='uib-yearpicker ng-scope']/table/tbody/tr[2]/td[5]"));
                clickY.Click();
            }
            catch(Exception e)
            {
                Console.WriteLine("Element not clickable"+e.Message);

            }
        }
    }
}
