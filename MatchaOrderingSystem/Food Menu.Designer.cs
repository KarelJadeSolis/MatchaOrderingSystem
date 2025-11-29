namespace MatchaOrderingSystem
{
    partial class Food_Menu
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
            this.lblAboutUs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAboutUs
            // 
            this.lblAboutUs.AutoSize = true;
            this.lblAboutUs.Location = new System.Drawing.Point(318, 161);
            this.lblAboutUs.Name = "lblAboutUs";
            this.lblAboutUs.Size = new System.Drawing.Size(76, 16);
            this.lblAboutUs.TabIndex = 0;
            this.lblAboutUs.Text = "ABOUT US";
            // 
            // Food_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 852);
            this.Controls.Add(this.lblAboutUs);
            this.Name = "Food_Menu";
            this.Text = "Food_Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAboutUs;
    }
}