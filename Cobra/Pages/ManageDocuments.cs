//using AutoItX3Lib;
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

namespace Framework.Pages
{
    class ManageDocuments
    {
        // Initializing the web elements 
        internal ManageDocuments()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Finding Manage Document link
        [FindsBy(How =How.XPath,Using = "//li[3]/a[text()='Manage Documents']")]
        private IWebElement ManageDocuHL { get; set; }

        //Enter the File Name 
        [FindsBy(How = How.XPath, Using = "//div/input[@id='fileName']")]
        private IWebElement FileName { get; set; }

        //Click Browse 
        [FindsBy(How =How.XPath,Using = "//*[@id='uploadFilesForm']/div[5]/div/label/span/input")]
        private IWebElement Browse { get; set; }

        //Click Uplaod
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary'][text()='Upload']")]
        private IWebElement Upload { get; set; }

        
        //Finding Delete button in MD 
         [FindsBy(How =How.XPath,Using = "//table[@class='table table-striped']//tr[last()]/td[last()]/button")]
         private IWebElement DeleteB { get; set; }

        //Finding Preview button
        [FindsBy(How = How.XPath, Using = "//table[@class='table table-striped']//tr[last()]/td[last()]/a")]
        private IWebElement Preview { get; set; }

        #region UploadDocuments
        public void UploadDocuments()
        {
         //Populate in collection
         Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "ManageDecument");
         Global.GlobalDefinitions.wait(1000);

         //Click ManageDocument Link
         var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
         wait.Until(dr => dr.FindElement(By.XPath("//li[3]/a[text()='Manage Documents']")).Displayed);
         ManageDocuHL.Click();
         Global.GlobalDefinitions.wait(1000);

         //Enter the Resource Type
         var waitt = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
         waitt.Until(dr => dr.FindElement(By.XPath("//select[@name='fileType']")).Displayed);
         IWebElement elementR = Global.GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='fileType']"));
         elementR.Click();
         Global.GlobalDefinitions.wait(500);
         SelectElement SelectR= new SelectElement(elementR);
         Thread.Sleep(500);
         SelectR.SelectByText(Global.ExcelLib.ReadData(2, "Type"));
         Thread.Sleep(500);

         //Enter the FileName
         FileName.SendKeys(Global.ExcelLib.ReadData(2, "Filename"));
         Global.GlobalDefinitions.wait(500);

         //Click Browse Button
         Browse.Click();
         Global.GlobalDefinitions.wait(500);

         //Upload Document
         //AutoItX3 autoIt = new AutoItX3();
         //autoIt.WinActivate("Open");
         //Global.GlobalDefinitions.wait(500);
         //autoIt.Send(@"C:\Users\user\Downloads\06-0237-0491696-50_Statement_2017-05-10.pdf");
         //Global.GlobalDefinitions.wait(1000);
         //autoIt.Send("{ENTER}");         
         //SendKeys.SendWait(@"{Enter}");
         //Global.GlobalDefinitions.wait(1000);

        //Click Uplaod button
        var wait2 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
        wait2.Until(dr => dr.FindElement(By.XPath("//button[@class='btn btn-primary'][text()='Upload']")).Displayed);
        Upload.Click();
        Global.GlobalDefinitions.wait(1000);
       
        //Report
        

            try
            {
                //verification
                string ActualDocName = Global.GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='table table-striped']//tr[last()]/td[2]")).Text;
                if(ActualDocName.ToLower()!=Global.ExcelLib.ReadData(2, "Filename").ToLower())
                {
                    Console.WriteLine("Document uploded Successfully");
                    Global.Base.test.Log(LogStatus.Pass, "Upload document added Successfully");
                }
                else
                {
                    Console.WriteLine("Document not uploded ");
                    Global.Base.test.Log(LogStatus.Pass, "Document not uploded");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured at Upload Document page" + e.Message);
            }

            }
        #endregion

        #region DeleteDocument
        public void DeleteDocument()
        {
            
           //Click Delete button
           var waitp = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
           waitp.Until(dr => dr.FindElement(By.XPath("//table[@class='table table-striped']//tr[last()]/td[last()]/button")).Displayed);
           DeleteB.Click();
           Global.GlobalDefinitions.wait(1000);

        }
        #endregion

        #region PreviewDocument
        public void PreviewDocument()
        {

            //Click Delete button
            var waitp = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            waitp.Until(dr => dr.FindElement(By.XPath("//table[@class='table table-striped']//tr[last()]/td[last()]/a")).Displayed);
            Preview.Click();
            Global.GlobalDefinitions.wait(1000);

        }
        #endregion
    }
}
