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

namespace hexaDECIMAL
{
    public partial class UserAccUpdate : UserControl
    {
        public UserAccUpdate()
        {
            InitializeComponent();
        }

        public String query;
        //public String userId;



        private void button1_Click(object sender, EventArgs e)
        {
            //OPEN MYSQL CONNECTION
            using (MySqlConnection con = new MySqlConnection(databaseOperations.mysqlDatasource))
            {
                con.Open();
                




                //UPDATE DATA IN USER TABLE
                if (textBoxEmail.Text != null)
                {
                    query = "UPDATE user SET email = @email WHERE userId = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@email", textBoxEmail.Text));
                        cmd.Parameters.Add(new MySqlParameter("@userId", Form1.userId));
                    }
                }
                if (textBoxCity.Text != null)
                {
                    query = "UPDATE user SET city = @city WHERE userId = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@city", textBoxCity.Text));
                        cmd.Parameters.Add(new MySqlParameter("@userId", Form1.userId));
                    }
                }
                if (textBoxStreet.Text != null)
                {
                    query = "UPDATE user SET street = @street WHERE userId = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@street", textBoxStreet.Text));
                        cmd.Parameters.Add(new MySqlParameter("@userId", Form1.userId));
                    }
                }
                if (textBoxPW.Text != null)
                {
                    query = "UPDATE user SET pw = @pw WHERE userId = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@pw", textBoxPW.Text));
                        cmd.Parameters.Add(new MySqlParameter("@userId", Form1.userId));
                    }
                }
                if (textBoxPC.Text != null)
                {
                    query = "UPDATE user SET postcode = @pc WHERE userId = @userId";

                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@pc", textBoxPC.Text));
                        cmd.Parameters.Add(new MySqlParameter("@userId", Form1.userId));
                    }
                }
            }
        }
    }
}