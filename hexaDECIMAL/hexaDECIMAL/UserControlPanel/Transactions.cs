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
    public partial class Transactions : UserControl
    {
        private MySqlDataReader mdr;
        private MySqlCommand cmd;

        Transaction dbtra = new Transaction();

        public Transactions()
        {
            InitializeComponent();

            TransactionTable(); // instert to list view transaction table data
        }

        // reading content from databse and adding it to list view
        public void TransactionTable()
        {

            try
            {

                dbtra.dbCon.Open(); // open connection to db

                // creating cmd using MySql and conn
                cmd = dbtra.dbCon.CreateCommand();

                cmd.CommandText = "select * from transaction order by transactionId ASC";

                mdr = cmd.ExecuteReader(); // Reading string from database into the reader

                // if the query runssuccessfuly then the value of rows will be greater then 0 else will equal 0

                while (mdr.Read())
                {
                    //CREATE OBJECT FOR THE LISTVIEW
                    ListViewItem item = new ListViewItem(mdr.GetString("transactionDate"));
                    item.SubItems.Add(mdr.GetString("TransactionType"));
                    item.SubItems.Add(mdr.GetString("transactionForeignAccount"));
                    item.SubItems.Add(mdr.GetString("value"));
                    
                    //PUT INFORMATION IN LISTVIEW
                    listView1.Items.Add(item);
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
                dbtra.dbCon.Close(); // close connection
            }

        }

    }
}
