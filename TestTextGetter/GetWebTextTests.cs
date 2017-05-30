using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld.Tests
{
    [TestClass()]
    public class GetWebTextTests
    {
        [TestMethod()]
        public void GetHelloWorldBoldTest()
        {
            IGetText gt = new GetWebText();
            string text = gt.GetHelloWorldBold();
            Assert.AreEqual(text, "<h1>Hello World!!</h1>");
        }

        [TestMethod()]
        public void GetHelloWorldLightTest()
        {
            IGetText gt = new GetWebText();
            string text = gt.GetHelloWorldLight();
            Assert.AreEqual(text, "<i>(hello world)</i>");
        }

        [TestMethod()]
        public void GetHelloWorldPlainTest()
        {
            IGetText gt = new GetWebText();
            string text = gt.GetHelloWorldPlain();
            Assert.AreEqual(text, "<span>Hello World</span>");




        }
    }
}