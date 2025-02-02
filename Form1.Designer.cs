﻿using System.Resources;

namespace Godaddy_links_checker_SE
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox AvailableResultsTextBox;
        private System.Windows.Forms.TextBox UnavailableResultsTextBox;
        private System.Windows.Forms.Button CheckUrlsButton;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label UrlLabel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            AvailableResultsTextBox = new TextBox();
            UnavailableResultsTextBox = new TextBox();
            CheckUrlsButton = new Button();
            UrlTextBox = new TextBox();
            UrlLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            AvailMarketList = new TextBox();
            NonAvailMarketList = new TextBox();
            SuspendLayout();
            // 
            // AvailableResultsTextBox
            // 
            AvailableResultsTextBox.Location = new Point(14, 80);
            AvailableResultsTextBox.Margin = new Padding(4, 3, 4, 3);
            AvailableResultsTextBox.Multiline = true;
            AvailableResultsTextBox.Name = "AvailableResultsTextBox";
            AvailableResultsTextBox.ScrollBars = ScrollBars.Vertical;
            AvailableResultsTextBox.Size = new Size(349, 330);
            AvailableResultsTextBox.TabIndex = 0;
            // 
            // UnavailableResultsTextBox
            // 
            UnavailableResultsTextBox.Location = new Point(371, 80);
            UnavailableResultsTextBox.Margin = new Padding(4, 3, 4, 3);
            UnavailableResultsTextBox.Multiline = true;
            UnavailableResultsTextBox.Name = "UnavailableResultsTextBox";
            UnavailableResultsTextBox.ScrollBars = ScrollBars.Vertical;
            UnavailableResultsTextBox.Size = new Size(349, 330);
            UnavailableResultsTextBox.TabIndex = 1;
            // 
            // CheckUrlsButton
            // 
            CheckUrlsButton.Location = new Point(14, 516);
            CheckUrlsButton.Margin = new Padding(4, 3, 4, 3);
            CheckUrlsButton.Name = "CheckUrlsButton";
            CheckUrlsButton.Size = new Size(707, 27);
            CheckUrlsButton.TabIndex = 2;
            CheckUrlsButton.Text = "Check Availability";
            CheckUrlsButton.UseVisualStyleBackColor = true;
            CheckUrlsButton.Click += CheckUrlsButton_Click;
            // 
            // UrlTextBox
            // 
            UrlTextBox.Location = new Point(58, 14);
            UrlTextBox.Margin = new Padding(4, 3, 4, 3);
            UrlTextBox.Name = "UrlTextBox";
            UrlTextBox.Size = new Size(662, 23);
            UrlTextBox.TabIndex = 3;
            UrlTextBox.Text = "https://www.godaddy.com/pricing";
            // 
            // UrlLabel
            // 
            UrlLabel.AutoSize = true;
            UrlLabel.Location = new Point(14, 17);
            UrlLabel.Margin = new Padding(4, 0, 4, 0);
            UrlLabel.Name = "UrlLabel";
            UrlLabel.Size = new Size(31, 15);
            UrlLabel.TabIndex = 4;
            UrlLabel.Text = "URL:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Location = new Point(14, 62);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(346, 15);
            label1.TabIndex = 5;
            label1.Text = "                                    Available Markets                                              ";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLight;
            label2.Location = new Point(371, 62);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(347, 15);
            label2.TabIndex = 6;
            label2.Text = "                                   Unavailable Markets                                           ";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // AvailMarketList
            // 
            AvailMarketList.Location = new Point(14, 416);
            AvailMarketList.Margin = new Padding(4, 3, 4, 3);
            AvailMarketList.Multiline = true;
            AvailMarketList.Name = "AvailMarketList";
            AvailMarketList.ScrollBars = ScrollBars.Vertical;
            AvailMarketList.Size = new Size(349, 82);
            AvailMarketList.TabIndex = 7;
            // 
            // NonAvailMarketList
            // 
            NonAvailMarketList.Location = new Point(369, 416);
            NonAvailMarketList.Margin = new Padding(4, 3, 4, 3);
            NonAvailMarketList.Multiline = true;
            NonAvailMarketList.Name = "NonAvailMarketList";
            NonAvailMarketList.ScrollBars = ScrollBars.Vertical;
            NonAvailMarketList.Size = new Size(349, 82);
            NonAvailMarketList.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 556);
            Controls.Add(NonAvailMarketList);
            Controls.Add(AvailMarketList);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(UrlLabel);
            Controls.Add(UrlTextBox);
            Controls.Add(CheckUrlsButton);
            Controls.Add(UnavailableResultsTextBox);
            Controls.Add(AvailableResultsTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "GoDaddy Feature Availability Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private TextBox AvailMarketList;
        private TextBox NonAvailMarketList;
    }
}