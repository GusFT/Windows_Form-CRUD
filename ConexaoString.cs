using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO0_exp_modeloprotrabalho
{
    internal class ConexaoString
    {
        string severName = "localhost";
        string port = "5432";
        string userName = "postgres";
        string password = "pgsql";
        string databaseName = "dbCliente";

        public string ConnString()
        {
            var connString = String.Format("Server = {0}; Port = {1}; Username = {2}; Password = {3}; Database = {4};", severName, port,
                userName, password, databaseName);

            // da de fazer assim tb:
            // var connString = "Server =" + severName +";Port ="+ port +"; Username ="+ userName +"; Password ="+ password +";Database ="+ databaseName + ";";


            return connString;
        }
    }
}
