using System;
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
                                port=3306;Initial Catalog=haxadecimal; User Id=user;password='user'";
        private static MySqlConnection con = new MySqlConnection(mysqlDatasource);

        //SQLITE SOURCE
        public static string datasource = @"DataSource=HNDSOFTSA13.db";

        //CONNECTION CHECK COUNTER
        static int count;

        //USER SUBSCRIPTION INFO
        public static bool premiumCheck { get; set; }

        //MYSQL DB CONNECTIVITY CONFIRMATION
        public static bool onlineCheck { get; set; }

        //ERROR MSG PROMPT (TO AVOID UNNECESSARY ERROR BOXES SHOWING)
        public static bool errorMsg { get; set; }

        public databaseOperations()
        {
            count = 0;
            onlineCheck = false;
            errorMsg = false;
            premiumCheck = false;
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
