using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestClasses;

namespace MyTestClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {

        [TestMethod]
        [Owner("tmount")]
        public void AreColletionsEqualFailsBeacauseNoComparerTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Paul", LastName = "Sherif" });
            peopleExpected.Add(new Person() { FirstName = "Terrance", LastName = "Mount" });
            peopleExpected.Add(new Person() { FirstName = "Heather", LastName = "Helgeson" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("tmount")]
        public void AreColletionsEqualWithComparerTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Paul", LastName = "Sherif" });
            peopleExpected.Add(new Person() { FirstName = "Terrance", LastName = "Mount" });
            peopleExpected.Add(new Person() { FirstName = "Heather", LastName = "Helgeson" });

            peopleActual = mgr.GetPeople();

            CollectionAssert.AreEqual(peopleExpected, peopleActual, 
                Comparer<Person>.Create((x, y) => 
                    x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        [Owner("tmount")]
        public void AreColletionsEqivalentTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);

            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("tmount")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = mgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
    }
}
