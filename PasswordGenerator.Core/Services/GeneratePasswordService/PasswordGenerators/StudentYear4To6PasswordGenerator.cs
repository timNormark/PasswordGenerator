using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordGenerator.Core.Services.GeneratePasswordService.PasswordGenerators
{
    public class StudentYear4To6PasswordGenerator : IPasswordGenerator
    {
        private const string _upperCase = "ABCDEFGHIJKLMNOPQRSTUVXYZ";
        private const string _lowerCase = "abcdefghijklmnopqrstuvxyz";
        private const string _numbers = "1234567890";
        private readonly List<string> charTypes = new List<string>
        {
            _upperCase, _lowerCase, _numbers
        };

        public string Generate()
        {
            var random = new Random();
            string password = "";

            // make sure there is at least one of every type och char
            password += _upperCase[random.Next(_upperCase.Length)];
            password += _lowerCase[random.Next(_lowerCase.Length)];
            password += _numbers[random.Next(_numbers.Length)];

            // Add 5 more random chars
            for (int i = 0; i < 5; i++)
            {
                string charSet = charTypes[random.Next(charTypes.Count)];
                password += charSet[random.Next(charSet.Length)];
            }

            // Shuffle the password
            password = new string(password.OrderBy(_ => Guid.NewGuid()).ToArray());
            return password;
        }
    }
}
