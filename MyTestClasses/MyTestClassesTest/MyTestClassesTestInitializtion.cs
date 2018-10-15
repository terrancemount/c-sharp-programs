using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTestClassesTest
{
    /// <summary>
    /// Summary description for MyTestClassesTestInitializtion
    /// </summary>
    [TestClass]
    public class MyTestClassesTestInitializtion
    {
       
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In the Assemby Initilize Method");
            //creates all the needed stuff here for all the tests.  
            //examples will be databases, xml files, or data needed for the tests.
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //delete any data that was created with the assembyInitialize function
        }
    }
}
