﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace hexaDECIMAL
{
    public class databaseOperations
    {
        //MYSQL DB CONNECTION
        public static string mysqlDatasource = @"Data Source=localhost;
                                port=3306;Initial Catalog=haxadecimal; User Id='admin'; password='admin'; SslMode=none";
        private static MySqlConnection con = new MySqlConnection(mysqlDatasource);

        //CONNECTION CHECK COUNTER
        static int count;
                
        //MYSQL DB CONNECTIVITY CONFIRMATION
        public static bool onlineCheck { get; set; }

        //ERROR MSG PROMPT (TO AVOID UNNECESSARY ERROR BOXES SHOWING)
        public static bool errorMsg { get; set; }

        public databaseOperations()
        {
            count = 0;
            onlineCheck = false;
            errorMsg = false;
        }

        //MYSQL DB CONNECTIVITY CHECK
        public static bool dbConnectionCheck()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                if (con.State == ConnectionState.Open)
                {
                    databaseOperations.onlineCheck = true;
                    return true;
                }
                else
                {
                    while (count <= 2)
                    {
                        dbConnectionCheck();
                        count++;
                    }
                    if (count == 2)
                    {
                        count = 0;
                        databaseOperations.onlineCheck = false;
                        return false;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }


    }
}
