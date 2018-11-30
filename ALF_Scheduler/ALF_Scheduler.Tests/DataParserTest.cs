// <copyright file="DataParserTest.cs">Copyright ©  2018</copyright>
using System;
using ALF_Scheduler;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ALF_Scheduler.Tests
{
    /// <summary>This class contains parameterized unit tests for DataParser</summary>
    [PexClass(typeof(DataParser))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DataParserTest
    {
        private string[] _testExcelColumns = { "facility name", "licensee name", "U", "752103", "98001", "City", "08/14/2016", "02/23/2018", "03/23/2019", "07/25/2019", "08/25/2019", "Miranda", "Yes" };

        [TestMethod]
        public void CreateDateTime_Success() {
            DateTime testDate = new DateTime(2018, 7, 22);
            Assert.AreEqual(testDate, DataParser.CreateDateTime("07/22/18"));
            Assert.AreEqual(testDate, DataParser.CreateDateTime("07/22/2018"));
        }

        [TestMethod]
        public void CreateDateTime_Fail() {
            DateTime testDate = new DateTime(2018, 7, 22);
            Assert.AreNotEqual(testDate, DataParser.CreateDateTime("02/22/88"));
            Assert.AreNotEqual(testDate, DataParser.CreateDateTime("02/22/2088"));
        }
    }
}
