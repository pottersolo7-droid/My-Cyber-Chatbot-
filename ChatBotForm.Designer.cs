using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CybersecurityBot
{
    partial class ChatBotForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAsciiArt = new System.Windows.Forms.TextBox();
            this.pnlChatContainer = new System.Windows.Forms.Panel();
            this.flowChat = new System.Windows.Forms.FlowLayoutPanel();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlChatContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAsciiArt
            // 
            this.txtAsciiArt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsciiArt.BackColor = System.Drawing.Color.Black;
            this.txtAsciiArt.Font = new System.Drawing.Font("Consolas", 8F);
            this.txtAsciiArt.ForeColor = System.Drawing.Color.Magenta;
            this.txtAsciiArt.Location = new System.Drawing.Point(10, 10);
            this.txtAsciiArt.Multiline = true;
            this.txtAsciiArt.Name = "txtAsciiArt";
            this.txtAsciiArt.ReadOnly = true;
            this.txtAsciiArt.Size = new System.Drawing.Size(652, 199);
            this.txtAsciiArt.TabIndex = 0;
            // 
            // pnlChatContainer
            // 
            this.pnlChatContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChatContainer.AutoScroll = true;
            this.pnlChatContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlChatContainer.Controls.Add(this.flowChat);
            this.pnlChatContainer.Location = new System.Drawing.Point(10, 215);
            this.pnlChatContainer.Name = "pnlChatContainer";
            this.pnlChatContainer.Size = new System.Drawing.Size(651, 97);
            this.pnlChatContainer.TabIndex = 1;
            // 
            // flowChat
            // 
            this.flowChat.AutoSize = true;
            this.flowChat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.flowChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowChat.Location = new System.Drawing.Point(0, 0);
            this.flowChat.Name = "flowChat";
            this.flowChat.Size = new System.Drawing.Size(0, 0);
            this.flowChat.TabIndex = 0;
            this.flowChat.WrapContents = false;
            // 
            // txtUserInput
            // 
            this.txtUserInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUserInput.Location = new System.Drawing.Point(10, 321);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(541, 25);
            this.txtUserInput.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(557, 319);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(105, 26);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            // 
            // ChatBotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(686, 364);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.pnlChatContainer);
            this.Controls.Add(this.txtAsciiArt);
            this.Name = "ChatBotForm";
            this.Text = "Cybersecurity Awareness Bot";
            this.pnlChatContainer.ResumeLayout(false);
            this.pnlChatContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox txtAsciiArt;
        private Panel pnlChatContainer;
        private FlowLayoutPanel flowChat;
        private TextBox txtUserInput;
        private Button btnSend;
    }
}