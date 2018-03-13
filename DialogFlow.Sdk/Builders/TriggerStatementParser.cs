using System;
using DialogFlow.Sdk.Intents;

namespace DialogFlow.Sdk.Builders
{
    public class TriggerStatementParser
    {
        public UserSays Parse(string triggerStatement)
        {
            var userData = new UserSays();
            var remainingStatement = triggerStatement;

            while (remainingStatement.Trim().Length > 0)
            {
                var nextEntityIndex = remainingStatement.IndexOf("@");
                if (nextEntityIndex != -1)
                {
                    var currentText = remainingStatement.Substring(0, nextEntityIndex);
                    if (!String.IsNullOrEmpty(currentText))
                    {
                        userData.Data.Add(new TextData
                        {
                            Text = currentText
                        });
                    }

                    remainingStatement = remainingStatement.Substring(nextEntityIndex);
                    var indexOfNextSpace = remainingStatement.IndexOf(" ");
                    var entityBindingText = remainingStatement.Substring(0, indexOfNextSpace);
                    var entityBindingTextTokens = entityBindingText.Split(':');
                    
                    userData.Data.Add(new EntityData
                    {
                        Meta = entityBindingTextTokens[0],
                        Alias = entityBindingTextTokens[1],
                        Text = entityBindingTextTokens[2],
                        UserDefined = false
                    });

                    remainingStatement = remainingStatement.Substring(indexOfNextSpace);

                }
                else
                {
                    if (!String.IsNullOrEmpty(remainingStatement))
                    {
                        userData.Data.Add(new TextData
                        {
                            Text = remainingStatement.TrimEnd()
                        });
                    }
                    
                    break;
                }
            }

            return userData;
        }
    }
}