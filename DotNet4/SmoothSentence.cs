using System;

namespace DotNet4
{
    public static class SmoothSentence
    {
        public static bool IsSmoothSentence(string sentence)
        {
            sentence = sentence.Trim().ToLower();
            string[] words = sentence.Split(' ');

            if (words.Length <= 1)
            {
                return false;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string firstWord = words[i];
                char lastChar = Char.Parse(firstWord.Substring(firstWord.Length - 1));

                string secondWord = words[i + 1];
                char firstChar = Char.Parse(secondWord.Substring(0, 1));

                if (lastChar != firstChar)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
