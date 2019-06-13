// <copyright file="Program.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace FAQNABOT
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// The main class which represents the main execution point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method of execution.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The web host builder interface implementation.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>The web host builder.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}