using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace AIS.Back.DBConfig
{
    public class DBConfig
    {

        private MySqlConnection conn;
        private string u_, p_;

        public void setCredentials(string username, string password)
        {
            u_ = username;
            p_ = password;
        }

        public string getUsername()
        {
            return u_;
        }
        public string getPassword()
        {
            return p_;
        }

        public void openConnection()
        {
            string cs = "server=127.0.0.1;uid=temp;password=temp;database=ais";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = cs;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void openConnectionExists()
        {
            string cs = string.Format("server=127.0.0.1;uid='{0}';password='{1}';database=ais", getUsername(), getPassword());
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = cs;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void closeConnection()
        {

            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }catch (MySqlException ex)
            {
                Debug.WriteLine("Error closing database connection: " + ex.Message);
            }
        }

        public int createQuerryInt(string v)
        {
            MySqlCommand cmd = new MySqlCommand(v, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            int result = 0;

            if (rdr.Read()) { 
            
                result = rdr.GetInt32(0);

            }

            rdr.Close();

            return result;
        }

        public void createQuerry(string v) {

            MySqlCommand cmd = new MySqlCommand(v, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
        }

        public bool verifyUserExistance(string u_, string p_)
        {

            openConnection();

            if (conn.State != ConnectionState.Open)
            {
                openConnection();
            }

            string query = string.Format("SELECT COUNT(*) FROM ais.users WHERE username = '{0}' AND password = '{1}'", u_, p_);
            int userCount = createQuerryInt(query);

            closeConnection();

            if (userCount > 0)
            {
                return true;
            }
            else return false;
        }

        public int getUserTypeID(string u_, string p_) {

            openConnection();

            if (conn.State != ConnectionState.Open)
            {
                openConnection();
            }

            string query = string.Format("SELECT user_typeID FROM ais.users WHERE username = '{0}' AND password = '{1}'", u_, p_);
            int userTypeID = createQuerryInt(query);

            closeConnection();

            return userTypeID;
        }

    }
}