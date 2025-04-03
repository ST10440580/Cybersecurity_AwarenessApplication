using System;
using System.Collections;

namespace Cybersecurity_AwarenessApplication
{
    public class response_system
    {
        public response_system()
        {
            

            // Initialize the chatbot name

            string chatbot = "Chatbot";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("+-----------------------------------------------------------------------------------+\r\n| ____   ____   ____   ____   ____   ____   ____   ____   ____   ____   ____   ____ |\r\n|)____( )____( )____( )____( )____( )____( )____( )____( )____( )____( )____( )____(|\r\n+-----------------------------------------------------------------------------------+");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Magenta;
            // Prompt user for their name
            Console.WriteLine($"{chatbot}:Please enter your name:");
            string name = Console.ReadLine();
            Console.ResetColor();

            Console.WriteLine($"{chatbot}: Welcome to the chatbot, {name}!");
           //For spacing
            Console.WriteLine("          ");
            
            // Initialize the ArrayList with questions and answers
            ArrayList chatbotResponses = new ArrayList()
            {
                new string[] { "phishing",$"Phishing is a form of online fraud in which hackers attempt to get your private information such as passwords, credit cards, or bank account data." },
                new string[] { "password",$"Use strong, unique passwords for each account. A password manager can help generate and store them securely." },
                new string[] { "safe browsing",$"Always check for HTTPS, avoid suspicious websites, and never download files from unknown sources." },
                new string[] { "how are you",$"I'm good, thank you for asking {name}!" },
                new string[] { "who are you",$"I am a cybersecurity chatbot here to help you stay safe online. Ask me about phishing, passwords, or browsing security!" },
                new string[] { "how can i prevent phishing",$"Keep informed about phishing techniques." },
                new string[] { "how can i further strengthen my browsing experience",$"Use a quick, minimal browser." },
                new string[] { "how often should i change my passwords",$"Use strong, unique passwords." },
                new string[] { "can i use the same password for multiple accounts",$"Reusing the same password for multiple accounts makes you vulnerable to cyber attacks." },
                new string[] { "how can i securely store my passwords",$"Password manager applications offer an excellent alternative to using your browser's password storage." },
                new string[] { "what is two-factor authentication",$"Two-factor authentication adds an extra layer of security." },
                new string[] { "how can i avoid malware when downloading files",$"Install and update antivirus software." },
                new string[] { "what's the difference between http and https",$"Well {name} HTTPS is just HTTP with encryption one is secure and the other one is'nt." },
                new string[] { "can i trust public wi-fi networks",$"Many public Wi-Fi hotspots are unencrypted so no." },
                new string[] { "how do i know if a website is legitimate",$"Well what you can do {name} is use a website legitimacy checker in any browser." },
                new string[] { "can browser extensions compromise my security",$"Yes {name} they can, malicious or bad add-ons compromise personal data." },
                new string[] { "how can I spot a fake email",$"Inspect the email header info to verify." },
                new string[] { "what is the goal of phishing attacks",$"Well {name} the whole purpose is gaining unauthorized access to systems and stealing money." },
                new string[] { "can phishing happen through text messages",$" Well {name} when smishing, cybercriminals send harmful links via text message." },
                new string[] { "what should I do with suspicious links",$"Hover over the link itself to see if it’s consistent with the domain." },
                new string[] { "how do phishers get my email address",$"Well {name} Scammers use brute force attacks to generate various alphanumeric combinations." },
                new string[] { "who am i",$"Your name is {name} as you mentioned." },
            };

            // Loop for the chatbot to respond to user input
            while (true)
            { 
                //Used for spacing
                Console.WriteLine("          ");
                
                Console.WriteLine($"{chatbot}:Please ask questions related to the following topics:1 Passwords 2.Safe Browsing 3.Phishing or type in exit to leave the program.");
               //Border acting as section breaker
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+-----------------------------------------------------------------------------------+\r\n| ____   ____   ____   ____   ____   ____   ____   ____   ____   ____   ____   ____ |\r\n|)____( )____( )____( )____( )____( )____( )____( )____( )____( )____( )____( )____(|\r\n+-----------------------------------------------------------------------------------+");
                Console.ResetColor();

                // Capture user input with feedback
                Console.ForegroundColor = ConsoleColor.Green;
                string userResponse = capture_user_response(name);
                Console.ResetColor();

                if (userResponse.ToLower() == "exit")
                {          
                    Console.WriteLine($"{chatbot}:Thank you for using our chatbot{name} have yourself a splendid day! ");
                    break;
                }

                // Used to serach for the responses from users input
                bool found = false;
                foreach (string[] response in chatbotResponses)
                {
                    if (userResponse.ToLower().Contains(response[0].ToLower()))
                    {
                        Console.WriteLine($"{chatbot}: {response[1]}");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{chatbot}:Sorry {name}, I didn't quite get that. Please ask about passwords, phishing, or safe browsing.\U000026A0 ");
                    Console.ResetColor();
                }
            }
        }

        // Method to capture user response with input typing effect
        private string capture_user_response(string name)
        {
            string input = "";
            ConsoleKeyInfo key;
            Console.Write($" {name}: ");
            do
            {
                key = Console.ReadKey(intercept: true);  // Read key without displaying it
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);  // Handle backspace
                    Console.Write("\b \b");  // Erase last character on screen
                }
                else if (key.Key != ConsoleKey.Enter)  // Don't add Enter key to input
                {
                    input += key.KeyChar;  // Add typed character to input
                    Console.Write(key.KeyChar);  // Display character on screen
                }
            } while (key.Key != ConsoleKey.Enter);  // Stop when Enter key is pressed

            Console.WriteLine();  // Move to the next line after the user presses Enter
            return input;
        }
    }
}


