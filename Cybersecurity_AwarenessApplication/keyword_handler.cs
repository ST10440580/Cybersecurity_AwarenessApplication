using System.Collections.Generic;
using System;

namespace Cybersecurity_AwarenessApplication
{
    public class keyword_handler
    {
        
            private readonly Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            { "password", new List<string> {
                "Use strong, unique passwords for every account.",
                "Avoid using personal information in your passwords.",
                "Consider using a password manager to generate and store passwords securely."
            }},
            { "phishing", new List<string> {
                "Phishing often involves fake emails that look real. Always double-check senders.",
                "Don’t click on suspicious links. Type URLs manually when in doubt.",
                "Look for poor spelling and grammar — common signs of a phishing attempt."
            }},
            { "privacy", new List<string> {
                "Review app permissions regularly to control your data exposure.",
                "Use encrypted messaging apps like Signal or WhatsApp.",
                "Limit what you share on social media — attackers mine this info."
            }}
        };

            public string GetResponse(string input)
            {
                foreach (var entry in keywordResponses)
                {
                    if (input.Contains(entry.Key))
                    {
                        var random = new Random();
                        var responses = entry.Value;
                        return responses[random.Next(responses.Count)];
                    }
                }

                return null; // No keyword match
            }
        }
    }

