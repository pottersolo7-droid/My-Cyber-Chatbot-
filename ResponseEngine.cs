using System;
using System.Collections.Generic;

namespace CybersecurityBot
{
    public class ResponseEngine
    {
        private Dictionary<string, string> responses;
        private Random random;

        public ResponseEngine()
        {
            responses = new Dictionary<string, string>();
            random = new Random();

            responses.Add("how are you", "I'm functioning perfectly! Thank you for asking.");
            responses.Add("purpose", "My purpose is to educate and raise awareness about cybersecurity. I provide information about online safety, password security, phishing detection, and safe browsing practices.");
            responses.Add("who are you", "I am the Cybersecurity Awareness Bot! I was created to help educate people about staying safe online.");
            responses.Add("what can you do", "I can help you with password safety, phishing detection, safe browsing, and general cybersecurity tips.");
            responses.Add("malware", "Malware is malicious software designed to harm or exploit your computer. Always keep your antivirus updated.");
            responses.Add("ransomware", "Ransomware encrypts your files and demands payment. Never pay the ransom and always backup your data.");
            responses.Add("vpn", "A VPN encrypts your internet connection and hides your IP address for increased privacy.");
            responses.Add("firewall", "A firewall monitors and controls incoming and outgoing network traffic based on security rules.");
            responses.Add("antivirus", "Antivirus software detects and removes malicious programs. Install reputable software and keep it updated.");
            responses.Add("social engineering", "Social engineering manipulates people into revealing confidential information. Never share passwords with strangers.");
            responses.Add("two factor", "Two-factor authentication adds an extra security layer by requiring a second form of verification.");
            responses.Add("2fa", "Two-factor authentication adds an extra security layer by requiring a second form of verification.");
            responses.Add("data breach", "A data breach occurs when unauthorized individuals access sensitive data. Use strong passwords and enable 2FA.");
            responses.Add("encryption", "Encryption converts data into a code that only authorized parties can decode.");
            responses.Add("identity theft", "Identity theft is when someone uses your personal information to commit fraud. Monitor your accounts regularly.");
        }

        public string GetResponse(string userInput, string userName)
        {
            string input = userInput.Trim().ToLower();

            if (input.Length == 0)
            {
                return "You did not enter anything, " + userName + ". Please type a question.";
            }

            foreach (KeyValuePair<string, string> entry in responses)
            {
                if (input.Contains(entry.Key))
                {
                    return entry.Value.Replace("{name}", userName);
                }
            }

            return "I'm not sure about that, " + userName + ". Ask me about passwords, phishing, malware, or safe browsing.";
        }

        public string GetHelpMessage(string userName)
        {
            return "Here is what I can help you with, " + userName + ":\n\n" +
                   "- Password safety (type 'password tips')\n" +
                   "- Phishing and scams (type 'scam' or 'phishing')\n" +
                   "- Privacy protection (type 'privacy')\n" +
                   "- Two-factor authentication (type '2fa')\n" +
                   "- Malware and ransomware\n" +
                   "- Safe browsing\n" +
                   "- VPN and firewalls\n\n" +
                   "Type 'bye' to exit.";
        }
    }
}