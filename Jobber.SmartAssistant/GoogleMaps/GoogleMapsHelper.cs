namespace Jobber.SmartAssistant.GoogleMaps
{
    public static class GoogleMapsHelper
    {
        public static string GetStaticMapLinkFor(string address)
        {
            return "https://maps.googleapis.com/maps/api/staticmap?" +
                   "center=&" +
                   "zoom=14&" +
                   "scale=2&" +
                   "size=600x300&" +
                   "maptype=roadmap" +
                   "&format=png" +
                   "&visual_refresh=true" +
                   $"&markers=size:mid%7Ccolor:0xb848ff%7Clabel:1%7C{address}";
        }

        public static string GetGoogleMapsLinkFor(string address)
        {
            return $"https://maps.google.com/?q={address}";
        }
    }
}