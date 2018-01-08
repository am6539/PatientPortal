using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Domain.Utilities
{
    public class RandomString
    {
        private static Random random = new Random();

        public static string Generate(int length, EnumRandomStringType type)
        {
            string number = "0123456789";
            string character = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder builder = new StringBuilder();
            switch (type)
            {
                case EnumRandomStringType.NumberOnly:
                    builder.Append(number);
                    break;
                case EnumRandomStringType.CharacterOnly:
                    builder.Append(character);
                    break;
                case EnumRandomStringType.NumberAndUpperCharacter:
                    builder.Append(number).Append(character);
                    break;
                case EnumRandomStringType.NumberAndLowerCharater:
                    builder.Append(number).Append(character.ToLower());
                    break;
                case EnumRandomStringType.NumberAndCharacter:
                    builder.Append(number).Append(character).Append(character.ToLower());
                    break;
                default:
                    break;
            }

            string chars = builder.ToString();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public enum EnumRandomStringType
    {
        NumberOnly,
        CharacterOnly,
        NumberAndUpperCharacter,
        NumberAndLowerCharater,
        NumberAndCharacter
    }
}
