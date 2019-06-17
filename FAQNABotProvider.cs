// <copyright file="FAQNABotProvider.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace FAQNABOT
{
    using System.Collections.Generic;
    using System.IO;
    using FAQNABOT.AdaptiveCardHelpers;
    using Microsoft.Bot.Schema;
    using Newtonsoft.Json;

    /// <summary>
    ///  This is a Calss Provides logic for Card Attachments.
    /// </summary>
    public class FAQNABotProvider
    {
        private static string welcome = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "WelcomeCard.json");

        /// <summary>
        /// Creates the adaptive card for the team welcome message.
        /// </summary>
        /// <returns>The Welcome Adaptive card.</returns>
        public Attachment CreateWelcomeCardAttachment()
        {
            var adaptiveWelcomeCardJson = WelcomeCard.GetCard();
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveWelcomeCardJson),
            };
            return adaptiveCardAttachment;
        }

        /// <summary>
        /// Displays Carousel of Tour Cards.
        /// </summary>
        /// <param name="cards">List of Carousel Cards.</param>
        /// <returns>The Tour Adaptive card.</returns>
        public List<Attachment> CreateTourCardCarouselAttachment(List<string> cards)
        {
            var carouselAttachments = new List<Attachment>();
            foreach (var card in cards)
            {
                string path = card + ".json";
                path = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", path);
                var adaptiveTourCardJson = File.ReadAllText(path);
                var adaptiveTourCardAttachment = new Attachment()
                {
                    ContentType = "application/vnd.microsoft.card.adaptive",
                    Content = JsonConvert.DeserializeObject(adaptiveTourCardJson),
                };
                carouselAttachments.Add(adaptiveTourCardAttachment);
            }

            return carouselAttachments;
        }
    }
}
