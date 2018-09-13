namespace hexaDECIMAL
{
    partial class UcArticle
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelText = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.labelText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelText.Location = new System.Drawing.Point(337, 116);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(1039, 674);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Text";
            // 
            // labelDate
            // 
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 15.6F);
            this.labelDate.ForeColor = System.Drawing.SystemColors.Control;
            this.labelDate.Location = new System.Drawing.Point(1169, 32);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(207, 33);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Date";
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 15.6F);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTitle.Location = new System.Drawing.Point(336, 32);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(450, 33);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            // 
            // labelAuthor
            // 
            this.labelAuthor.Font = new System.Drawing.Font("Century Gothic", 15.6F);
            this.labelAuthor.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAuthor.Location = new System.Drawing.Point(809, 32);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(323, 33);
            this.labelAuthor.TabIndex = 4;
            this.labelAuthor.Text = "Author";
            // 
            // UcArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(154)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelText);
            this.Name = "UcArticle";
            this.Size = new System.Drawing.Size(1468, 837);
            this.Load += new System.EventHandler(this.UcArticle_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAuthor;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
    }
}
