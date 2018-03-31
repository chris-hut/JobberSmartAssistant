namespace Jobber.SmartAssistant.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoringCase(this string str, string comparasionString)
        {
            return str.ToLower().Contains(comparasionString.ToLower());
        }
    }
}