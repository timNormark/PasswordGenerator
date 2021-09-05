using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordGenerator.Core.Services.GeneratePasswordService.PasswordGenerators
{
    public class StudentYear1To3PasswordGenerator : IPasswordGenerator
    {
        private readonly IEnumerable<string> words;

        public StudentYear1To3PasswordGenerator(PasswordGeneratorSettings settings)
        {
            if(settings == null)
                throw new ArgumentNullException(nameof(settings));
            if(settings.Words?.Any() != true)
                throw new ArgumentException("Could not load any words from PasswordGeneratorSettings");

            words = settings.Words;
        }

        public string Generate()
        {
            var random = new Random();
            int index = random.Next(words.Count());
            return words.ElementAt(index);
        }
    }
}
