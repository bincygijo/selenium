using Framework.Config;
using Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Global
{
    class Base
    {
        #region To access Path from resource file
        public static int Browser = Int32.Parse(Resource.Browser);
        public static String ExcelPath = Resource.ExcelPath;
        public static string ScreenshotPath = Resource.ScreenShotPath;
        public static string ReportPath = Resource.ReportPath;
        public static string UploadPath = Resource.UploadPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;

       
        #endregion

        #region Setup
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    var options = new ChromeOptions();
                    options.AddArguments("chrome.switches", "--disable-extensions  --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    GlobalDefinitions.driver = new ChromeDriver(options);
                    break;

            }

            //Creating object for Login class to access Loginstep method
            //Login loginobj = new Login();
            //loginobj.LoginStep();
            //Global.GlobalDefinitions.wait(1000);

            //Initialise Report
            extent = new ExtentReports(ReportPath, true, DisplayOrder.NewestFirst);
            //Load report cofig file
            extent.LoadConfig(Resource.ReportXMLPath);
        }
        #endregion


        #region TearDown
        [TearDown]
        public void TearDown()
        {
            // Screenshot
           //String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
            //test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :           
            //GlobalDefinitions.driver.Close();
        }
        #endregion

    }
}
