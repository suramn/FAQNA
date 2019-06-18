// <copyright file="FAQNABotProvider.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace FAQNABOT
{
    using System.Collections.Generic;
    using System.IO;
    using FAQNABOT.AdaptiveCardHelpers;
    using FAQNABOT.BotHelperMethods.AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Newtonsoft.Json;

    /// <summary>
    ///  This is a Class Provides logic for Card Attachments.
    /// </summary>
    public class FAQNABotProvider
    {
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
        /// <returns>The Tour Adaptive card.</returns>
        public List<Attachment> CreateTourCardCarouselAttachment()
        {
            return new List<Attachment>()
            {
                FunctionalCard.GetCard(),
                AskAnExpert.GetCard(),
                ShareFeedback.GetCard(),
            };
        }
    }
}
