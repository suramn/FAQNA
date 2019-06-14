// <copyright file="ConfigurationCredentialProvider.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

namespace FAQNABOT
{
    using Microsoft.Bot.Connector.Authentication;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    ///  This class will have credentials for configring the application.
    /// </summary>
    public class ConfigurationCredentialProvider : SimpleCredentialProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationCredentialProvider"/> class.
        /// </summary>
        /// <param name="configuration">Configures the Bot Id.</param>
        /// <returns>A unit of Execution.</returns>
        public ConfigurationCredentialProvider(IConfiguration configuration)
            : base(configuration["MicrosoftAppId"], configuration["MicrosoftAppPassword"])
        {
        }
    }
}