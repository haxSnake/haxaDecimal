using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hexaDECIMAL
{
    public partial class Form1 : Form
    {

        //CLASS MEMBERS
        private static MySqlDataReader mdr;
        private bool launch;
        private int loginCheck;
        private int mov;
        private int movX;
        private int movY;
        public static String userId { get; set; }
        private String queryId;

        public Form1()
        {
            InitializeComponent();
            //REMEMBER ME VARIABLES CHECK
            if (Properties.Settings.Default.email != string.Empty)
            {
                if (Properties.Settings.Default.remember == "yes")
                {
                    loginBox.Text = Properties.Settings.Default.email;
                    pswBox.Text = Properties.Settings.Default.password;
                    checkBox1.Checked = true;
                }
                else
                {
                    loginBox.Text = Properties.Settings.Default.email;
                }
            }
            //HIDE PASSWORD
            if (!pswBox.Text.Equals("Password"))
            {
                pswBox.PasswordChar = '*';
            }
        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void pswBox_TextChanged(object sender, EventArgs e)
        {

        }

        //***EMAIL/PASSWORD TEXTBOX LOGIC
        private void loginBox_Enter(object sender, EventArgs e)
        {
            if (launch == false)
            {
                if (loginBox.Text == "Email")
                {
                    loginBox.Text = "";
                }
            }
            else
            {
                launch = false;
            }
        }

        //LOGIN BUTTON
        private void loginButton_Click(object sender, EventArgs e)
        {
            //CONNECTION CHECK WITH OFFLINE MODE PROMPT
            MainMenu mainMenu = new MainMenu();
            databaseOperations.dbConnectionCheck();
            if (!databaseOperations.dbConnectionCheck())
            {
                DialogResult result = MessageBox.Show("Would you like to start the application in offline mode?", "Connection error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    mainMenu.Show();
                    this.Hide();
                    result = DialogResult.None;
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                //LOGIN SET AS FALSE BY DEFAULT
                loginCheck = 0;
                try
                {
                    //OPEN MYSQL CONNECTION
                    using (MySqlConnection con = new MySqlConnection(databaseOperations.mysqlDatasource))
                    {
                        //LOGIN VALIDATION
                        con.Open();
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        string password = pswBox.Text;
                        //password = String.Concat(password.Select(x => ((int)x).ToString("x"))); // this is simple encryption, not needed for testing phase

                        string userCheck = "select * from user where email=@email and pw=@pw";
                        cmd.Parameters.Add(new MySqlParameter("@email", loginBox.Text));
                        cmd.Parameters.Add(new MySqlParameter("@pw", password));
                        cmd.CommandText = userCheck;
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        loginCheck = Convert.ToInt32(dt.Rows.Count.ToString());
                        mdr = cmd.ExecuteReader();

                        if (mdr.Read())
                        {
                            //USER SUBSCRIPTION TYPE
                            //databaseOperations.premiumCheck = mdr.GetBoolean("premium");
                        }

                        if (loginCheck == 0)
                        {
                            label2.Text = "Incorrect email or password!";
                        }

                        else
                        {
                            //REMEMBER USER CREDENTIALS AND GO TO THE MAIN SCREEN
                            Properties.Settings.Default.email = loginBox.Text;
                            if (checkBox1.Checked == true)
                            {
                                Properties.Settings.Default.password = pswBox.Text;
                                Properties.Settings.Default.Save();
                                Properties.Settings.Default.remember = "yes";
                            }

                            mainMenu.Show();
                            this.Hide();

                            //STORE USERID FOR SESSION
                            queryId = "SELECT userId FROM user WHERE email = @email1";

                            using (MySqlCommand cmdId = new MySqlCommand(queryId))
                            {
                                cmd.Parameters.Add(new MySqlParameter("@email1", loginBox.Text));
                                DataTable dtId = new DataTable();
                                MySqlDataAdapter daId = new MySqlDataAdapter(cmdId);
                                daId.Fill(dtId);
                                userId = dtId.Rows[0]["userId"].ToString();
                            }

                        }


                    }
                }
                catch (SocketException ex)
                {
                    if (databaseOperations.errorMsg == false)
                    {
                        MessageBox.Show(ex.Message, "Connection error");
                        databaseOperations.errorMsg = true;
                    }
                }
                catch (Exception ex)
                {
                    if (databaseOperations.errorMsg == false)
                    {
                        MessageBox.Show(ex.Message, "ERROR!");
                        databaseOperations.errorMsg = true;
                    }
                }

            }
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost/register.php");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            launch = true;
        }

        //REMEMBER ME CHECKBOX SETTINGS
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.email = loginBox.Text;
                Properties.Settings.Default.password = pswBox.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.remember = "yes";
            }
            else
            {
                Properties.Settings.Default.email = loginBox.Text;
                Properties.Settings.Default.password = "Password";
                Properties.Settings.Default.remember = "no";
                Properties.Settings.Default.Save();
            }
        }

        private void loginBox_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == "Email")
            {
                loginBox.Text = "";
            }
        }

        private void loginBox_Leave(object sender, EventArgs e)
        {
            if (loginBox.Text == "")
            {
                loginBox.Text = "Email";
            }
        }

        private void pswBox_Enter(object sender, EventArgs e)
        {
            if (pswBox.Text == "Password")
            {
                pswBox.Text = "";
                pswBox.PasswordChar = '*';
            }
        }

        private void pswBox_Click(object sender, EventArgs e)
        {
            if (pswBox.Text == "Password")
            {
                pswBox.Text = "";
                pswBox.PasswordChar = '*';
            }
        }

        private void pswBox_Leave(object sender, EventArgs e)
        {
            if (pswBox.Text == "")
            {
                pswBox.PasswordChar = '\0';
                pswBox.Text = "Password";
            }
        }

        //***WINDOW DRAGGING
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        //***


    }
}
