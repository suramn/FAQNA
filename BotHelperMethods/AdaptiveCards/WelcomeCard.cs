// <copyright file="WelcomeCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace FAQNABOT.AdaptiveCardHelpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using FAQNABOT.Properties;

    /// <summary>
    ///  This class process an Welcome Card function.
    /// </summary>
    public class WelcomeCard
    {
        private static string cardTemplate;

        static WelcomeCard()
        {
            var cardJsonFilePath = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "WelcomeCard.json");
            cardTemplate = File.ReadAllText(cardJsonFilePath);
        }

        /// <summary>
        /// This method performs a function that helps with localisation using Resx.
        /// </summary>
        /// <returns>Card attachement as Json stirng.</returns>
        public static string GetCard()
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

            return cardBody;
        }
    }
}
