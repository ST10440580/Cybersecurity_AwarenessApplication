using System;
using System.Collections;
using System.Collections.Generic;

namespace Cybersecurity_AwarenessApplication
{
    public class response_system
    {
        private readonly sentiment_handler sentimentAnalyzer = new sentiment_handler();
        private readonly memory_management memory = new memory_management();

     
        private readonly Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            {"phishing", new List<string>{
                "Phishing is a type of cyberattack where attackers try to trick people into giving away sensitive information like passwords, credit card numbers, or personal details—usually by pretending to be a trustworthy source via email or messages.\r\n\r\n",
                "Phishing typically involves fake emails that look like they're from legitimate companies (like your bank or Netflix), asking you to click a link and \"verify your account\"—but the link leads to a malicious site designed to steal your information.",
                "It's a form of social engineering where cybercriminals pose as someone you trust—like a coworker, manager, or company—to get you to send them confidential data or make payments.",
                " Phishing often creates a sense of urgency (e.g., “Your account will be locked in 24 hours”) to pressure victims into clicking links or downloading attachments without thinking critically.",
                "While most phishing happens through email, it can also occur via SMS (\"smishing\"), phone calls (\"vishing\"), or even on social media platforms through fake messages or ads. "
            }},
            {"password", new List<string>{
                "A password is a secret combination of characters that users create to prove their identity and gain access to systems, accounts, or devices.\r\n\r\n",
                "Passwords act as a first line of defense against unauthorized access. Without the correct password, attackers are blocked from entering your accounts or devices.\r\n\r\n",
                "Strong passwords usually include a mix of uppercase and lowercase letters, numbers, and special characters to make them harder for hackers to guess or crack." ,
                "They are one of the most common authentication methods used in both personal and professional settings to confirm that you are who you say you are.\r\n\r\n" ,
                "Weak passwords—like \"123456\" or \"password\"—are easy for hackers to guess. That’s why using complex, unique passwords for every account is important."
            }},
            {"privacy", new List<string>{
                "Privacy is the right to control your personal information and how it’s collected, used, or shared—whether online or offline.",
                "Online privacy means protecting your data—like browsing history, location, and social media activity—from being tracked or misused by websites, companies, or hackers.\r\n\r\n",
                "A key principle of privacy is only sharing the minimum amount of information necessary. The less you share, the lower the risk of that data being stolen or misused.",
                "Privacy includes managing the permissions you grant to apps on your phone or computer—such as access to your camera, microphone, or contacts.\r\n\r\n"
            }},
            {"safe browsing" ,new List<string> {
                "Safe browsing is the practice of using the internet in a way that protects your personal data, devices, and privacy from online threats like malware, scams, or malicious websites.\r\n\r\n",
                "When visiting websites, always check for “HTTPS” in the URL. The \"S\" stands for \"secure\" and means the site encrypts your data, helping prevent it from being intercepted by attackers.",
                "Never click on links or download files from unknown sources. Even if they appear in emails or messages from people you know, they could be part of a phishing scam.",
                "Browsers release frequent updates to patch security flaws. Enabling automatic updates ensures you have the latest protections against known vulnerabilities."
            }},
             {"browsing" ,new List<string> {
                "Safe browsing is the practice of using the internet in a way that protects your personal data, devices, and privacy from online threats like malware, scams, or malicious websites.\r\n\r\n",
                "When visiting websites, always check for “HTTPS” in the URL. The \"S\" stands for \"secure\" and means the site encrypts your data, helping prevent it from being intercepted by attackers.",
                "Never click on links or download files from unknown sources. Even if they appear in emails or messages from people you know, they could be part of a phishing scam.",
                "Browsers release frequent updates to patch security flaws. Enabling automatic updates ensures you have the latest protections against known vulnerabilities."
             } },
                   {"scam" ,new List<string> {
                "Online scams can be convincing ,A scam is a dishonest scheme or trick used to cheat someone out of their money, personal information, or access to their accounts. ",
                "Online scams often come through emails, fake websites, or social media, where scammers pretend to be legitimate companies or individuals to fool you into giving up sensitive info.",
                "Many scams offer something that sounds amazing—like a free prize, inheritance, or miracle investment—but these are bait to lure victims into giving money or data.",
                "Phishing is one common form of scam where attackers impersonate trusted sources to steal credentials, financial info, or infect your device with malware."
        }} };

