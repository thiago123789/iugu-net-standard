using System;
using System.Collections.Generic;
using System.Text;
using iugu.net.standard.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iugu.test
{
    [TestClass]
    public class PaymentMethodTest
    {
        private PaymentMethod _paymentMethod;

        [TestInitialize]
        public void Initial()
        {
            _paymentMethod = new PaymentMethod(customerId:"", apiToken:"");
        }

        [TestMethod]
        public void AssertDescriptionReturn()
        {
            var result = _paymentMethod.PutAsync(id: "", desc:"Description Teste").Result;
            Assert.IsTrue(result.description == "Description Teste");
        }
    }
}
