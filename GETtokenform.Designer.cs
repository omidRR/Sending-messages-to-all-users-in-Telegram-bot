namespace REXBOT
{
    partial class GETtokenform
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
        [System.Obsolete]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GETtokenform));
            this.tokentxt = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // tokentxt
            // 
            this.tokentxt.AnimateReadOnly = false;
            this.tokentxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tokentxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tokentxt.Depth = 0;
            this.tokentxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tokentxt.HideSelection = true;
            this.tokentxt.Hint = "Enter token here";
            this.tokentxt.LeadingIcon = null;
            this.tokentxt.Location = new System.Drawing.Point(6, 77);
            this.tokentxt.MaxLength = 32767;
            this.tokentxt.MouseState = MaterialSkin.MouseState.OUT;
            this.tokentxt.Name = "tokentxt";
            this.tokentxt.PasswordChar = '\0';
            this.tokentxt.PrefixSuffixText = "Enter token here";
            this.tokentxt.ReadOnly = false;
            this.tokentxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tokentxt.SelectedText = "";
            this.tokentxt.SelectionLength = 0;
            this.tokentxt.SelectionStart = 0;
            this.tokentxt.ShortcutsEnabled = true;
            this.tokentxt.Size = new System.Drawing.Size(497, 48);
            this.tokentxt.TabIndex = 0;
            this.tokentxt.TabStop = false;
            this.tokentxt.Tag = "Enter token here";
            this.tokentxt.Text = "5068289754:AAHfloxnIuQgGQYxtHy33t11VrVTnQggE-0";
            this.tokentxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tokentxt.TrailingIcon = null;
            this.tokentxt.UseSystemPasswordChar = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(198, 144);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(118, 36);
            this.materialButton1.TabIndex = 1;
            this.materialButton1.Text = "Enter Token";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // GETtokenform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(514, 189);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.tokentxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GETtokenform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GETtokenform";
            this.Load += new System.EventHandler(this.GETtokenform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 tokentxt;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}