        private Dictionary<string, string> userMemory = new Dictionary<string, string>();
        private int responseCount = 0;

        public response_system()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("============================================================================================================================================================");
            Console.WriteLine("============================================================================================================================================================");
            Console.WriteLine("██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗\r\n██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝\r\n██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗  \r\n██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝  \r\n╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗\r\n ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Chatbot:");
            Console.ResetColor();
            Console.WriteLine("Please enter your name");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User:");
            Console.ResetColor();
            string name = Console.ReadLine();
            userMemory["name"] = name;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Chatbot:");
            Console.ResetColor();
            Console.WriteLine($"Welcome to the chatbot, {name}!");
           // Console.WriteLine("          ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Chatbot:");
            Console.ResetColor();
            Console.WriteLine("Please ask questions related to the following topics:\n1.Passwords,\n2.Safe Browsing or \n3.Phishing.\nIf you would like to continue asking the chatbot questions you may carry on asking more questions and if not type in exit to leave the program.Also if youre interested in any topic be sure to tell us");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("============================================================================================================================================================");
            Console.WriteLine("============================================================================================================================================================");
            Console.ResetColor();

            while (true)
            {
                string user_response = capture_user_response(name);
                memory.AddToMemory($"{name},{user_response}");

                if (user_response.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Chatbot:");
                    Console.ResetColor();
                    Console.WriteLine($"Thank you for using our chatbot {name} have yourself a splendid day! ");
                    break;
                }

                string sentiment = sentimentAnalyzer.DetectSentiment(user_response);
                HandleSentiment(sentiment, name);

                // Detect interest
                if (user_response.ToLower().Contains("interested in"))
                {
                    foreach (var topic in keywordResponses.Keys)
                    {
                        if (user_response.ToLower().Contains(topic))
                        {
                            userMemory["favoriteTopic"] = topic;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Chatbot:");
                            Console.ResetColor();
                            Console.WriteLine($"Great! I'll remember that you're interested in {topic}.");
                           // Console.WriteLine("          ");
                        }
                    }
                    continue;
                }

                bool found = false;
                foreach (var keyword in keywordResponses.Keys)
                {
                    if (user_response.ToLower().Contains(keyword))
                    {
                        Random rand = new Random();
                        List<string> responses = keywordResponses[keyword];
                        string reply = responses[rand.Next(responses.Count)];

                        // Only print "Chatbot:" once before response
                        Console.ForegroundColor = ConsoleColor.Magenta;
                       
                        Console.ResetColor();
                        Console.WriteLine(reply);

                        // If user has a favorite topic, mention it every 3 turns
                        responseCount++;
                        if (userMemory.ContainsKey("favoriteTopic") && responseCount % 3 == 0)
                        {
                            Console.WriteLine($"Since you're interested in {userMemory["favoriteTopic"]}, here's something to keep in mind:" + reply);
                        }
                        //Console.WriteLine();
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (user_response.ToLower().Contains("understand") || user_response.ToLower().Contains("confused") || user_response.ToLower().Contains("more details"))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        //Console.WriteLine("Chatbot:");
                        Console.ResetColor();
                        Console.WriteLine($"No worries, {name}. I can clarify that. Could you tell me what part you're unsure about?");
                       // Console.WriteLine("          ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                       
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Sorry {name}, I didn't quite get that. Please ask about passwords, phishing, or safe browsing. ");
                        Console.ResetColor();
                       // Console.WriteLine("          ");
                    }
                }
            }
        }

        private string capture_user_response(string name)
        {
            string input = "";
            ConsoleKeyInfo userinput;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{name}: ");
            Console.ResetColor();
            //Console.WriteLine("          ");

            do
            {
                userinput = Console.ReadKey(true);
                if (userinput.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.Write("\b \b");
                }
                else if (userinput.Key != ConsoleKey.Enter)
                {
                    input += userinput.KeyChar;
                    Console.Write(userinput.KeyChar);
                }
            } while (userinput.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return input;
        }

        private void HandleSentiment(string sentiment, string name)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Chatbot:");
            Console.ResetColor();
            switch (sentiment)
            {
                case "negative":
                    Console.WriteLine($"I'm sorry you're feeling that way, {name}. Cybersecurity can feel overwhelming—but you're not alone.");
                    break;
                case "positive":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Glad to hear that, {name}! Let's keep that momentum going.");
                    break;
            }
           
           
        }
    }
}
