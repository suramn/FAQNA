// <copyright file="FunctionalCard.cs" company="Microsoft">
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
    ///  This class process an Carousel Function Card.
    /// </summary>
    public static class FunctionalCard
    {
        private static string cardTemplate;

        static FunctionalCard()
        {
            var cardJsonFilePath = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "FunctionalCard.json");
            cardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// This method performs a function that helps with localization using Resx file.
        /// </summary>
        /// <returns>Card attachment as Json string.</returns>
        public static Attachment GetCard()
        {
            var functionCardText1 = Resource.FunctionCardText1;
            var functionCardText2 = Resource.FunctionCardText2;
            var functionTopicsText = Resource.FunctionTopicsText;
            var bulletedQuestionText = Resource.BulletedQuestionText;
            var askAnExpertFunctionText = Resource.AskAnExpertFunctionText;
            var takeATourButtonText = Resource.TakeATourButtonText;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "FunctionCardText1", functionCardText1 },
                { "FunctionCardText2", functionCardText2 },
                { "FunctionTopicsText", functionTopicsText },
                { "BulletedQuestionText", bulletedQuestionText },
                { "AskAnExpertFunctionText", askAnExpertFunctionText },
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
