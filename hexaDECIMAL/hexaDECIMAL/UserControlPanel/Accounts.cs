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
    public partial class Accounts : UserControl
    {
        private MySqlDataReader mdr;
        private MySqlCommand cmd;

        Account dbCon = new Account();

        public Accounts()
        {
            InitializeComponent();
            Acc();
        }

        // user login
        public void Acc()
        {

            try
            {
                dbCon.dbCon.Open(); // open db connection

                // creating cmd using MySql and conn
                MySqlCommand cmd = dbCon.dbCon.CreateCommand();
                cmd.CommandText = "select * from account order by accId ASC";
                mdr = cmd.ExecuteReader(); // Reading string from database into the reader

                // geting data from db and display
                if (mdr.Read())
                {
                    label2.Text = mdr.GetString("accountNumber".ToString());
                    label4.Text = mdr.GetString("IBAN");
                    label6.Text = mdr.GetString("sortCode");
                    label8.Text = mdr.GetString("balance".ToString());
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
                dbCon.dbCon.Close();
            }

        }



    }
}
