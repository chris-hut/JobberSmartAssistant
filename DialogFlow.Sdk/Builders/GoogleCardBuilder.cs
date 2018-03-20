using System;
using DialogFlow.Sdk.Models.Messages;

namespace DialogFlow.Sdk.Builders
{
    public class GoogleCardBuilder
    {
        private readonly GoogleCardMessage _googleCardMessage;

        private GoogleCardBuilder()
        {
            _googleCardMessage = new GoogleCardMessage();
        }

        public static GoogleCardBuilder Create()
        {
            return new GoogleCardBuilder();
        }

        public GoogleCardBuilder Title(string title)
        {
            _googleCardMessage.Title = title;
            return this;
        }

        public GoogleCardBuilder Subtitle(string subtitle)
        {
            _googleCardMessage.Subtitle = subtitle;
            return this;
        }

        public GoogleCardBuilder Content(string content)
        {
            _googleCardMessage.FormattedText = content;
            return this;
        }

        public GoogleCardBuilder Image(string imageUrl)
        {
            _googleCardMessage.Image.Url = imageUrl;
            return this;
        }

        public GoogleCardBuilder WithButton(string label, string url)
        {
            _googleCardMessage.Buttons.Add(new GoogleCardButton
            {
                Label = label,
                Url = new UrlContainer
                {
                    Url = url
                }
            });
            return this;
        }

        public GoogleCardMessage Build()
        {
            return _googleCardMessage;
        }
    }
}