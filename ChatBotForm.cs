using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityBot
{
    public partial class ChatBotForm : Form
    {
        private Greeting greeting;
        private ResponseEngine responseEngine;
        private Random random;
        private Dictionary<string, string> userMemory;
        private string currentTopic;
        private string userName;
        private Image botImage;
        private Image userImage;

        public ChatBotForm()
        {
            InitializeComponent();
            LoadImages();
            InitializeChatBot();
        }

        private void LoadImages()
        {
            string botPath = Application.StartupPath + "\\bot.jpg";
            string userPath = Application.StartupPath + "\\user.jpg";

            try
            {
                if (System.IO.File.Exists(botPath))
                    botImage = Image.FromFile(botPath);
                else
                    botImage = null;
            }
            catch { botImage = null; }

            try
            {
                if (System.IO.File.Exists(userPath))
                    userImage = Image.FromFile(userPath);
                else
                    userImage = null;
            }
            catch { userImage = null; }
        }

        private void InitializeChatBot()
        {
            greeting = new Greeting();
            responseEngine = new ResponseEngine();
            random = new Random();
            userMemory = new Dictionary<string, string>();
            currentTopic = "";
            userName = "";

            // Play voice greeting
            try
            {
                VoiceGreeting.PlayGreeting("greeting.wav");
            }
            catch { }

            // Display ASCII art
            txtAsciiArt.Text = AsciiArt.GetLogo();
            txtAsciiArt.Font = new Font("Consolas", 8);

            // Initial messages
            AppendBotMessage(greeting.GetInitialGreeting());

            // Add keyboard event
            txtUserInput.KeyPress += txtUserInput_KeyPress;
        }

        private string GetTimestamp()
        {
            return DateTime.Now.ToString("HH:mm");
        }

        private void AppendBotMessage(string message)
        {
            Panel msgPanel = new Panel();
            msgPanel.AutoSize = true;
            msgPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            msgPanel.Margin = new Padding(5);
            msgPanel.BackColor = Color.FromArgb(240, 240, 240);
            msgPanel.Width = flowChat.Width - 20;

            PictureBox avatar = new PictureBox();
            avatar.Size = new Size(35, 35);
            avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            if (botImage != null) avatar.Image = botImage;
            avatar.Location = new Point(5, 5);
            avatar.BackColor = Color.FromArgb(225, 225, 225);

            Panel bubblePanel = new Panel();
            bubblePanel.AutoSize = true;
            bubblePanel.BackColor = Color.FromArgb(225, 225, 225);
            bubblePanel.Location = new Point(45, 0);

            Label lblTimestamp = new Label();
            lblTimestamp.Text = "Bot " + GetTimestamp();
            lblTimestamp.Font = new Font("Segoe UI", 7, FontStyle.Italic);
            lblTimestamp.ForeColor = Color.Gray;
            lblTimestamp.AutoSize = true;
            lblTimestamp.Location = new Point(10, 5);

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblMessage.ForeColor = Color.Black;
            lblMessage.BackColor = Color.FromArgb(225, 225, 225);
            lblMessage.AutoSize = true;
            lblMessage.MaximumSize = new Size(500, 0);
            lblMessage.Location = new Point(10, 25);

            bubblePanel.Controls.Add(lblTimestamp);
            bubblePanel.Controls.Add(lblMessage);
            bubblePanel.Height = lblMessage.Bottom + 10;
            bubblePanel.Width = Math.Max(lblTimestamp.Width, lblMessage.Width) + 20;

            msgPanel.Controls.Add(avatar);
            msgPanel.Controls.Add(bubblePanel);

            flowChat.Controls.Add(msgPanel);
            flowChat.ScrollControlIntoView(msgPanel);
        }

        private void AppendUserMessage(string message)
        {
            Panel msgPanel = new Panel();
            msgPanel.AutoSize = true;
            msgPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            msgPanel.Margin = new Padding(5);
            msgPanel.BackColor = Color.FromArgb(240, 240, 240);
            msgPanel.Width = flowChat.Width - 20;

            Panel bubblePanel = new Panel();
            bubblePanel.AutoSize = true;
            bubblePanel.BackColor = Color.FromArgb(0, 132, 255);

            Label lblTimestamp = new Label();
            lblTimestamp.Text = GetTimestamp();
            lblTimestamp.Font = new Font("Segoe UI", 7, FontStyle.Italic);
            lblTimestamp.ForeColor = Color.LightGray;
            lblTimestamp.AutoSize = true;
            lblTimestamp.Location = new Point(10, 5);

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblMessage.ForeColor = Color.White;
            lblMessage.BackColor = Color.FromArgb(0, 132, 255);
            lblMessage.AutoSize = true;
            lblMessage.MaximumSize = new Size(500, 0);
            lblMessage.Location = new Point(10, 25);

            bubblePanel.Controls.Add(lblTimestamp);
            bubblePanel.Controls.Add(lblMessage);
            bubblePanel.Height = lblMessage.Bottom + 10;
            bubblePanel.Width = Math.Max(lblTimestamp.Width, lblMessage.Width) + 20;
            bubblePanel.Location = new Point(msgPanel.Width - bubblePanel.Width - 45, 0);

            PictureBox avatar = new PictureBox();
            avatar.Size = new Size(35, 35);
            avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            if (userImage != null) avatar.Image = userImage;
            avatar.Location = new Point(msgPanel.Width - 40, 5);
            avatar.BackColor = Color.FromArgb(0, 132, 255);

            msgPanel.Controls.Add(bubblePanel);
            msgPanel.Controls.Add(avatar);

            flowChat.Controls.Add(msgPanel);
            flowChat.ScrollControlIntoView(msgPanel);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                AppendBotMessage("I didn't quite understand that. Could you rephrase?");
                return;
            }

            AppendUserMessage(userInput);
            ProcessUserInput(userInput);
            txtUserInput.Clear();
            txtUserInput.Focus();
        }

        private void ProcessUserInput(string input)
        {
            string lowerInput = input.ToLower();

            // Get user name first
            if (string.IsNullOrEmpty(userName))
            {
                if (greeting.SetUserName(input))
                {
                    userName = greeting.UserName;
                    userMemory["Name"] = userName;
                    AppendBotMessage(greeting.GetWelcomeMessage());
                }
                else
                {
                    AppendBotMessage("I didn't quite understand that. Could you rephrase?");
                }
                return;
            }

            // Exit
            if (greeting.ShouldExit(input))
            {
                AppendBotMessage("Thank you for chatting with me, " + userName + "! Stay safe online. Goodbye!");
                return;
            }

            // Help
            if (lowerInput == "help" || lowerInput.Contains("what can i ask"))
            {
                AppendBotMessage(responseEngine.GetHelpMessage(userName));
                return;
            }

            // Memory recall
            if (lowerInput.Contains("remember") || lowerInput.Contains("what do you know"))
            {
                RecallUserInfo();
                return;
            }

            // Follow-up
            if (IsFollowUpRequest(lowerInput))
            {
                HandleFollowUp();
                return;
            }

            // Sentiment detection
            string sentiment = DetectSentiment(lowerInput);

            // Keyword responses
            string response = GetKeywordResponse(lowerInput, sentiment);

            if (response == null)
            {
                response = responseEngine.GetResponse(input, userName);
            }

            AppendBotMessage(response);
            StoreCurrentTopic(lowerInput);
        }

        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous") || input.Contains("anxious"))
                return "worried";

            if (input.Contains("frustrated") || input.Contains("confused") || input.Contains("annoying"))
                return "frustrated";

            if (input.Contains("curious") || input.Contains("interested") || input.Contains("want to know"))
                return "curious";

            return "neutral";
        }

        private string GetKeywordResponse(string input, string sentiment)
        {
            // Password keyword
            if (input.Contains("password") || input.Contains("passcode"))
            {
                string[] tips = {
                    "Use at least 12 characters with uppercase, lowercase, numbers and symbols.",
                    "Never reuse passwords across different accounts.",
                    "Consider using a password manager to store strong passwords.",
                    "Enable two-factor authentication whenever possible.",
                    "Avoid using personal information like birthdays or names in passwords."
                };
                string tip = tips[random.Next(tips.Length)];

                if (sentiment == "worried")
                    return "Don't worry. " + tip + " I can give you more tips if you like.";
                else if (sentiment == "curious")
                    return "Good question about passwords. " + tip;

                return tip;
            }

            // Scam / Phishing keyword
            if (input.Contains("scam") || input.Contains("phish") || input.Contains("fraud"))
            {
                string[] tips = {
                    "Never click links in unexpected emails. Check the sender's email address carefully.",
                    "Scammers create urgency. If someone demands immediate action, it's likely a scam.",
                    "Legitimate companies never ask for your password via email.",
                    "Look for spelling errors and generic greetings like 'Dear Customer' - these are scam signs.",
                    "Report suspicious emails to your email provider."
                };
                string tip = tips[random.Next(tips.Length)];

                if (sentiment == "worried")
                    return "It's normal to be concerned. " + tip;

                return tip;
            }

            // Privacy keyword
            if (input.Contains("privacy") || input.Contains("private"))
            {
                string[] tips = {
                    "Review your social media privacy settings monthly.",
                    "Use a VPN on public WiFi to encrypt your data.",
                    "Regularly check which apps have access to your accounts.",
                    "Cover your webcam when not in use.",
                    "Use different email addresses for different services."
                };
                string tip = tips[random.Next(tips.Length)];

                userMemory["Interest"] = "privacy";
                return tip + " I will remember you are interested in privacy.";
            }

            // 2FA keyword
            if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("two-factor"))
            {
                return "Two-factor authentication adds an extra security layer. Always enable it when available.";
            }

            // Safe browsing
            if (input.Contains("browsing") || input.Contains("browse") || input.Contains("internet"))
            {
                return "Always use HTTPS websites, keep your browser updated, and avoid public WiFi for sensitive transactions.";
            }

            return null;
        }

        private bool IsFollowUpRequest(string input)
        {
            string[] triggers = { "another tip", "tell me more", "explain more", "more", "another", "continue" };
            foreach (string trigger in triggers)
            {
                if (input.Contains(trigger))
                    return true;
            }
            return false;
        }

        private void HandleFollowUp()
        {
            if (currentTopic == "password")
            {
                string[] tips = {
                    "Use a passphrase with random words like correct-horse-battery-staple.",
                    "Change passwords immediately if you suspect a breach.",
                    "Don't store passwords in plain text files or sticky notes."
                };
                AppendBotMessage(tips[random.Next(tips.Length)]);
            }
            else if (currentTopic == "scam")
            {
                string[] tips = {
                    "Report phishing emails to your email provider.",
                    "Don't call phone numbers from suspicious emails. Look up official numbers instead.",
                    "Scammers often pretend to be from tech support or banks."
                };
                AppendBotMessage(tips[random.Next(tips.Length)]);
            }
            else if (currentTopic == "privacy")
            {
                string[] tips = {
                    "Use different email addresses for different services.",
                    "Turn off location tracking for apps that don't need it.",
                    "Regularly clear your browser cookies and cache."
                };
                AppendBotMessage(tips[random.Next(tips.Length)]);
            }
            else
            {
                AppendBotMessage("What topic would you like more tips on? Try password, scam, or privacy.");
            }
        }

        private void StoreCurrentTopic(string input)
        {
            if (input.Contains("password"))
                currentTopic = "password";
            else if (input.Contains("scam") || input.Contains("phish"))
                currentTopic = "scam";
            else if (input.Contains("privacy"))
                currentTopic = "privacy";
        }

        private void RecallUserInfo()
        {
            if (userMemory.Count == 0)
            {
                AppendBotMessage("I don't know much about you yet. Tell me your interests.");
                return;
            }

            string message = "Here is what I remember about you:";
            foreach (var item in userMemory)
            {
                message = message + Environment.NewLine + "- " + item.Key + ": " + item.Value;
            }

            if (userMemory.ContainsKey("Interest"))
            {
                message = message + Environment.NewLine + "Since you like " + userMemory["Interest"] + ", focus on privacy settings.";
            }

            AppendBotMessage(message);
        }

        private void txtUserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSend_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}