using System.Runtime.CompilerServices;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Tests.Utils;
using NUnit.Framework;

namespace DialogFlow.Sdk.Tests.Builders
{
    [TestFixture]
    public class TriggerStatementParserTests
    {
        [Test]
        public void TestOnlyEntityData()
        {
            var statement = "[@sys.any:amount:6]";
            var parsedStatement = new TriggerStatementParser().Parse(statement);
            
            Assert.AreEqual(1, parsedStatement.Data.Count);
            parsedStatement.Data[0].AssertIsEntityDataWith("@sys.any", "amount", "6");
        }
        
        [Test]
        public void TestOnlyEntityDataWithSpace()
        {
            var statement = "[@sys.any:name:John Applessed]";
            var parsedStatement = new TriggerStatementParser().Parse(statement);
            
            Assert.AreEqual(1, parsedStatement.Data.Count);
            parsedStatement.Data[0].AssertIsEntityDataWith("@sys.any", "name", "John Applessed");
        }
        
        [Test]
        public void TestOnlyTextData()
        {
            var statement = "What's the weather like?";
            var parsedStatement = new TriggerStatementParser().Parse(statement);
            
            Assert.AreEqual(1, parsedStatement.Data.Count);
            parsedStatement.Data[0].AssertIsTextDataWith("What's the weather like?");
        }

        [Test]
        public void TestEmbeddedEntityData()
        {
            var statement = "Can you call [@sys.any:name:John Applessed] please?";
            var parsedStatement = new TriggerStatementParser().Parse(statement);
            
            Assert.AreEqual(3, parsedStatement.Data.Count);
            parsedStatement.Data[0].AssertIsTextDataWith("Can you call ");
            parsedStatement.Data[1].AssertIsEntityDataWith("@sys.any", "name", "John Applessed");
            parsedStatement.Data[2].AssertIsTextDataWith(" please?");
        }

        [Test]
        public void TestTextEndingWithEntityData()
        {
            var statement = "Call [@sys.any:name:John Applessed]";
            var parsedStatement = new TriggerStatementParser().Parse(statement);
            
            Assert.AreEqual(2, parsedStatement.Data.Count);
            parsedStatement.Data[0].AssertIsTextDataWith("Call ");
            parsedStatement.Data[1].AssertIsEntityDataWith("@sys.any", "name", "John Applessed");
        }
    }
}