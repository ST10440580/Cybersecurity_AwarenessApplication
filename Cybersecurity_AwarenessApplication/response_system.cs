using System;
using System.Collections;
using System.Collections.Generic;

namespace Cybersecurity_AwarenessApplication
{
    public class response_system
    {
        public response_system()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Red;
            string Chatbot = "Chatbot:";
            Console.ResetColor();

            // Prompt user for their name
            Console.WriteLine($"{Chatbot}Please enter your name");
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"User:{name}");
            Console.ResetColor();

            Console.WriteLine($"{Chatbot} Welcome to the chatbot {name}");

            // Initialize the ArrayList with questions and answers
            ArrayList chatbot_responses = new ArrayList()
            {
                new string[] { "phishing", "Phishing is a form of online fraud in which hackers attempt to get your private information such as passwords, credit cards, or bank account data..." },
                new string[] { "password", "Use strong, unique passwords for each account. A password manager can help generate and store them securely." },
                new string[] { "safe browsing", "Always check for HTTPS, avoid suspicious websites, and never download files from unknown sources." },
                new string[] { "how are you", "I'm good thank you for asking!" },
                new string[] { "who are you", "I am a cybersecurity chatbot here to help you stay safe online. Ask me about phishing, passwords, or browsing security!" },
                new string[] { "how can i prevent phishing", "Keep Informed About Phishing Techniques..." },
                new string[] { "how can i further strengthen my browsing experience", "Use a Quick Minimal Browser..." },
                new string[] { "how often should i change my passwords", "Use Strong, Unique Passwords..." },
                new string[] { "can i use the same password for multiple accounts", "Reusing the same password for multiple accounts makes you vulnerable to cyber attacks..." },
                new string[] { "how can i securely store my passwords", "Password manager applications offer an excellent alternative to using your browser's password storage..." },
                new string[] { "what is two-factor authentication", "Two-factor authentication adds an extra layer of security..." },
                new string[] { "how can i avoid malware when downloading files", "Install and update antivirus software..." },
                new string[] { "what's the difference between http and https", "HTTPS is just HTTP with encryption..." },
                new string[] { "can i trust public wi-fi networks", "Many public Wi-Fi hotspots are unencrypted..." },
                new string[] { "how do i know if a website is legitimate", "You can use a website legitimacy checker in any browser..." },
                new string[] { "can browser extensions compromise my security", "Yes, malicious or bad add-ons compromise personal data..." },
                new string[] { "how can I spot a fake email", "Inspect the Email Header Info to Verify..." },
                new string[] { "what is the goal of phishing attacks", "Gaining unauthorized access to systems and stealing money..." },
                new string[] { "can phishing happen through text messages", "When smishing, cybercriminals send harmful links via text message..." },
                new string[] { "what should I do with suspicious links", "Hover over the link itself to see if it’s consistent with the domain..." },
                new string[] { "how do phishers get my email address", "Scammers use brute force attacks to generate various alphanumeric combinations..." },
                new string[] { "who am i", $"Your name is {name} as you mentioned" },
            };

            while (true)
            {
                // Prompt user to ask chatbot questions
                Console.WriteLine($"{Chatbot}Please ask questions related to the following topics:" +
                    $"\n1.Passwords \n2.Safe Browsing \n3.Phishing.                                                                                                                      ");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("============================================================================================================================================================");
                Console.ResetColor();

                // Prompt users input with added colour
                Console.ForegroundColor = ConsoleColor.Green;
                string user_response = Console.ReadLine();
                Console.WriteLine($"{name}: " + user_response);
                Console.ResetColor();

                if (user_response.ToLower() == "exit")
                {
                    Console.WriteLine($"{Chatbot}Thank you for using our chatbot {name}!");
                    break;
                }

                // Search for the response in the ArrayList
                bool found = false;
                foreach (string[] response in chatbot_responses)
                {
                    if (user_response.ToLower().Contains(response[0].ToLower()))
                    {
                        Console.WriteLine($"{Chatbot} {response[1]}");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"\U000026A0! {Chatbot} Please rephrase your question as I am programmed to answer questions related to passwords, phishing, or safe browsing.");
                }
            }
        }
    }
}
