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

        public void openConnectionExists(string u_, string p_)
        {
            string cs = string.Format("server=127.0.0.1;uid='{0}';password='{1}';database=ais", u_, p_);
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

        public string createQuerryString(string v, string u_, string p_)
        {

            openConnectionExists(u_, p_);

            MySqlCommand cmd = new MySqlCommand(v, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            string text = "";

            if (rdr.Read())
            {
                text = rdr.GetString(0);
            }

            rdr.Close ();
            return text;
        }

        public void createQuerry(string v, string u_, string p_) {

            openConnectionExists(u_, p_);

            MySqlCommand cmd = new MySqlCommand(v, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Close();

            closeConnection();
        }

        public DataTable transformToDT(List<List<object>> list, List<string> columnNames)
        {
            DataTable dt = new DataTable(); // sukuriamas DT atvaizduoti duomenis istrauktus is DB
            foreach (var columnName in columnNames)
            {
                dt.Columns.Add(columnName); // Sukuriami stulpeliai dataTable'ui
            }

            foreach (var row in list)
            {

                var values = new object[row.Count]; // sukuriamas masyvas visos eilutes elementu (kiek eiluteje elementu, toks masyvo dydis)

                for (int i = 0; i < row.Count; i++)
                {
                    values[i] = row[i];
                }
                dt.Rows.Add(values);
            }

            return dt;
        }

        public async Task<List<List<object>>> getData(string v, string u_, string p_)
        {

            openConnectionExists(u_, p_);

            MySqlCommand cmd = new MySqlCommand(v, conn);
            var rdr = await cmd.ExecuteReaderAsync(); // ERA - igalina ReadAsync skaityma duomenu

            var mainList = new List<List<object>>();

            while (await rdr.ReadAsync() ) // ReadAsync - nuskaito tolimesne eilute (row)
            {
                List<object> data = new List<object>();
                for (int i = 0; i < rdr.FieldCount; i++) {  // FieldCount - column count

                    data.Add(rdr.GetValue(i)); // GetValue paima column'o duomeni ir ideda i "temporary" data sarasa
                }

                mainList.Add(data); // temporary sarasas su vieno row duomenimis idedamas i main sarasa, kuriame visi duomenys accessible
            }

            closeConnection();

            return mainList;//list;
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

        public string getGradeTypeString (int gradeTypeID, string u_, string p_) {

            string query = string.Format("SELECT typeName FROM ais.grade_type WHERE grade_type_ID = '{0}'", gradeTypeID);
            string result = createQuerryString(query, u_, p_);

            return result;
        }

        public bool checkIfRelative (string v, string u_, string p_)
        {

            openConnectionExists(u_, p_);

            int existingNums = createQuerryInt(v);

            if (existingNums > 0)
            {
                return true;
            }
            else return false;
        }

        public string generateUser(string u_, string p_)
        {

            string generatedUser = "";

            Random random = new Random();
            int randomNumber = random.Next(1000000);

            generatedUser = "s" + randomNumber.ToString();
            if (!checkIfRelative(string.Format("SELECT DBuser from ais.users WHERE DBuser = '{0}'", generatedUser), u_, p_))
            {

                return generatedUser;
            } else generateUser(u_, p_);

            return generatedUser;

        }

    }

}