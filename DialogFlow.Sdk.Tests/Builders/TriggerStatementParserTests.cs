using DialogFlow.Sdk.Builders;
using NUnit.Framework;

namespace DialogFlow.Sdk.Tests.Builders
{
    [TestFixture]
    public class TriggerStatementParserTests
    {
        [Test]
        public void Test()
        {
            var statement = "[@sys.any:amount:6]";
            var parsedStatement = new TriggerStatementParser().Parse(statement);
            
            Assert.AreEqual(1, parsedStatement.Count);
            
        }
    }
}