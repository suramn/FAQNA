// <copyright file="FAQNABot.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

namespace FAQNABOT.Bots
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;

    /// <summary>
    ///  This Class Invokes all Bot Conversation functionalites.
    /// </summary>
    public class FAQNABot : ActivityHandler
    {
        /// <summary>
        /// The method that gets invoked each time there is a message that is coming in.
        /// </summary>
        /// <param name="turnContext">The current turn.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of Execution.</returns>
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string text = string.IsNullOrEmpty(turnContext.Activity.Text) ? string.Empty : turnContext.Activity.Text.ToLower();

            List<Attachment> nextMessage = null;

            if (!string.IsNullOrEmpty(text))
            {
                nextMessage = await this.GetMessageFromText(turnContext, text, cancellationToken);
            }

            if (nextMessage.Count > 1)
            {
                await turnContext.SendActivityAsync(MessageFactory.Carousel(nextMessage));
            }
            else
            {
                await turnContext.SendActivityAsync(MessageFactory.Attachment(nextMessage[0]));
            }
        }

        /// <summary>
        /// The method that gets invoked when the bot is first opened after installation.
        /// </summary>
        /// <param name="membersAdded">The account that has been eiter added or interacting with the bot.</param>
        /// <param name="turnContext">The current turn/execution flow.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A unit of Execution.</returns>
        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var faqnaBotProvider = new FAQNABotProvider();
            var cardAttachment = faqnaBotProvider.CreateWelcomeCardAttachment();
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Attachment(cardAttachment), cancellationToken);
                }
            }
        }

        /// <summary>
        /// Sends the Appropriate Adaptive Card to the user parsing the text.
        /// </summary>
        /// <param name="context">The current turn/execution flow.</param>
        /// <param name="text">Parses the text from user conversation.</param>
        /// <param name="cancellationToken">The cancellation Token.</param>
        /// <returns>Approrpriate Card.</returns>
        private async Task<List<Attachment>> GetMessageFromText(ITurnContext context, string text, CancellationToken cancellationToken)
        {
            List<Attachment> nextMessage = null;
            var faqnaBotProvider = new FAQNABotProvider();
            if (text == "hi"
                     || text == "hello"
                     || text == "reset"
                     || text == "start over"
                     || text == "restart")
            {
                // starts the conversation all over again from the welcome message,
                // since the user has decided to restart the bot
                nextMessage = new List<Attachment>() { await Task.Run(() => faqnaBotProvider.CreateWelcomeCardAttachment()) };
            }
            else if (context.Activity.Text == "Take a tour")
            {
                var carouselCards = new List<string>() { "carousel1", "carousel2", "carousel3" };
                nextMessage = await Task.Run(() => faqnaBotProvider.CreateTourCardCarouselAttachment(carouselCards));
            }
            else
            {
                await context.SendActivityAsync(MessageFactory.Text("Hey, I don't understand what you're saying, would you like to take a tour"), cancellationToken);
                nextMessage = new List<Attachment>() { await Task.Run(() => faqnaBotProvider.CreateWelcomeCardAttachment()) };
            }

            return nextMessage;
        }
    }
}