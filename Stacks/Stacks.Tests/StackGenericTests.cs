using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stacks.Library;
using System;

namespace Stacks.Tests
{
    [TestClass]
    public class StackGenericTests
    {

        [TestMethod]
        public void CanPopOffItem()
        {
            var stack = new MyGenericStack<string>(100);
            stack.Push("foo");
            Assert.AreEqual("foo", stack.Pop());
        }

      
    }
}
