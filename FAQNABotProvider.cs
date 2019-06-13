using FAQNABOT.AdaptiveCardHelpers;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FAQNABOT.Bots;

namespace FAQNABOT
{
    public  class FAQNABotProvider
    {
        private  string _welcome = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "WelcomeCard.json");
        private  string _tour = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "TourCard.json");

        /// <summary>
        /// Creates the adaptive card for the team welcome message
        /// </summary>
        ///<param name="filePath">Parses the Adaptive Card Json Path</param>
        /// <returns>The Welcome Adaptive card</returns>
        public  Attachment CreateWelcomeCardAttachment()
        {
            var adaptiveWelcomeCardJson = WelcomeCard.GetCard();
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveWelcomeCardJson),
            };
            return adaptiveCardAttachment;
        }

        public  Attachment CreateTourCardAttachment()
        {
            var adaptiveTourCardJson = File.ReadAllText(_tour);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveTourCardJson),
            };
            return adaptiveCardAttachment;
        }
    }
}
