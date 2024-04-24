using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;

namespace dolgozok_adatainak_lekerese
{
    internal class Adatbazis
    {
        MySqlCommand MySqlCommand;
        MySqlConnection MySqlConnection;

        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "dolgozok";

            MySqlConnection = new MySqlConnection(builder.ConnectionString);
            MySqlCommand = MySqlConnection.CreateCommand();

            
        }

        private void kapcsolatZar()
        {
            try
            {
                if (MySqlConnection.State != System.Data.ConnectionState.Closed)
                {
                    MySqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private void kapcsolatNyit()
        {
            try
            {
                if (MySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    MySqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }            
        }

        internal List<Dolgozok> getAllDolgozo()
        {
            kapcsolatNyit();
            List<Dolgozok> dolgozok = new List<Dolgozok>();
            MySqlCommand.CommandText = "SELECT `nev`,`neme`,`reszleg`,`belepesev`,`ber` FROM `dolgozok`";
            using (MySqlDataReader dr = MySqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dolgozok dolgozo = new Dolgozok(dr.GetString("nev"), dr.GetString("neme"), dr.GetString("reszleg"), dr.GetInt32("belepesev"), dr.GetInt32("ber"));
                    dolgozok.Add(dolgozo);
                }
                kapcsolatZar();
            }
            return dolgozok;
        }
    }
}
