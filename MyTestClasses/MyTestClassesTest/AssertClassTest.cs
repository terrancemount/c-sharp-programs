using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestClasses;

namespace MyTestClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("tmount")]
        public void AreEqualTest()
        {
            string str1 = "Paul";
            string str2 = "Paul";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("tmount")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitveTest()
        {
            string str1 = "Paul";
            string str2 = "paul";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("tmount")]
        public void AreNotEqualTest()
        {
            string str1 = "Paul";
            string str2 = "John";

            Assert.AreNotEqual(str1, str2, false);
        }

        #endregion

        #region AreSame / AreNotSame Tests
        [TestMethod]
        [Owner("tmount")]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        [Owner("tmount")]
        public void AreSameNotTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }
        #endregion

        #region IsInstanceOftype Test

        [TestMethod]
        [Owner("tmount")]
        public void IsInstaceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Terrance", "Mount", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }
        #endregion

        #region IsNull Test

        [TestMethod]
        [Owner("tmount")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Mount", true);

            Assert.IsNull(per);
        }
        #endregion
    }
}
