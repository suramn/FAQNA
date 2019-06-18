using FAQNABOT.Properties;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FAQNABOT.BotHelperMethods.AdaptiveCards
{
    public static class Carousel1
    {
        private static string cardTemplate;

        static Carousel1()
        {
            var cardJsonFilePath = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "Carousel1.json");
            cardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// This method performs a function that helps with localisation using Resx.
        /// </summary>
        /// <returns>Card attachement as Json stirng.</returns>
        public static Attachment GetCard()
        {
            var botName = Resource.BotName;
            var welcomeText1 = Resource.WelcomeText1;
            var welcomeText2 = Resource.WelcomeText2;
            var messageText1 = Resource.MessageText1;
            var bulletedList = Resource.BulletedList;
            var messageText2 = Resource.MessageText2;
            var takeATourButtonText = Resource.TakeATourButtonText;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "BotName", botName },
                { "WelcomeText1", welcomeText1 },
                { "WelcomeText2", welcomeText2 },
                { "MessageText1", messageText1 },
                { "BulletedList", bulletedList },
                { "MessageText2", messageText2 },
                { "TakeATourButtonText", takeATourButtonText },
            };

            var cardBody = cardTemplate;
            foreach (var kvp in variablesToValues)
            {
                cardBody = cardBody.Replace($"%{kvp.Key}%", kvp.Value);
            }

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(cardBody),
            };

            return adaptiveCardAttachment;
        }
    }
}
