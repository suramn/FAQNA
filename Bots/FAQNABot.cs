// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System;
using Microsoft.Bot;
using FAQNABOT.AdaptiveCardHelpers;

namespace FAQNABOT.Bots
{
    public class FAQNABot : ActivityHandler
    {
        private string _welcome = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "WelcomeCard.json");
        private string _tour = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", "TourCard.json");

        /// <summary>
        /// The method that gets invoked each time there is a message that is coming in
        /// </summary>
        /// <param name="turnContext">The current turn</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A unit of execution</returns>

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string text = string.IsNullOrEmpty(turnContext.Activity.Text) ? string.Empty : turnContext.Activity.Text.ToLower();

            Attachment nextMessage = null;

            if (!string.IsNullOrEmpty(text))
            {
                nextMessage = await GetMessageFromText(turnContext,text);
            }
           
            await turnContext.SendActivityAsync(MessageFactory.Attachment(nextMessage));
        }
        /// <summary>
        /// The method that gets invoked when the bot is first opened after installation
        /// </summary>
        /// <param name="membersAdded">The account that has been eiter added or interacting with the bot</param>
        /// <param name="turnContext">The current turn/execution flow</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A unit of Execution</returns>
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var cardAttachment = CreateWelcomeCardAttachment();
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                }
            }
        }
        /// <summary>
        /// Creates the adaptive card for the team welcome message
        /// </summary>
        ///<param name="filePath">Parses the Adaptive Card Json Path</param>
        /// <returns>The Welcome Adaptive card</returns>

        private Attachment CreateWelcomeCardAttachment()
        {
            var adaptiveWelcomeCardJson = WelcomeCard.GetCard();
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveWelcomeCardJson),
            };
            return adaptiveCardAttachment;
        }
        private Attachment CreateTourCardAttachment()
        {
            var adaptiveTourCardJson = File.ReadAllText(_tour);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveTourCardJson),
            };
            return adaptiveCardAttachment;
        }
        /// <summary>
        /// Sends the Appropriate Adaptive Card to the user parsing the text
        /// </summary>
        ///<param name="context">The current turn/execution flow</param>
        ///<param name="text">Parses the text from user conversation</param>
        /// <returns>Approrpriate Card</returns>
        private async Task<Attachment> GetMessageFromText(ITurnContext context, string text)
        {
            Attachment nextMessage = null;

            if (text == "hi"
                     || text == "hello"
                     || text == "reset"
                     || text == "start over"
                     || text == "restart")
            {
                //starts the conversation all over again from the welcome message, since the user has decided to restart the bot
                nextMessage = await Task.Run(() => CreateWelcomeCardAttachment());
            }
            else if(text.ToLower() == "take a tour")
            {
                nextMessage = await Task.Run(() => CreateTourCardAttachment());
            }
            else
            {
                nextMessage = await Task.Run(() => CreateWelcomeCardAttachment());

            }

            return nextMessage;
        }
       
    }
}
