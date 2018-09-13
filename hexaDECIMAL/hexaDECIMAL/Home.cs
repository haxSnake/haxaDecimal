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
                cmd.CommandText = "select * from user";
                mdr = cmd.ExecuteReader(); // Reading string from database into the reader

                // getting data from db and display

                label4.Text = mdr.GetString("firstName") + " " + mdr.GetString("lastName");
                

                cmd.CommandText = "select * from account";
                mdr = cmd.ExecuteReader(); // Reading string from database into the reader

                // getting data from db and display
                label5.Text = mdr.GetString("balance".ToString());

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
    }
}
