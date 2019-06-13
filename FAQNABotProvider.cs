// <copyright file="FAQNABotProvider.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace FAQNABOT
{
    using System.IO;
    using FAQNABOT.AdaptiveCardHelpers;
    using FAQNABOT.Bots;
    using Microsoft.Bot.Schema;
    using Newtonsoft.Json;

    /// <summary>
    ///  This is a Calss Provides logic for Card Attachments.
    /// </summary>
    public class FAQNABotProvider
    {
        private string welcome = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "WelcomeCard.json");
        private string tour = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "TourCard.json");

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
        /// Creates the adaptive card for Tour Functionality.
        /// </summary>
        /// <returns>The Tour Adaptive card.</returns>
        public Attachment CreateTourCardAttachment()
        {
            var adaptiveTourCardJson = File.ReadAllText(this.tour);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveTourCardJson),
            };
            return adaptiveCardAttachment;
        }
    }
}
