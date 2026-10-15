using System;

namespace CybersecurityBot
{
    public class Greeting
    {
        public string ChatBotName { get; set; }
        public string UserName { get; set; }

        public Greeting()
        {
            ChatBotName = "CybersecurityBot";
            UserName = "";
        }

        public bool SetUserName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            UserName = name.Trim();
            return true;
        }

        public string GetInitialGreeting()
        {
            return "Hello! Welcome to the Cybersecurity Awareness Bot.\n\n" +
                   "I am here to help you stay safe online.\n\n" +
                   "May I ask what your name is?";
        }

        public string GetWelcomeMessage()
        {
            return "Nice to meet you, " + UserName + "!\n\n" +
                   "I can help you with:\n" +
                   "- Password safety\n" +
                   "- Phishing detection\n" +
                   "- Safe browsing practices\n" +
                   "- General cybersecurity tips\n\n" +
                   "Type 'help' to see all commands or 'bye' to exit.";
        }

        public bool ShouldExit(string input)
        {
            string lower = input.ToLower();
            return lower == "bye" || lower == "exit" || lower == "quit" || lower == "goodbye";
        }
    }
}