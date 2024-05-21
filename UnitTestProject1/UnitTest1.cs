using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static DEMO2.MainWindow;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string login = "Client";
            string password = "Client";

            bool waits = false;
            var app = new forTest();
            Assert.AreEqual(waits, app.testc(login, password));
        }
    }
}
