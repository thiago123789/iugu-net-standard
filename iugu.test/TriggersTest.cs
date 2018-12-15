using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using iugu.net.standard.Lib;
using iugu.net.standard.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iugu.test
{
    [TestClass]
    public class TriggersTest
    {
        private Triggers _triggers;

        [TestInitialize]
        public void Initial()
        {
            _triggers = new Triggers("api_key");
        }

        [TestMethod]
        public void AssertTypeReturn()
        {
            var result = _triggers.GetEventListAsync().Result;
            Assert.IsInstanceOfType(result, typeof(List<string>).BaseType);
        }

        [TestMethod]
        public void AssertHasContent()
        {
            var result = _triggers.GetEventListAsync().Result;
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.WriteLine(result.ElementAt(0));
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestCreatingTrigger()
        {
            var triggerObj = new TriggerRequestMessage()
            {
                Event = "all",
                Url = "http://minhaUrldeTeste.com",
                Authorization = "TOKENDETESTE"
            };
            var result = _triggers.CreateTriggerAsync(triggerObj).Result;
            Assert.IsTrue(!string.IsNullOrEmpty(result.Id));
        }


        [TestMethod]
        public void TestCreatingAndDeleteTrigger()
        {
            var triggerObj = new TriggerRequestMessage()
            {
                Event = "all",
                Url = "http://minhaUrldeTeste.com",
                Authorization = "TOKENDETESTE"
            };
            var result = _triggers.CreateTriggerAsync(triggerObj).Result;
            var resultDelete = _triggers.DeleteTriggerAsync(result.Id).Result;

            Assert.IsTrue(result.Id == resultDelete.Id);
        }
    }
}
