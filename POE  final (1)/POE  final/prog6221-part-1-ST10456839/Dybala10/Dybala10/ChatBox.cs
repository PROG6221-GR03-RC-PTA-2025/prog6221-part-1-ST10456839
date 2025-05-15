using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dybala10
{
    public class Chatbot
    {
        private Dictionary<string, string> keywordResponses = new Dictionary<string, string>
    {
        { "password", "Use strong, unique passwords and avoid personal information." },
        { "scam", "Never share your personal info with untrusted sources." },
        { "privacy", "Review your privacy settings regularly." }
    };

        private List<string> phishingTips = new List<string>
    {
        "Don't click links from unknown emails.",
        "Check the sender's email address carefully.",
        "Look for grammar mistakes in suspicious messages."
    };

        private Dictionary<string, string> sentiments = new Dictionary<string, string>
    {
        { "worried", "It's okay to feel worried. You're not alone." },
        { "frustrated", "Take it slow—you're learning something important." },
        { "curious", "Nice! Curiosity is key to cybersecurity." }
    };

        private Random random = new Random();

        public void HandleInput(string input, UserProfile user)
        {
            input = input.ToLower();

            foreach (var sentiment in sentiments.Keys)
            {
                if (input.Contains(sentiment))
                {
                    Console.WriteLine(sentiments[sentiment]);
                    return;
                }
            }

            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    Console.WriteLine(keywordResponses[keyword]);
                    return;
                }
            }

            if (input.Contains("phishing"))
            {
                Console.WriteLine(phishingTips[random.Next(phishingTips.Count)]);
                return;
            }

            Console.WriteLine("I’m not sure I understand. Can you try rephrasing?");
        }
    }
}
