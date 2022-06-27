namespace CouInjector_Auto_Update
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.poisonLabel = new ReaLTaiizor.Controls.PoisonLabel();
            this.aloneProgressBar1 = new ReaLTaiizor.Controls.AloneProgressBar();
            this.poisonButton = new ReaLTaiizor.Controls.PoisonButton();
            this.SuspendLayout();
            // 
            // poisonLabel
            // 
            this.poisonLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.poisonLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.poisonLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.poisonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.poisonLabel.Location = new System.Drawing.Point(23, 142);
            this.poisonLabel.Margin = new System.Windows.Forms.Padding(3);
            this.poisonLabel.Name = "poisonLabel";
            this.poisonLabel.Size = new System.Drawing.Size(350, 24);
            this.poisonLabel.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Yellow;
            this.poisonLabel.TabIndex = 60;
            this.poisonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.poisonLabel.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            this.poisonLabel.UseStyleColors = true;
            // 
            // aloneProgressBar1
            // 
            this.aloneProgressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.aloneProgressBar1.BackgroundColor = System.Drawing.Color.Green;
            this.aloneProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(13)))));
            this.aloneProgressBar1.Location = new System.Drawing.Point(23, 63);
            this.aloneProgressBar1.Maximum = 100;
            this.aloneProgressBar1.Minimum = 0;
            this.aloneProgressBar1.Name = "aloneProgressBar1";
            this.aloneProgressBar1.Size = new System.Drawing.Size(350, 23);
            this.aloneProgressBar1.Stripes = System.Drawing.Color.DarkGreen;
            this.aloneProgressBar1.TabIndex = 63;
            this.aloneProgressBar1.Text = "aloneProgressBar1";
            this.aloneProgressBar1.Value = 0;
            // 
            // poisonButton
            // 
            this.poisonButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.poisonButton.Highlight = true;
            this.poisonButton.Location = new System.Drawing.Point(23, 112);
            this.poisonButton.Name = "poisonButton";
            this.poisonButton.Size = new System.Drawing.Size(350, 24);
            this.poisonButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Yellow;
            this.poisonButton.TabIndex = 64;
            this.poisonButton.Text = "Update CouInjector";
            this.poisonButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            this.poisonButton.UseSelectable = true;
            this.poisonButton.Click += new System.EventHandler(this.poisonButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 174);
            this.Controls.Add(this.poisonButton);
            this.Controls.Add(this.aloneProgressBar1);
            this.Controls.Add(this.poisonLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.ShadowType = ReaLTaiizor.Enum.Poison.FormShadowType.AeroShadow;
            this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Yellow;
            this.Text = "CouInjector-Auto-Updater";
            this.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Dark;
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.PoisonLabel poisonLabel;
        private ReaLTaiizor.Controls.AloneProgressBar aloneProgressBar1;
        private ReaLTaiizor.Controls.PoisonButton poisonButton;
    }
}