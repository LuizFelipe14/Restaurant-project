using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importing MySQL Dll
using MySql.Data.MySqlClient;


namespace Restaurante.Class.DataBase {
    class MySqlConn {

        #region Properties

        string stringConn;

        MySqlConnection connDB;

        #endregion


        #region Construct

        //Construct for connection in MySQL and in DataBase
        public MySqlConn(string server, string vUser, string vPassword, string vDataBase) {

            string stringConn = "server=" + server + ";database=" + vDataBase + ";User Id=" + vUser + ";Password=" + vPassword + ";";

            connDB = new MySqlConnection(stringConn);

            connectDB();

        }

        #endregion

        #region Methods

        /*--------------------
        Method 1 (SQLQuery)
        Param1 = Query
        Method for capture query 
        --------------------*/
        public void SQLQuery(string SQLq) {

            try {
                MySqlCommand myCommand = new MySqlCommand(SQLq, connDB);
            }
            catch (Exception) {
                Console.WriteLine("Sem Sucesso !");
                throw;
            }
        }


        /*--------------------
        Method 1 (SQLQuery)
        Method for connect to database
        --------------------*/
        public MySqlConnection connectDB() {

            switch (connDB.State == System.Data.ConnectionState.Closed) {
                case true:
                    connDB.Open();
                    break;
                default:
                    break;
            }
            return connDB;
        }


        /*--------------------
       Method 1 (SQLQuery)
       Method for disconnect to database
       --------------------*/
        public void disconnectDB() {

            switch (connDB.State == System.Data.ConnectionState.Open) {
                case true:
                    connDB.Close();
                    break;
                default:
                    break;
            }
        }
    }


    #endregion

}
