using System;
using connection;
using System.Data.SQLite;
using System.Collections.Generic;
using window;

namespace model
{
    public class Mpilalao
    {
        int idMpilalao;
        string anaranaMpilalao;
        double vola;

        // Used only when they are on match, they will possess a theri Taho
        Taho[] playerController;
        // Contructor
        public Mpilalao(){}

        

        public Mpilalao(int idMpilalao, string anaranaMpilalao, double vola){
            this.IdMpilalao = idMpilalao;
            this.AnaranaMpilalao = anaranaMpilalao;
            this.Vola = vola;
        }

        // A function that will select all from mpilalao and return a list of it 
        public List<Mpilalao> getAll(SQLiteConnection con = null){
            bool isopen = con != null;
            if(!isopen){
                con = (new Connexion()).Connect(); 
            }

            // Preparing the list that contains the results
            List<Mpilalao> results = new List<Mpilalao>();
            string query = "SELECT * FROM mpilalao";

            try
            {
                con.Open();
                using(SQLiteCommand command = new SQLiteCommand(query, con)){
                    using(SQLiteDataReader reader = command.ExecuteReader()){
                            while(reader.Read()){
                                Mpilalao toadd = new Mpilalao(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2));
                                results.Add(toadd);
                            }
                    }
                }
            } catch (Exception e){Console.WriteLine(e);}
            finally{
                if(!isopen){con.Close();}
            }

            return results;

        }

        // Getters
        public int IdMpilalao {get ; set;}
        public string AnaranaMpilalao{get; set;}
        public double Vola {get; set;}
        public Taho[] PlayerController {get; set;}
    }
}