using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTestClassesTest
{
    [TestClass]
    public class StringAssertClassTests
    {
     

        [TestMethod]
        [Owner("tmount")]
        public void ContainsTest()
        {
            string str1 = "Terrance Mount";
            string str2 = "Mount";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("tmount")]
        public void StartWithTest()
        {
            string str1 = "Terrance Mount";
            string str2 = "Terrance";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("tmount")]
        public void IsAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        [Owner("tmount")]
        public void IsNotAllLowerCaseTest()
        {
            Regex r = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("All lower case", r);
        }

    }
}
