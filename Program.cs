// <copyright file="Program.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

namespace FAQNABOT
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// This a Prgram class for this Bot.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method.
        /// </summary>
        /// <param name="args">String of Arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// This method will hit the Sartup Method to set up the complete bot services.
        /// </summary>
        /// <param name="args">String of Arguments.</param>
        /// <returns>A unit of Execution.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
