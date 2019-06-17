// <copyright file="CarouselCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace FAQNABOT.BotHelperMethods.AdaptiveCards
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    ///  This class process Carousel Tour Card function.
    /// </summary>
    public class CarouselCard
    {
        private static string cardTemplate;

        static CarouselCard()
        {
            string path = ".json";
            path = Path.Combine(".", "BotHelperMethods", "AdaptiveCards", path);
            cardTemplate = File.ReadAllText(path);
        }
    }
}
