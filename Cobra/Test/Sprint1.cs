using Framework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    class Sprint1
    {
        [TestFixture]
        [Category("Sprint_1")]
        class Profile : Global.Base
        {
            //*---------- Created By Bincy Gijo on 15/10/2017................*

            [SetUp]
            public void LoginCheck()
            {
               // Creating object for Login class to access Loginstep method
                Login loginobj = new Login();
                loginobj.LoginStep();
                Global.GlobalDefinitions.wait(1000);
            }
            [Test]
            public void ValidateWelcome()
            {
                //Start the Welcome page starts
                test = extent.StartTest("Welcome Profile Information starts here ");
                WelcomeInfo WelcomeObj = new WelcomeInfo();
                WelcomeObj.ValidatePersonalInfo();


            }
            [Test]
            public void ValidateEmail()
            {
                //Start the Duplicate email Address test
                test = extent.StartTest("Checking Email Id duplication ");
                Registration objRej = new Registration();
                objRej.ValidateEmailAlreadyExixts();
            }

            [Test]
            public void AddAddress()
            {
                //Start the Add address test
                test = extent.StartTest("Add adress test case starts");
                //Start the code here
                Console.WriteLine("Please start wrting the tests here");
            }
            [Test]
            public void Assigntask()
            {
                //Start the Add address test
                test = extent.StartTest("Assign task test case starts");
                TaskQueue taskobj = new TaskQueue();
                taskobj.AssignTask();

            }

          [Test]
           public void EditProfile()
            {
                //Start the Add address test
                test = extent.StartTest("Edit profile test case starts");
                //Creating object for Profile class to access EditProfleSteps method
                Profilee profobj = new Profilee();
                profobj.EditProfleSteps();
                //profobj.ManageDocuments();
            }
            [Test]
            public void UploadDocuments()
            {
                //Start the Delete document test
             test = extent.StartTest("Upload document test case starts");
               ManageDocuments uploadobj = new ManageDocuments();
               uploadobj.UploadDocuments();
               uploadobj.PreviewDocument();

           }

          //[Test]
          // public void UploadProfile()
          //  {
          //      //Start the Delete document test
          //      test = extent.StartTest("Upload document test case starts");
          //      Profile1 profobj = new Profile1();
          //      profobj.UploadProfile();
                

          //  }
            [Test]
            public void Addaddress()
            {
                //Start the Add Address test
              test = extent.StartTest("Add Address test case starts");
              Contacts ConObj = new Contacts();
              ConObj.Addaddress();
           }
            [Test]
            public void EditAddress()
            {
               //Start the Edit Address test
                test = extent.StartTest("Edit Address test case starts");
               Contacts ConObj = new Contacts();
               ConObj.EditAddress();
           }
            [Test]
            public void DeleteAddress()
            {
                //Start the Delete Address test
                test = extent.StartTest("Delete Address test case starts");
                Contacts ConObj = new Contacts();
                ConObj.DeleteAddress();
            }
            [Test]
            public void Add()
            {
                Address addObj = new Pages.Address();
                addObj.Add_address();

            }
            [Test]
            public void ValidateCal()
            {
                Welcome objWel = new Welcome();
                objWel.ValidateCalender();


            }
           

        }
    }
}
