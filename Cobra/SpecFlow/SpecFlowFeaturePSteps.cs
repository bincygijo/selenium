using Framework.Config;
using Framework.Global;
using Framework.Pages;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Framework.SpecFlow
{
    [Binding]
    class SpecFlowFeaturePSteps
    {
        public string ReportPath { get; private set; }
        public ExtentTest test { get; private set; }

        [Given(@"I have logged into Alex Swift Emergency Contact  portal")]
        public void GivenIHaveLoggedIntoAlexSwiftEmergencyContactPortal()
        {
            //Init and define chrome driver
            GlobalDefinitions.driver = new ChromeDriver();

            //Creating object for Login class to access Loginstep method
            Login loginobj = new Login();
            loginobj.LoginStep();


            //Initialise Report
            Global.Base.extent = new ExtentReports(ReportPath, true, DisplayOrder.NewestFirst);
            //Load report cofig file
            Global.Base.extent.LoadConfig(Resource.ReportXMLPath);
        }

        [Then(@"I should be able to Update Profile Successfully")]
        public void ThenIShouldBeAbleToUpdateProfileSuccessfully()
        {
            //Start the Add address test
            test = Global.Base.extent.StartTest("Edit profile test case starts");
            //Creating object for Profile class to access EditProfleSteps method
            Profilee profobj = new Profilee();
            profobj.EditProfleSteps();

            Base.extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            Base.extent.Flush();
        }

      
    }
}
