// <copyright file="ShareFeedback.cs" company="Microsoft">
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
    ///  This class process an Carousel ShareFeedback Card.
    /// </summary>
    public static class ShareFeedback
    {
        private static string cardTemplate;

        static ShareFeedback()
        {
            var cardJsonFilePath = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "ShareFeedback.json");
            cardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// This method performs a function that helps with localization using Resx file.
        /// </summary>
        /// <returns>Card attachment as Json string.</returns>
        public static Attachment GetCard()
        {
            var sharefeedbacktitletext = Resource.ShareFeedbackTitleText;
            var feedbackText1 = Resource.FeedbackText1;
            var feedbackText2 = Resource.FeedbackText2;
            var collectFeedback = Resource.CollectFeedback;

            var variablesToValues = new Dictionary<string, string>()
            {
                { "ShareFeedbackTitleText", sharefeedbacktitletext },
                { "FeedbackText1", feedbackText1 },
                { "FeedbackText2", feedbackText2 },
                { "CollectFeedback", collectFeedback },
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
