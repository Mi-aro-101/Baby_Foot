using System;
using System.Collections.Generic;
using System.Data.SQLite;
using connection;


namespace model
{
    public class Babyfoot
    {
        int idBabyfoot;
        int vidinaJeton;
        int isaBaolina;

        // Constructor
        public Babyfoot(){}
        public Babyfoot(int idBabyfoot, int vidinaJeton, int isaBaolina){
            IdBabyfoot = idBabyfoot;
            VidinaJeton = vidinaJeton;
            IsaBaolina = isaBaolina;
        }

        // select the baby
        public Babyfoot getBabyfoot(SQLiteConnection con = null){
            Babyfoot result = null;
            bool isopen = con != null;
            if(!isopen){
                con = (new Connexion()).Connect(); 
            }

            // Preparing the list that contains the results
            string query = "SELECT * FROM Babyfoot";

            try
            {
                con.Open();
                using(SQLiteCommand command = new SQLiteCommand(query, con)){
                    using(SQLiteDataReader reader = command.ExecuteReader()){
                        // Get only one baby dispo in the db
                            if(reader.Read()){
                                result = new Babyfoot(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                            }
                    }
                }
            } catch (Exception e){Console.WriteLine(e);}
            finally{
                if(!isopen){con.Close();}
            }

            return result;
        }

        // Getters and Setters
        public int IdBabyfoot{get; set;}
        public int VidinaJeton{get; set;}
        public int IsaBaolina{get; set;}
    }
}