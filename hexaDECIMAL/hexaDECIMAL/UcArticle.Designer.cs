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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMySQL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btnMySQL
            // 
            this.btnMySQL.Location = new System.Drawing.Point(61, 71);
            this.btnMySQL.Name = "btnMySQL";
            this.btnMySQL.Size = new System.Drawing.Size(75, 23);
            this.btnMySQL.TabIndex = 1;
            this.btnMySQL.Text = "button1";
            this.btnMySQL.UseVisualStyleBackColor = true;
            this.btnMySQL.Click += new System.EventHandler(this.btnMySQL_Click);
            // 
            // UcArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(154)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.btnMySQL);
            this.Controls.Add(this.label1);
            this.Name = "UcArticle";
            this.Size = new System.Drawing.Size(1468, 837);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMySQL;
    }
}
