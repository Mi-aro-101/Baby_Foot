using System;
using System.Data.SQLite;

namespace connection
{
    // This class is only responsible for the connection to the database
    public class Connexion
    {
        // The string for connection to "babyfoot.mdb" file database [SQLite]
        static string connection_string = "Data Source=babyfoot.mdb;Version=3;";

        // Constructor
        public Connexion(){}

        public SQLiteConnection Connect(){
            SQLiteConnection connexion = null;
            try{
                // Setting up a connection
                connexion = new SQLiteConnection(connection_string);
            }catch(Exception e){
                Console.WriteLine("Connection failed :"+e.Message);
            }

            return connexion;
        }

        // Getters only of the string connection in case null given
        public static string Connection_string{get; set;}
    }
}