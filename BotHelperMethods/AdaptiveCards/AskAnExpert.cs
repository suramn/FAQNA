// <copyright file="AskAnExpert.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace FAQNABOT.BotHelperMethods.AdaptiveCards
{
    using System.Collections.Generic;
    using System.IO;
    using FAQNABOT.Properties;
    using Microsoft.Bot.Schema;
    using Newtonsoft.Json;

    /// <summary>
    ///  This class process an Carousel AskAnExpert card.
    /// </summary>
    public static class AskAnExpert
    {
        private static string cardTemplate;

        static AskAnExpert()
        {
            var cardJsonFilePath = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "AskAnExpert.json");
            cardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// This method performs a function that helps with localization using Resx file.
        /// </summary>
        /// <returns>Card attachment as Json string.</returns>
        public static Attachment GetCard()
        {
            var askAnExpertText1 = Resource.AskAnExpertText1;
            var askAnExpertText2 = Resource.AskAnExpertText2;
            var variablesToValues = new Dictionary<string, string>()
            {
                { "AskAnExpertText1", askAnExpertText1 },
                { "AskAnExpertText2", askAnExpertText2 },
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
