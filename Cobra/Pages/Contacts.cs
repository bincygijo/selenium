using Framework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Threading;
using System.Collections.ObjectModel;
using System.Text;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace Framework.Pages
{
    class Contacts
    {
        // Initializing the web elements 
        internal Contacts()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Finding Contact link
        [FindsBy(How = How.XPath, Using = "//li/a[text()='Contacts']")]
        private IWebElement ContactLink { get; set; }

        //Finding (+) link
        [FindsBy(How = How.XPath, Using = "//div[@id='tab-5']//div[@class='col-md-12 ng-scope']//following::button[@class='custom-btn'][1]")]
        private IWebElement AddLink { get; set; }

        //Finding Address
        [FindsBy(How =How.XPath,Using = "//input[@id='address']")]
        private IWebElement Address { get; set; }

        //Finding Street No
        [FindsBy(How = How.XPath, Using = "//input[@name='nameStreetNo']")]
        private IWebElement StreetNo { get; set; }

        //Finding Street Name
        [FindsBy(How = How.XPath, Using = "//input[@name='nameStreetName']")]
        private IWebElement StreetName { get; set; }

        //Finding Suburb
        [FindsBy(How = How.XPath, Using = "//input[@name='nameSuburb']")]
        private IWebElement Suburb { get; set; }

        //Finding City
        [FindsBy(How = How.XPath, Using = "//input[@name='nameCity']")]
        private IWebElement City { get; set; }

        //Finding State
        [FindsBy(How = How.XPath, Using = "//input[@name='nameState']")]
        private IWebElement State { get; set; }

        //Finding Country
        [FindsBy(How = How.XPath, Using = "//input[@name='nameCountry']")]
        private IWebElement Country { get; set; }

        //Finding Zipcode
        [FindsBy(How = How.XPath, Using = "//input[@name='nameZipCode']")]
        private IWebElement Zipcode { get; set; }

        //Finding Save Button
        [FindsBy(How = How.XPath, Using = "//button[@ng-click='postNewAddress()']")]
        private IWebElement Save { get; set; }

        //Finding Edit button
        [FindsBy(How = How.XPath, Using = "//div[@id='tab-5']//div[@class='col-md-4 ng-scope'][1]//a[@class='btn btn-warning btn-xs']")]
        private IWebElement EditContact { get; set; }
        public object TimeUnit { get; private set; }

        //click primary //div[@id='tab-5']//div[@class='col-md-4 ng-scope'][1]//div/strong[text()='Primary']

        #region Addaddress
        public void Addaddress()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Contacts");
            Global.GlobalDefinitions.wait(1000);

            //Click Contact Link
            ContactLink.Click();
            Global.GlobalDefinitions.wait(1000);

            //Screenshot
            Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Click Contact Link");

            //click Add address(+) 
            AddLink.Click();
            Global.GlobalDefinitions.wait(1000);

            //Enter the Address Type
            var waitt = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            waitt.Until(dr => dr.FindElement(By.XPath("//select[@ng-options='addrType.value as addrType.text for addrType in modalAddressTypes']")).Displayed);
            IWebElement elementR = Global.GlobalDefinitions.driver.FindElement(By.XPath("//select[@ng-options='addrType.value as addrType.text for addrType in modalAddressTypes']"));
            elementR.Click();
            Global.GlobalDefinitions.wait(500);
            SelectElement SelectR = new SelectElement(elementR);
            Thread.Sleep(500);
            SelectR.SelectByText(Global.ExcelLib.ReadData(2, "AddressType"));
            Thread.Sleep(500);

            //Search Address
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

            //Adding screenshot in extendReport
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Address added successfully");
            string screenShotPath = Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Click Contact Link");
           // test.Log(LogStatus.Fail, stackTrace + errorMessage);
            Base.test.Log(LogStatus.Fail, "Snapshot below: " + Base.test.AddScreenCapture(screenShotPath));
           // Global.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "add address");
            //click Save button
            Save.Click();
            Global.GlobalDefinitions.wait(500);

            ////Enter the Street Name
            //StreetName.SendKeys(Global.ExcelLib.ReadData(2, "StreetName"));
            //Global.GlobalDefinitions.wait(500);

            ////Enter the Suburb
            //Suburb.SendKeys(Global.ExcelLib.ReadData(2, "Suburb"));
            //Global.GlobalDefinitions.wait(500);

            ////Enter the City
            //City.SendKeys(Global.ExcelLib.ReadData(2, "City"));
            //Global.GlobalDefinitions.wait(500);

            ////Enter the State
            //State.SendKeys(Global.ExcelLib.ReadData(2, "State"));
            //Global.GlobalDefinitions.wait(500);

            ////Select the Country
            //IWebElement country = Global.GlobalDefinitions.driver.FindElement(By.Name("CountryId"));
            //country.Click();
            //Global.GlobalDefinitions.wait(500);
            //SelectElement CountryEle = new SelectElement(country);
            //CountryEle.SelectByText(Global.ExcelLib.ReadData(2, "Country"));
            //Global.GlobalDefinitions.wait(500);

            ////Enter the Zipcode
            //Zipcode.SendKeys(Global.ExcelLib.ReadData(2, "Zipcode"));
            //Global.GlobalDefinitions.wait(500);

            ////Global.GlobalDefinitions.wait(1000);
            //////Click Save button
            ////Console.WriteLine("Click save button");
            //var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            //wait.Until(dr => dr.FindElement(By.XPath("//form[@name='modalForm']/div[@class='modal-footer']/span/button[1]")).Displayed);
            //IWebElement SaveClick = Global.GlobalDefinitions.driver.FindElement(By.XPath("//form[@name='modalForm']/div[@class='modal-footer']/span/button[1]"));
            //Global.GlobalDefinitions.wait(1000);
            //SaveClick.Click();
            //Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Data added successfully");
            ////Alert checking
            //IAlert confirmationAlert = GlobalDefinitions.driver.SwitchTo().Alert();
            //String alertText = confirmationAlert.Text;
            //Console.WriteLine("Alert text is= " + alertText);
            //Global.Base.test.Log(LogStatus.Pass, "Alert text is= " + alertText);
            //Thread.Sleep(4000);
            //confirmationAlert.Accept();
            ////Verification 
            ////check if the data  available or not
            //try
            //{
            //    IList address = GlobalDefinitions.driver.FindElements(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][1]"));
            //    int countadd = address.Count;
            //    Global.GlobalDefinitions.wait(1000);

            //    for (int i = 1; i <= countadd; i++)
            //    {
            //        string TextAddres = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][" + i + "]//div[@class='col-md-9']/div[contains(text(),'15 Melrose, Mount Roskill, ')]")).Text;
            //        string[] data = TextAddres.Split(',');
            //        string streetNo = Regex.Match(data[0], @"\d+").Value;
            //        string streetName = Regex.Match(data[0], @"\D+").Value;
            //        Global.GlobalDefinitions.wait(500);
            //        if (streetNo.ToLower() == Global.ExcelLib.ReadData(2, "StreetNo").ToLower())
            //        {
            //            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Data found record with Street Name & Street No");
            //            SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Found Added Address");
            //            GlobalDefinitions.driver.Close();
            //        }
            //        else
            //        {
            //            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Data not found record with Street Name & Street No");
            //        }

            //    }
            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception occured " + e.Message);
            //}

            ////validating all the input fields

            //// Validating the Street No maximum numbers
            //string StreetNoErrMsg = " Incorrect Format: Only numbers & Max 10 numbers  ";
            //string StreetNameErrMsg = " Incorrect Format ";
            //string SuburbErrMsg = " Incorrect Format ";

            //try
            //{
            //    Assert.AreEqual(StreetNoErrMsg, "//span[text()=' Incorrect Format: Only numbers & Max 10 numbers  ']", Global.ExcelLib.ReadData(2, "StreetNo"));
            //    Global.Base.test.Log(LogStatus.Pass, "Street No : Expected & Actual results are equal");

            //}
            //catch (Exception e)
            //{
            //    Global.Base.test.Log(LogStatus.Fail, "Test fail");
            //    Global.Base.test.Log(LogStatus.Info, e.Message + ">>No message for Invalid Street No");
            //}

            //try
            //{
            //    Assert.AreEqual(StreetNameErrMsg, "//input[@name='nameStreetName']//following::span[3]", Global.ExcelLib.ReadData(2, "StreetName"));
            //    Global.Base.test.Log(LogStatus.Pass, "Street Name : Expected & Actual results are equal");

            //}
            //catch (Exception e)
            //{
            //    Global.Base.test.Log(LogStatus.Fail, "Test fail");
            //    Global.Base.test.Log(LogStatus.Info, e.Message + ">>No message for Invalid Street Name");
            //}

            //try
            //{
            //    Assert.AreEqual(SuburbErrMsg, "//input[@name='nameSuburb']//following::span[3]", Global.ExcelLib.ReadData(2, "Suburb"));
            //    Global.Base.test.Log(LogStatus.Pass, "Suburb : Expected & Actual results are equal");

            //}
            //catch (Exception e)
            //{
            //    Global.Base.test.Log(LogStatus.Fail, "Test fail");
            //    Global.Base.test.Log(LogStatus.Info, e.Message + ">>No message for Invalid Suburb");
            //}

        }

        private void WaitForElementPresent(IWebElement autoCompleteOption)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region EditAddress
        public void EditAddress()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "EditContacts");
            Global.GlobalDefinitions.wait(1000);

            //Click Contact Link
            ContactLink.Click();
            Global.GlobalDefinitions.wait(1000);

            try
            {
                IList Listaddress = GlobalDefinitions.driver.FindElements(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][1]"));
                int countEdit = Listaddress.Count;
                Global.GlobalDefinitions.wait(1000);
                Console.WriteLine("count" + countEdit);
                for (int i = 1; i <= countEdit; i++)
                {
                    string TextAddres = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][" + i + "]//div[@class='col-md-9']/div[contains(text(),'15 Melrose, Mount Roskill, ')]")).Text;
                    string[] data = TextAddres.Split(',');
                    string streetNo = Regex.Match(data[0], @"\d+").Value;
                    string streetName = Regex.Match(data[0], @"\D+").Value;
                    Global.GlobalDefinitions.wait(500);
                    if (streetNo.ToLower() == Global.ExcelLib.ReadData(2, "StreetNo").ToLower())
                    {
                        //Console.WriteLine("streetNo" + Global.ExcelLib.ReadData(2, "StreetNo"));
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Data found record with Street Name & Street Name");
                        Thread.Sleep(2000);
                        //Click on Edit button 
                        GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][" + i + "]//div[@class='col-md-9']/div[contains(text(),'15 Melrose, Mount Roskill, ')]//following::div[@class='position-bottom'][1]/a[1]/i")).Click();
                        Thread.Sleep(2000);
                        SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Found Edit Address");


                        //Populate in collection
                        Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "EditContacts");
                        Global.GlobalDefinitions.wait(1000);

                        //Edit address type
                        // IWebElement editType = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//div[@class='col-md-4 ng-scope'][" + i + "]//a[@class='btn btn-warning btn-xs']"));
                        var waittEdit = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
                        waittEdit.Until(dr => dr.FindElement(By.XPath("//form[@name='modalForm']//span[@class='editable-wrap editable-select ng-scope'][1]//select[@name='nameAddressType']")).Displayed);
                        IWebElement editType = Global.GlobalDefinitions.driver.FindElement(By.XPath("//form[@name='modalForm']//span[@class='editable-wrap editable-select ng-scope'][1]//select[@name='nameAddressType']"));
                        editType.Click();
                        Global.GlobalDefinitions.wait(500);
                        SelectElement SelectR = new SelectElement(editType);
                        Thread.Sleep(1000);
                        SelectR.SelectByText("Work");
                        Thread.Sleep(1000);

                        //Enter the Street No
                        IWebElement StreetNo = GlobalDefinitions.driver.FindElement(By.XPath("//form[@name='modalForm']//span[@class='editable-wrap editable-select ng-scope'][1]//following::input[@name='nameStreetNo']"));
                        StreetNo.Clear();
                        StreetNo.SendKeys("75");
                        Global.GlobalDefinitions.wait(500);

                        //Enter the Street Name
                        IWebElement Streetname = GlobalDefinitions.driver.FindElement(By.XPath("//form[@name='modalForm']//span[@class='editable-wrap editable-select ng-scope'][1]//following::input[@name='nameStreetName']"));
                        Streetname.Clear();
                        Streetname.SendKeys(Global.ExcelLib.ReadData(2, "StreetName"));

                        Global.GlobalDefinitions.wait(500);

                        //Enter the Suburb
                        Suburb.Clear();
                        Suburb.SendKeys(Global.ExcelLib.ReadData(2, "Suburb"));
                        Global.GlobalDefinitions.wait(500);

                        //Enter the City
                        City.Clear();
                        City.SendKeys(Global.ExcelLib.ReadData(2, "City"));
                        Global.GlobalDefinitions.wait(500);

                        //Enter the State
                        State.Clear();
                        State.SendKeys(Global.ExcelLib.ReadData(2, "State"));
                        Global.GlobalDefinitions.wait(500);

                        //Select the Country
                        IWebElement country = Global.GlobalDefinitions.driver.FindElement(By.Name("CountryId"));
                        country.Click();
                        Global.GlobalDefinitions.wait(500);
                        SelectElement CountryEle = new SelectElement(country);
                        CountryEle.SelectByText(Global.ExcelLib.ReadData(2, "Country"));
                        Global.GlobalDefinitions.wait(500);

                        //Enter the Zipcode
                        Zipcode.Clear();
                        Zipcode.SendKeys(Global.ExcelLib.ReadData(2, "Zipcode"));
                        Global.GlobalDefinitions.wait(500);

                        //Clicking Save Button
                        GlobalDefinitions.driver.FindElement(By.XPath("//form[@name='modalForm']//span[@class='editable-wrap editable-select ng-scope'][1]//following::div[@class='modal-footer']/span/button[1]")).Click();
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Data edited successfully");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Data not found record with Street Name & Street No");
                    }

                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e.Message);
            }


        }
        #endregion

        #region DeleteAddress
        public void DeleteAddress()
        {
            //Populate in collection
            Global.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "DeleteAddress");
            Global.GlobalDefinitions.wait(1000);

            //Click Contact Link
            ContactLink.Click();
            Global.GlobalDefinitions.wait(1000);

            //clicking delete record
            try
            {
                IList ListDelete = GlobalDefinitions.driver.FindElements(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][1]"));
                int countDelete = ListDelete.Count;
                Global.GlobalDefinitions.wait(1000);
                //Console.WriteLine("count" + countDelete);
                for (int i = 1; i <= countDelete; i++)
                {
                    string TextAddres = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][" + i + "]//div[@class='col-md-9']/div[contains(text(),'75 Melrose, NewLynn, ')]")).Text;
                    Console.WriteLine("add"+ TextAddres);
                    string[] data = TextAddres.Split(',');
                    string streetNo = Regex.Match(data[0], @"\d+").Value;
                    string streetName = Regex.Match(data[0], @"\D+").Value;
                    Console.WriteLine("streetNo"+ streetNo);
                    Global.GlobalDefinitions.wait(500);
                    Console.WriteLine("no-=="+ Global.ExcelLib.ReadData(2, "StreetNo"));
                    if (streetNo.ToLower() == Global.ExcelLib.ReadData(2, "StreetNo").ToLower())
                    {
                        //Click on Delete button 
                        Console.WriteLine("both are same");
                        var waitDelete = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
                        waitDelete.Until(dr => dr.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][1]//div[@class='col-md-9']/div[contains(text(),'75 Melrose, NewLynn, ')]//following::div[@class='position-bottom']//a[@class='btn btn-danger btn-xs ng-pristine ng-valid ng-empty ng-touched']/i")).Displayed);
                        GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][1]//div[@class='col-md-9']/div[contains(text(),'75 Melrose, NewLynn, ')]//following::div[@class='position-bottom']//a[@class='btn btn-danger btn-xs ng-pristine ng-valid ng-empty ng-touched']/i")).Click();
                       // GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='tab - 5']/div/div/div[2]/div/div[2]/div[1]/a[2]/i")).Click();
                        
                        Global.GlobalDefinitions.wait(4000);
                        SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Found Delete Address");
                        //Get the text message
                        //string error_msg = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][" + i + "]//div[@class='col-md-9']/div[contains(text(),'75 Melrose, NewLynn, ')]//following::div[@class='position-bottom']//a[@class='btn btn-danger btn-xs ng-pristine ng-valid ng-empty ng-touched']/i")).Text;
                        //Console.WriteLine("meeage" + error_msg);
                        //if (error_msg == "Do you want to Delete")
                        //{
                        //    GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='tab-5']//following::div[@class='col-md-12 contact-panel'][" + i + "]//div[@class='col-md-9']/div[contains(text(),'75 Melrose, NewLynn, ')]//following::div[@class='position-bottom']//a[@class='btn btn-danger btn-xs']//i[@class='glyphicon glyphicon-trash'][last()]")).Click();
                        //}

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e.Message);
            }
        }
        #endregion
    }
}
