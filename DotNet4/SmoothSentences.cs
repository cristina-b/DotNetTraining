using System;

namespace DotNet4
{
    public static class SmoothSentence
    {
        public static bool IsSmoothSentence(string sentence)
        {
            sentence = sentence.Trim().ToLower();
            string[] sentences = sentence.Split(' ');

            if (sentence.Length <= 1)
            {
                return false;
            }

            for (int i = 0; i < sentences.Length - 1; i++)
            {
                string previousWord = sentences[i];
                char lastChar = Char.Parse(previousWord.Substring(previousWord.Length - 1));

                string followingWord = sentences[i + 1];
                char firstChar = Char.Parse(followingWord.Substring(0, 1));

                if (lastChar != firstChar)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
