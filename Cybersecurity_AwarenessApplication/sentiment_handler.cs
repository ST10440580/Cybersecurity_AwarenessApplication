using System.Collections.Generic;

namespace Cybersecurity_AwarenessApplication
{
    public class sentiment_handler
    {
        //keywords for sentiments 
        private readonly string[] positivekeywords = { "good", "great", "happy", "excited", "amazing", "fun", "love", "cool" };
        private readonly string[] negativekeywords = { "sad", "bad", "angry", "frustrated", "upset", "hate", "worried", "tired", "scared", "nervous" };

        public string DetectSentiment(string input)
        {
            string lowerInput = input.ToLower();

            foreach (string word in positivekeywords)
                if (lowerInput.Contains(word)) return "positive";

            foreach (string word in negativekeywords)
                if (lowerInput.Contains(word)) return "negative";

            return "neutral";
        }//endof constructor
    }//endof class
}//endof namespace