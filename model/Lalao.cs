using System;
using System.Collections.Generic;
using System.Data.SQLite;
using connection;
using window;


namespace model
{
    public class Lalao
    {
        int idLalao;
        int idMpilalao1;
        int idMpilalao2;
        int isaMpilalao1;
        int isaMpilalao2;
        int fanamby;
        int manche;

        //Construnctors
        public Lalao(){}
        public Lalao(int idlalao, int idMpilalao1, int idMpilalao2, int isaMpilalao1, int isaMpilalao2, int fanamby, int manche){
            IdLalao = idLalao;
            IdMpilalao1 = idMpilalao1;
            IdMpilalao2 = idMpilalao2;
            IsaMpilalao1 = isaMpilalao1;
            IsaMpilalao2 = isaMpilalao2;
            Fanamby = fanamby;
            Manche = manche;
        }

        // Insert function
        public void insert(SQLiteConnection con = null){
            bool isopen = con != null;
            if(!isopen){
                con = (new Connexion()).Connect(); 
            }

            // Preparing the query that will be executed
            string columns = "idMpilalao1, idMpilalao2, isaMpilalao1, isaMpilalao2, fanamby, manche";
            string values = IdMpilalao1+", "+IdMpilalao2+", "+IsaMpilalao1+", "+IsaMpilalao2+", "+Fanamby+", "+Manche;
            string query = "INSERT INTO lalao ("+columns+") VALUES("+values+")";

            try{
                con.Open();
                using(SQLiteCommand command = new SQLiteCommand(query, con)){
                    command.ExecuteNonQuery();
                }
            }catch (Exception e){
                Console.WriteLine(e);
            }
            
        }

        //Function that will ge the last match on (actif)
        public Lalao getLastMatch(SQLiteConnection con = null){
            Lalao result = null;
            bool isopen = con != null;
            if(!isopen){
                con = (new Connexion()).Connect(); 
            }

            // Preparing the list that contains the results
            string query = "SELECT * FROM lalao where idLalao = (select max(idLalao) from lalao)";

            try
            {
                con.Open();
                using(SQLiteCommand command = new SQLiteCommand(query, con)){
                    using(SQLiteDataReader reader = command.ExecuteReader()){
                        // Get only the last match designed by the query from db
                            if(reader.Read()){
                                result = new Lalao(
                                    reader.GetInt32(0), 
                                    reader.GetInt32(1), 
                                    reader.GetInt32(2),
                                    reader.GetInt32(3),
                                    reader.GetInt32(4),
                                    reader.GetInt32(5),
                                    reader.GetInt32(6)
                                );
                            }
                    }
                }
            } catch (Exception e){Console.WriteLine(e);}
            finally{
                if(!isopen){con.Close();}
            }

            return result;
        }

        // Function begin match and then return Kianja that will be given to Form and displays it
        public Kianja newMatch(Mpilalao mpilalao1, Mpilalao mpilalao2, int manche, Formulaire form1){
            Babyfoot babyfoot = new Babyfoot();
            babyfoot = babyfoot.getBabyfoot();
            this.Fanamby = this.Fanamby-(babyfoot.VidinaJeton*2*manche);
            this.insert();
            Console.WriteLine("Manomboka ny lalao ary.");
            // Put the two opponent in a array so I can give it to the constructor of Kianja (game window)
            Mpilalao[] players = new Mpilalao[2];
            players[0] = mpilalao1;
            players[1] = mpilalao2;
            // Get the last match I inserted in order to give it Kianja, 
            // then It can use mathc's id in order to insert in statlalao table every action done
            Lalao izao = this.getLastMatch();
            Kianja kianja = new Kianja(1000, 500, players, izao, babyfoot.IsaBaolina*manche, form1);
            
            return kianja;
        }

        //Getters and Setters
        public int IdLalao{get; set;}
        public int IdMpilalao1{get; set;}
        public int IdMpilalao2{get; set;}
        public int IsaMpilalao1{get; set;}
        public int IsaMpilalao2{get; set;}
        public int Fanamby{get; set;}

        public int Manche{get; set;}

    }
}