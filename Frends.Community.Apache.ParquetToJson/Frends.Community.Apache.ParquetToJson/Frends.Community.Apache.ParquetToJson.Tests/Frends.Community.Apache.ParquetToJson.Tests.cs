using NUnit.Framework;
using System;

namespace Frends.Community.Apache.ParquetToJson.Tests
{
    [TestFixture]
    class TestClass
    {
        /// <summary>
        /// You need to run Frends.Community.Apache.ParquetToJson.SetPaswordsEnv.ps1 before running unit test, or some other way set environment variables e.g. with GitHub Secrets.
        /// </summary>
        [Test]
        public void ThreeParquetToJsonTasks()
        {
            var input = new Parameters
            {
                Message = Environment.GetEnvironmentVariable("EXAMPLE_ENVIROMENT_VARIABLE")
        };

            var options = new Options
            {
                Amount = 3,
                Delimiter = ", "
            };

            var ret = ParquetToJsonTask.ParquetToJson(input, options, new System.Threading.CancellationToken());

            Assert.That(ret.Replication, Is.EqualTo("foobar, foobar, foobar"));
        }
    }
}
