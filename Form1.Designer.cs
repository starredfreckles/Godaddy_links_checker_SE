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
            this.AvailableResultsTextBox = new System.Windows.Forms.TextBox();
            this.UnavailableResultsTextBox = new System.Windows.Forms.TextBox();
            this.CheckUrlsButton = new System.Windows.Forms.Button();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AvailableResultsTextBox
            // 
            this.AvailableResultsTextBox.Location = new System.Drawing.Point(12, 41);
            this.AvailableResultsTextBox.Multiline = true;
            this.AvailableResultsTextBox.Name = "AvailableResultsTextBox";
            this.AvailableResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AvailableResultsTextBox.Size = new System.Drawing.Size(300, 400);
            this.AvailableResultsTextBox.TabIndex = 0;
            // 
            // UnavailableResultsTextBox
            // 
            this.UnavailableResultsTextBox.Location = new System.Drawing.Point(318, 41);
            this.UnavailableResultsTextBox.Multiline = true;
            this.UnavailableResultsTextBox.Name = "UnavailableResultsTextBox";
            this.UnavailableResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UnavailableResultsTextBox.Size = new System.Drawing.Size(300, 400);
            this.UnavailableResultsTextBox.TabIndex = 1;
            // 
            // CheckUrlsButton
            // 
            this.CheckUrlsButton.Location = new System.Drawing.Point(12, 447);
            this.CheckUrlsButton.Name = "CheckUrlsButton";
            this.CheckUrlsButton.Size = new System.Drawing.Size(606, 23);
            this.CheckUrlsButton.TabIndex = 2;
            this.CheckUrlsButton.Text = "Check URLs";
            this.CheckUrlsButton.UseVisualStyleBackColor = true;
            this.CheckUrlsButton.Click += new System.EventHandler(this.CheckUrlsButton_Click);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(50, 12);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(568, 20);
            this.UrlTextBox.TabIndex = 3;
            this.UrlTextBox.Text = "https://www.godaddy.com/pricing";
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Location = new System.Drawing.Point(12, 15);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(32, 13);
            this.UrlLabel.TabIndex = 4;
            this.UrlLabel.Text = "URL:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 482);
            this.Controls.Add(this.UrlLabel);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.CheckUrlsButton);
            this.Controls.Add(this.UnavailableResultsTextBox);
            this.Controls.Add(this.AvailableResultsTextBox);
            this.Name = "Form1";
            this.Text = "GoDaddy Links Checker";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}