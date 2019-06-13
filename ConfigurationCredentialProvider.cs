// <copyright file="ConfigurationCredentialProvider.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace FAQNABOT
{
    using Microsoft.Bot.Connector.Authentication;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// The credentials provider class.
    /// </summary>
    public class ConfigurationCredentialProvider : SimpleCredentialProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationCredentialProvider"/> class.
        /// </summary>
        /// <param name="configuration">Contains necessary credential properties.</param>
        public ConfigurationCredentialProvider(IConfiguration configuration)
            : base(configuration["MicrosoftAppId"], configuration["MicrosoftAppPassword"])
        {
        }
    }
}