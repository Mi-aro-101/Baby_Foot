using connection;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using model;
using window;
using System.Windows.Forms;

namespace main {
    public class Hello{
        [STAThread]
        public static void Main(string[] args){
            Connexion connexion = new Connexion();
            SQLiteConnection connct = connexion.Connect();
                        
            Mpilalao mpilalao = new Mpilalao();
            // Get all the player in the SQLite database, give a connection as argument, if not it will be null by default
            List<Mpilalao> all_Player = mpilalao.getAll();

            // Init a Form object
            Formulaire init_play = new Formulaire();
            // Configure the display of the form
            init_play.setUpGUI(all_Player);

            // Display the form to screen and run it
            Application.Run(init_play);

            //Close the connection
            connct.Close();

        }
    }
}