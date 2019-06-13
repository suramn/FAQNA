// <copyright file="FAQNABot.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace FAQNABOT.Bots
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using Newtonsoft.Json;

    /// <summary>
    /// This is the bot class.
    /// </summary>
    public class FAQNABot : ActivityHandler
    {
        private string welcome = Path.Combine(".", "AdaptiveCards", "WelcomeCard.json");
        private string tour = Path.Combine(".", "AdaptiveCards", "TourCard.json");

        /// <summary>
        /// The method that gets invoked each time there is a message that is coming in.
        /// </summary>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string text = string.IsNullOrEmpty(turnContext.Activity.Text) ? string.Empty : turnContext.Activity.Text.ToLower();

            string nextMessage = null;

            if (!string.IsNullOrEmpty(text))
            {
                nextMessage = await this.GetMessageFromText(turnContext, text);
            }

            await turnContext.SendActivityAsync(MessageFactory.Attachment(CreateAdaptiveCardAttachment(nextMessage)));
        }

        /// <summary>
        /// The method that gets invoked when the bot is first opened after installation.
        /// </summary>
        /// <param name="membersAdded">The account that has been eiter added or interacting with the bot.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of execution.</returns>
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var cardAttachment = CreateAdaptiveCardAttachment(this.welcome);
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                }
            }
        }

        /// <summary>
        /// Creates the adaptive card for the team welcome message.
        /// </summary>
        /// <param name="filePath">Parses the Adaptive Card Json Path.</param>
        /// <returns>The Welcome Adaptive card.</returns>
        private static Attachment CreateAdaptiveCardAttachment(string filePath)
        {
            var adaptiveCardJson = File.ReadAllText(filePath);
            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        /// <summary>
        /// Sends the Appropriate Card to the user parsing the text.
        /// </summary>
        /// <param name="context">The current turn/execution flow.</param>
        /// <param name="text">Parses the text from user conversation.</param>
        /// <returns>Approrpriate Card.</returns>
        private async Task<string> GetMessageFromText(ITurnContext context, string text)
        {
            string nextMessage = null;

            if (text == "hi"
                     || text == "hello"
                     || text == "reset"
                     || text == "start over"
                     || text == "restart")
            {
                // starts the conversation all over again from the welcome message,
                // since the user has decided to restart the bot
                nextMessage = await Task.Run(() => this.welcome);
            }
            else if (text.ToLower() == "take a tour")
            {
                nextMessage = await Task.Run(() => this.tour);
            }

            return nextMessage;
        }
    }
}