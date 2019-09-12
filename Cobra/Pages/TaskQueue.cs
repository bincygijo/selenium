using Framework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class TaskQueue
    {
        // Initializing the web elements 
        internal TaskQueue()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Finding Call center link
        [FindsBy(How =How.XPath,Using = "//div[@class='tabmenu-right ng-scope']/a[text()='Call Center']")]
        private IWebElement CallCenterLink { get; set; }

        //Finding Task Queue
        [FindsBy(How =How.XPath,Using = "//li/a[text()='Task Queue']")]
        private IWebElement TaskQueueLink { get; set; }

        #region TaskQueue
        public void AssignTask()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "TaskQueue");
            Global.GlobalDefinitions.wait(1000);

            //Clicking Callcenter link
            CallCenterLink.Click();
            Global.GlobalDefinitions.wait(1000);

            //Clicking TaskQueue link
            TaskQueueLink.Click();
            Global.GlobalDefinitions.wait(6000);

            //Clicking Assigned to dropdown box
            IWebElement AssignTo = Global.GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='table table-hover table-responsive table-bordered table-white']/tbody/tr[1]/td[8]/form/div/select"));
            AssignTo.Click();
            Global.GlobalDefinitions.wait(500);
            SelectElement SelectR = new SelectElement(AssignTo);
            Thread.Sleep(500);
            SelectR.SelectByText(Global.ExcelLib.ReadData(2, "Assign"));
           
            Thread.Sleep(500);

            //Scroll window to the Add button first
            Global.GlobalDefinitions.wait(50000);
           var elem = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='bob']/div[2]/section/div/ng-include/div/div/div/div[2]/table/tbody/tr[10]/td[6]"));
           ((IJavaScriptExecutor)Global.GlobalDefinitions.driver).ExecuteScript("arguments[0].scrollIntoView(true);", elem);
            Global.GlobalDefinitions.wait(10000);


           // Scroll to Page navigation
           ((IJavaScriptExecutor)Global.GlobalDefinitions.driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
           Global.GlobalDefinitions.wait(5000);
           
           
            // go through all pages to find the particular element
            var i = 2;
            while (true)
            {
               for (int j = 1; j < 10; j++)
                {
                   var name = GlobalDefinitions.driver.FindElement(By.XPath(".//div[@class='content row']//table[@ng-show='userCount > 0']//tbody[" + j + "]/tr/td[2]")).Text;

                    var email = GlobalDefinitions.driver.FindElement(By.XPath(".//div[@class='content row']//table[@ng-show='userCount > 0']//tbody[" + j + "]/tr/td[3]")).Text;

                   if (name == "Bincy Gijo" && email == "bincy77@gmail.com")
                   {
                        var action = GlobalDefinitions.driver.FindElement(By.XPath(".//div[@class='content row']//table[@ng-show='userCount > 0']//tbody[" + j + "]/tr/td[4]"));
                        action.Click();
                       return;
                   }

              }
                GlobalDefinitions.driver.FindElement(By.XPath(".//div[@class='content row']//table[2]//tr//td//ul//li[" + i + "]/a ")).Click();
                i++;
            }

           

        }
        #endregion
    }
}
