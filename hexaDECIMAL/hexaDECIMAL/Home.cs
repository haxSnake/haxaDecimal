using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hexaDECIMAL.UserControlPanel
{
    public partial class Home : UserControl
    {
        private MySqlDataReader mdr;
        private MySqlCommand cmd;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label4;
        User user = new User();

        public Home()
        {
            InitializeComponent();
            UsrDetails();

        }

        public void UsrDetails()
        {
            try
            {
                user.dbCon.Open(); // open db connection

                // creating cmd using MySql and conn
                MySqlCommand cmd = user.dbCon.CreateCommand();
                cmd.CommandText = "select * from user, account";
                mdr = cmd.ExecuteReader(); // Reading string from database into the reader

                // getting data from db and display
                if (mdr.Read())
                {
                    label4.Text = mdr.GetString("firstName") + " " + mdr.GetString("lastName");
                
                    // getting data from db and display
                    label5.Text = mdr.GetString("balance".ToString());
                }
            }

            catch (Exception ex)
            {
                // error catch 
                //  LeagueTabListView.ResetText();

                string erMsg = string.Format("Error during reading data from database:\n{0}", ex.Message); // error message
                MessageBox.Show(erMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // error box display
            }
            finally
            {
                user.dbCon.Close();
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ravie", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(472, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(524, 45);
            this.label3.TabIndex = 13;
            this.label3.Text = "The Money Saving App";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ravie", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1058, 155);
            this.label2.TabIndex = 12;
            this.label2.Text = "haxaDecimal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 70F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(962, 155);
            this.label1.TabIndex = 11;
            this.label1.Text = "Welcome to";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(624, 710);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 39);
            this.label5.TabIndex = 10;
            this.label5.Text = "Your Balance";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(680, 617);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            // 
            // Home
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(154)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(1468, 837);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
