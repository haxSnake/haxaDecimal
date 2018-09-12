using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace hexaDECIMAL
{
    class User
    {
        private static string connStr = @"Data Source = localhost; port = 3306; Initial Catalog = haxadecimal; User Id = user; password = 'user'";
        public MySqlConnection dbCon = new MySqlConnection(connStr); // MySql database connector
        private DataTable dt;           // data table
        private MySqlCommand cmd;       // MySql command

        public bool fullSub;           // subscription type bool

        private string querySql = "";   // MySql query string

        // user table variables
        private int userId { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string email { get; set; }
        private string pw { get; set; }
        private string dob { get; set; }
        //private int phoneNumber { get; set; }
        private string street { get; set; }
        private int postcode { get; set; }
        private string city { get; set; }
        private string country { get; set; }


        public int MyProperty { get; set; }


        // open data base connection
        public void DBconn()
        {

            // connection with MySql database
            try
            {
                // checking if connection to database is closed or open and if closed than open connection
                if (dbCon.State == ConnectionState.Closed)
                    dbCon.Open();
            }
            catch (Exception ex)
            {
                // if connection to server hadn't been eastablish display error massege
                string m = "Application could not connect to server";
                string m2 = "Error";
                MessageBox.Show(m, m2);
            }

        }

        // close data base connection
        public void DBconnClose()
        {
            // checking if connection to database is open and if yes than close connection
            if (dbCon.State == ConnectionState.Open)
                dbCon.Close();
        }


        // selecting data from database
        public DataTable Select()
        {

            // checking if connection is open or closed
            if (dbCon.State == ConnectionState.Closed)
                dbCon.Open(); // connecting to db

            try
            {
                MySqlDataReader mdr;

                // creating cmd using MySql and conn
                MySqlCommand cmd = dbCon.CreateCommand();

                // Writing MySql query
                cmd.CommandText = "SELECT * FROM user";

                //Redeing string from db to reader
                mdr = cmd.ExecuteReader();

                if (mdr.Read())
                {
                    dt = new DataTable();
                    // Creating MySQL data adapter using cmd
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                    dbCon.Open();
                    adp.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // error catch 
                string erMsg = string.Format("Error during User Login:\n{0}", ex.Message); // error message
                MessageBox.Show(erMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // error box display
            }
            finally
            {
                dbCon.Close();
                dbCon.Dispose();
            }

            return dt;

        }


        // Insert data to database
        public bool Insert(User q)
        {
            // Creating a default return type and setting its value to false
            bool isSuccess = false;

            try
            {

                querySql = "INSERT INTO user (firstName,lastName,email,pw,dob,street,postcode,city,country) VALUES ('" + firstName + "','"
                            + lastName + "','" + email + "','" + pw + "','" + dob + "','" + street + "','" + postcode + "','" + city + "','" + country + "')";

                // Creating MySQL command using sql and conn
                MySqlCommand cmd = new MySqlCommand(querySql, dbCon);

                // Create parametrs to add data
                cmd.Parameters.AddWithValue("@firstName", q.firstName);
                cmd.Parameters.AddWithValue("@lastName", q.lastName);
                cmd.Parameters.AddWithValue("@email", q.email);
                cmd.Parameters.AddWithValue("@pw", q.pw);
                cmd.Parameters.AddWithValue("@dob", q.dob);
                //cmd.Parameters.AddWithValue("@phoneNumber", q.phoneNumber);
                cmd.Parameters.AddWithValue("@street", q.street);
                cmd.Parameters.AddWithValue("@postcode", q.postcode);
                cmd.Parameters.AddWithValue("@city", q.city);
                cmd.Parameters.AddWithValue("@country", q.country);

                // open connection
                dbCon.Open();
                int rows = cmd.ExecuteNonQuery();

                // if the query run ssuccessfuly then the value of rows will be greater then 0 else will equal 0

                if (rows > 0)
                {
                    isSuccess = true;
                    MessageBox.Show(" You've been registered \n Please click cancel button to get back to login form", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                // error catch 
                string erMsg = string.Format("Error during User Registration.\n{0}", ex.Message); // error message
                MessageBox.Show(erMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // error box display
            }
            finally
            {
                dbCon.Close();
            }

            return isSuccess;
        }


        // Methode to update data in application
        public bool Update(User q)
        {
            // Create a return type and set it defoult value to false
            bool isSuccess = false;

            dbCon.Open();

            try
            {
                // MySQL update data in database
                querySql = "UPDATE user SET firstName=@firstName, lastName=@lastName, email=@email, pw=@pw, dob=@dob, street=@street, postcode=@postcode, city=@city, country=@country WHERE userId=@userId";

                // creating MySQL command
                MySqlCommand cmd = new MySqlCommand(querySql, dbCon);

                // creating paramiters to add value
                cmd.Parameters.AddWithValue("@firstName", q.firstName);
                cmd.Parameters.AddWithValue("@lastName", q.lastName);
                cmd.Parameters.AddWithValue("@email", q.email);
                cmd.Parameters.AddWithValue("@pw", q.pw);
                cmd.Parameters.AddWithValue("@dob", q.dob);
                //cmd.Parameters.AddWithValue("@phoneNumber", q.phoneNumber);
                cmd.Parameters.AddWithValue("@street", q.street);
                cmd.Parameters.AddWithValue("@postcode", q.postcode);
                cmd.Parameters.AddWithValue("@city", q.city);
                cmd.Parameters.AddWithValue("@country", q.country);

                // open connection
                dbCon.Open();
                int rows = cmd.ExecuteNonQuery();

                // if the query runssuccessfuly then the value of rows will be greater then 0 else will equal 0

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                // error catch 
                string erMsg = string.Format("Error during User information update.\n{0}", ex.Message); // error message
                MessageBox.Show(erMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // error box display
            }
            finally
            {
                dbCon.Close();
            }

            return isSuccess;
        }

        public bool Delete(User q)
        {
            // Create a return type and set it defoult value to false
            bool isSuccess = false;

            // Connect to database
            // MySqlConnection conn = new MySqlConnection(myConn);

            try
            {
                // MySQL to delete user
                querySql = "DELETE FROM user WHERE  userId=@userId";

                // creating MySQL command
                MySqlCommand cmd = new MySqlCommand(querySql, dbCon);

                // creating paramiters to add value
                cmd.Parameters.AddWithValue("@userId", q.userId);

                // open connection
                dbCon.Open();
                int rows = cmd.ExecuteNonQuery();

                // if the query runssuccessfuly then the value of rows will be greater then 0 else will equal 0

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                dbCon.Close();
            }
            return isSuccess;
        }


        // user login
        public bool Login(User q)
        {

            bool logpass = false;

            DataTable dt = new DataTable();

            try
            {

                dbCon.Open();
                MySqlDataReader mdr;

                // creating cmd using MySql and conn
                MySqlCommand cmd = dbCon.CreateCommand();

                cmd.CommandType = CommandType.Text;

                string cmdLine = "SELECT * FROM user WHERE email=@email and pw=@pw";
                //      string cmd = "SELECT * FROM user full_sub";

                // Writing MySql query
                cmd.CommandText = cmdLine;
                cmd.Parameters.Add("@email", q.email);
                cmd.Parameters.Add("@pw", q.pw);
                cmd.ExecuteNonQuery();

                dt = new DataTable();
                // Creating MySQL data adapter using cmd
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                int rows = adp.Fill(dt);
                //   logpass = Convert.ToInt32(dt.Rows.Count.ToString());

                // if the query runssuccessfuly then the value of rows will be greater then 0 else will equal 0

                if (rows > 0)
                {
                    logpass = true;
                }
                else
                {
                    logpass = false;
                }

                //Redeing string from db to reader
                mdr = cmd.ExecuteReader();


                if (mdr.Read())
                {
                    fullSub = mdr.GetBoolean("full_sub");
                }

            }
            catch (Exception ex)
            {
                // error catch 
                string erMsg = string.Format("Error during User Login:\n{0}", ex.Message); // error message
                MessageBox.Show(erMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // error box display
            }
            finally
            {
                dbCon.Close();
            }

            return logpass;


        }



    }
}
