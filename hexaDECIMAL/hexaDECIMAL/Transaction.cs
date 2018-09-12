﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hexaDECIMAL
{
    class Transaction
    {
        private static string connStr = @"Data Source = localhost; port = 3306; Initial Catalog = haxadecimal; User Id = user; password = 'user'";
        public MySqlConnection dbCon = new MySqlConnection(connStr); // MySql database connector
        private DataTable dt;           // data table
        private MySqlCommand cmd;       // MySql command

        public bool fullSub;           // subscription type bool

        private string querySql = "";   // MySql query string



        // Data carrir in QP Application - user data
        private int transactionId { get; set; }
        private int accId { get; set; }
        private string transactionDate { get; set; }
        private bool transactionType { get; set; } 
        private int transactionForeignAccount { get; set; }
        private double value { get; set; }

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
        public bool Insert(Transaction q)
        {
            // Creating a default return type and setting its value to false
            bool isSuccess = false;

            try
            {

                querySql = "INSERT INTO user (transactionDate,transactionType,transactionForeignAccount,value) VALUES ('" + transactionType + "','" + value + "')";

                // Creating MySQL command using sql and conn
                MySqlCommand cmd = new MySqlCommand(querySql, dbCon);

                // Create parametrs to add data
                cmd.Parameters.AddWithValue("@transactionDate", q.transactionDate);
                cmd.Parameters.AddWithValue("@transactionType", q.transactionType);
                cmd.Parameters.AddWithValue("@transactionForeignAccount", q.transactionForeignAccount);
                cmd.Parameters.AddWithValue("@value", q.value);

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
        public bool Update(Transaction q)
        {
            // Create a return type and set it defoult value to false
            bool isSuccess = false;

            dbCon.Open();

            try
            {
                // MySQL update data in database
                querySql = "UPDATE user SET transactionDate=@transactionDate, TransactionType=@TransactionType, transactionForeignAccount=@transactionForeignAccount, value=@value WHERE transactionId=@transactionId";

                // creating MySQL command
                MySqlCommand cmd = new MySqlCommand(querySql, dbCon);

                // creating paramiters to add value
                cmd.Parameters.AddWithValue("@transactionDate", q.transactionDate);
                cmd.Parameters.AddWithValue("@TransactionType", q.transactionType);
                cmd.Parameters.AddWithValue("@transactionForeignAccount", q.transactionForeignAccount);
                cmd.Parameters.AddWithValue("@value", q.value);

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

        public bool Delete(Transaction q)
        {
            // Create a return type and set it defoult value to false
            bool isSuccess = false;

            // Connect to database
            // MySqlConnection conn = new MySqlConnection(myConn);

            try
            {
                // MySQL to delete user
                querySql = "DELETE FROM user WHERE  accId=@accId";

                // creating MySQL command
                MySqlCommand cmd = new MySqlCommand(querySql, dbCon);

                // creating paramiters to add value
                cmd.Parameters.AddWithValue("@accId", q.accId);

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
    }
}