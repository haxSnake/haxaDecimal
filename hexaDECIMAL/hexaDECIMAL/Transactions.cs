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
        private ListView listView1;
        private ColumnHeader column;
        private ColumnHeader ColumnHeader;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
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
                    if (mdr.GetInt32("TransactionType") == 1)
                    {
                        item.SubItems.Add("Deposit");
                    }
                    else
                    {
                        item.SubItems.Add("Withdraw");
                    }
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

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(154)))), ((int)(((byte)(70)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column,
            this.ColumnHeader,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1468, 837);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column
            // 
            this.column.Text = "Date";
            this.column.Width = 200;
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Text = "Type";
            this.ColumnHeader.Width = 368;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 600;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Amount";
            this.columnHeader4.Width = 300;
            // 
            // Transactions
            // 
            this.Controls.Add(this.listView1);
            this.Name = "Transactions";
            this.Size = new System.Drawing.Size(1468, 837);
            this.ResumeLayout(false);

        }
    }
}
