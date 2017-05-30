using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld.Tests
{
    [TestClass()]
    public class GetConsoleTextTests
    {
        [TestMethod()]
        public void GetHelloWorldBoldTest()
        {
            IGetText gt = new GetConsoleText();
            string text = gt.GetHelloWorldBold();
            Assert.AreEqual(text, "*** Hello World! ***");

        }

        [TestMethod()]
        public void GetHelloWorldLightTest()
        {
            IGetText gt = new GetConsoleText();
            string text = gt.GetHelloWorldLight();
            Assert.AreEqual(text, "(hello world)");
        }

        [TestMethod()]
        public void GetHelloWorldPlainTest()
        {
            IGetText gt = new GetConsoleText();
            string text = gt.GetHelloWorldPlain();
            Assert.AreEqual(text, "Hello World");
        }
    }
}