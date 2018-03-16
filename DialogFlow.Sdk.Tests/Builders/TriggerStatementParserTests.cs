using System.Runtime.CompilerServices;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Intents;
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
    }

    internal static class IConversationDataExtensions
    {
        public static void AssertIsTextDataWith(this IConversationData conversationData, string text)
        {
            Assert.IsTrue(conversationData is TextData);
            var textData = (TextData) conversationData;
            Assert.AreEqual(text, textData.Text);
        }

        public static void AssertIsEntityDataWith(this IConversationData conversationData, string meta, string alias, string text)
        {
            Assert.IsTrue(conversationData is EntityData);
            var entityData = (EntityData) conversationData;
            Assert.AreEqual(alias, entityData.Alias);
            Assert.AreEqual(meta, entityData.Meta);
            Assert.AreEqual(text, entityData.Text);
        }
    } 
}