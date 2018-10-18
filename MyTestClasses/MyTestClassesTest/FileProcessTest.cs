using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestClasses;
using System.Configuration; //add a System.Configuration Reference to the project references
using System.IO;

namespace MyTestClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        const string BAD_FILE_NAME = @"C:\BadFilename.bad";
        private string _goodFileName; //the name of the file name to be added
        public TestContext TestContext { get; set; }

        #region Class Initialize and Cleanup
        //use the initialization and cleanup if most of the class (75% or above) needs the resource
        //otherwise just use the method init and cleanup

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            tc.WriteLine("In the Class Initialze.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //clean up stuff that was initialized.
        }

        #endregion

        #region Test Initalize and Cleanup
        //this is run before each test
        [TestInitialize]
        public void TestInitialize()
        {
            //this will match with any function that starts with the same name convention
            if(TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_goodFileName))
                {
                    TestContext.WriteLine("Creating File: " + _goodFileName);
                    File.AppendAllText(_goodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (!string.IsNullOrEmpty(_goodFileName))
                {
                    TestContext.WriteLine("Deleting the file: " + _goodFileName);
                    File.Delete(_goodFileName);
                }
            }
        }
        #endregion

        #region Helper - SetGoodFileName
        /**
         * Sets the good file name for testing.
         */
        public void SetGoodFileName()
        {
            _goodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_goodFileName.Contains("[AppPath]"))
            {
                _goodFileName = _goodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        #endregion

        //shows how to write out a simple message
        [TestMethod]
        [Owner("Terrance")]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fp = new FileProcess(); //Arrange
            bool fromCall;

            fromCall = fp.FileExists(_goodFileName); //Act

            Assert.IsFalse(fromCall, "File Does NOT Exist."); //assert
        }

        //Paul is a big fan of putting messages in the assert.
        //shows how to write out a simple message
        [TestMethod]
        [Owner("Terrance")]
        public void FileNameDoesExistSimpleMessageWithFormatting()
        {
            FileProcess fp = new FileProcess(); //Arrange
            bool fromCall;

            fromCall = fp.FileExists(_goodFileName); //Act

            //give a message with formatting.  Adds the filename so you can start tracking down were the error is.  
            Assert.IsFalse(fromCall, "File '{0}' Does NOT Exist.", _goodFileName); //assert
        }


        //write test methods with discriptive method names so you can infer the purpose by reading the method name.
        [TestMethod]
        [Description("Check to see if a file exists.")] //not needed if you don't have good method name. puts in to dis
        [Owner("TerranceMount")] //useful with enterprise edition.  puts into traits as owner
        [Priority(0)] //not useful in VS but can filter by command line.
        [TestCategory("No-Exception")] //just adds another trait.
        //[Ignore()] //good for keeping the test in the test file but just skips it.
        public void FileNameDoesExist()
        {

            //Step - Arrange... Arrange all the needed variables to run the test. i.e. set up local varables.
            FileProcess fp = new FileProcess();
            bool fromCall;


            TestContext.WriteLine("Testing the file: " + _goodFileName);
            //Step - Act... Act on the local varables to test the method. 
            fromCall = fp.FileExists(_goodFileName);

        

            //Step - Assert...  Then assert the value from the act is correct.
            Assert.IsTrue(fromCall);
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Terrance")]
        [DeploymentItem(FILE_NAME)] //used to create a 
        public void FileNameDoesExistsDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;
            fromCall = fp.FileExists(fileName);

            //Step - Assert...  Then assert the value from the act is correct.
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Timeout(3000)] //good for disallowing the endless loops 
        [Ignore()]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }


        [TestMethod]
        [Owner("Terrance")]
        [Priority(0)]
        public void FileNameDoesNotExist()
        {
            //Step - Arrange... Arrange all the needed variables to run the test. i.e. set up local varables.
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Step - Act... Act on the local varables to test the method. 
            fromCall = fp.FileExists(BAD_FILE_NAME);

            //Step - Assert...  Then assert the value from the act is correct.
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] //used to test an exception.  Does not work for data driven exceptions.
        [Owner("tmount")]
        [Priority(1)]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            //Step - Arrange... Arrange all the needed variables to run the test. i.e. set up local varables.
            FileProcess fp = new FileProcess();

            fp.FileExists("");

            //also could use a try / catch block if you want to do that.
        }

        [TestMethod]
        [Owner("tmount")]
        [Priority(1)]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_TryCatch()
        {
            //Step - Arrange... Arrange all the needed variables to run the test. i.e. set up local varables.
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Call to FileExists did NOT throw an ArgumentNullException");
        }
       
    }
}
