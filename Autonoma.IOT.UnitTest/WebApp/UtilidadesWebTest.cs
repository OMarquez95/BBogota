using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autonoma.IOT.WebApp.Helpers;
using Autonoma.IOT.Common.Extensions;

namespace Autonoma.IOT.UnitTest.WebApp
{
    [TestClass]
    public class UtilidadesWebTest
    {
        [TestMethod]
        public void GetJsonDiffTestMethod()
        {
            try
            {
                string filejson1 = "{'key1':'1','key2':'value2'}";
                string filejson2 = "{'key1':'11','key2':'value2'}";

                var result = Utilidades.GetJsonDiff(ref filejson1, ref filejson2);
            }
            catch(Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
