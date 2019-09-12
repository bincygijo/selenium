using Framework.Global;
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

namespace Framework.Pages
{
    class Address
    {
        // Initializing the web elements 
        internal Address()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Finding Contact link
        [FindsBy(How = How.XPath, Using = "//li/a[text()='Contacts']")]
        private IWebElement ContactLink { get; set; }

        //Finding (+) link
        [FindsBy(How = How.XPath, Using = "//div[@class='custom-btn']/input[@ng-click='showAddAddressModal()']")]
        private IWebElement AddLink { get; set; }

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
        [FindsBy(How = How.XPath, Using = "//span/button[1]")]
        private IWebElement Save { get; set; }

        public void Add_address()
        {
            try
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
            waitt.Until(dr => dr.FindElement(By.XPath("//select[@name='nameAddressType']")).Displayed);
            IWebElement elementR = Global.GlobalDefinitions.driver.FindElement(By.XPath("//select[@name='nameAddressType']"));
            elementR.Click();
            Global.GlobalDefinitions.wait(500);
            SelectElement SelectR = new SelectElement(elementR);
            Thread.Sleep(500);
            SelectR.SelectByText(Global.ExcelLib.ReadData(2, "AddressType"));
            Thread.Sleep(500);

            //Enter the Street No
            StreetNo.SendKeys(Global.ExcelLib.ReadData(2, "StreetNo"));
            Global.GlobalDefinitions.wait(500);

            //Enter the Street Name
            StreetName.SendKeys(Global.ExcelLib.ReadData(2, "StreetName"));
            Global.GlobalDefinitions.wait(500);

            //Enter the Suburb
            Suburb.SendKeys(Global.ExcelLib.ReadData(2, "Suburb"));
            Global.GlobalDefinitions.wait(500);

            //Enter the City
            City.SendKeys(Global.ExcelLib.ReadData(2, "City"));
            Global.GlobalDefinitions.wait(500);

            //Enter the State
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
            Zipcode.SendKeys(Global.ExcelLib.ReadData(2, "Zipcode"));
            Global.GlobalDefinitions.wait(500);

            //Clicking Save Button
            var wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            wait.Until(dr => dr.FindElement(By.XPath("//form[@name='modalForm']/div[@class='modal-footer']/span/button[1]")).Displayed);
            IWebElement SaveClick = Global.GlobalDefinitions.driver.FindElement(By.XPath("//form[@name='modalForm']/div[@class='modal-footer']/span/button[1]"));
            Global.GlobalDefinitions.wait(1000);
            SaveClick.Click();
            Console.WriteLine("Data added successfully");
            Global.Base.test.Log(LogStatus.Pass, "New Data added successfully");
            //Alert handling
            string textAlert = GlobalDefinitions.driver.SwitchTo().Alert().Text;
            Console.WriteLine("Alert=" + textAlert);
            if(textAlert== "Address already exist")
                {
                    GlobalDefinitions.driver.SwitchTo().Alert().Accept();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured in Address page" + e.Message);
            }

        }
    }
}
