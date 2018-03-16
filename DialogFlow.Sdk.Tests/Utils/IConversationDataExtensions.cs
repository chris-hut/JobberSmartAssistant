using DialogFlow.Sdk.Intents;
using NUnit.Framework;

namespace DialogFlow.Sdk.Tests.Utils
{
    public static class IConversationDataExtensions
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