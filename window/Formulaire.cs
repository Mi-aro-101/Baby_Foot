using System;
using System.Windows.Forms;
using model;
using System.Collections.Generic;

namespace window
{
    /**
    * This class is used for displaying a form that allows you to choose which of the Players want to duel
    */
    public class Formulaire : Form
    {

        // Variable that will define the Form size
        int lavany, sakany;
        // The two lists (dropdown list) that will contain all players
        private ComboBox[] mpilalao_list;
        // Text box to get the amount of bet they will set
        private TextBox betValue;
        private TextBox manche;
        // Button begin match
        Button submit;

        public Formulaire(){
            Lavany = 500; Sakany=400;
            // List where you can select which of the players want to duel
            Mpilalao_list = new ComboBox[2];
        }

        // Function that will set up all the elements contained in the Form window
        public void setUpGUI(List<Mpilalao> mpilalao){
            // Setting a title for the form
            this.Text = "Baby foot";
            // Set its size
            this.Size = new System.Drawing.Size(Lavany, Sakany);
            int i = 0;



            // Adding the 2 ComboBox that contains the lists of the players
            for(i = 0 ; i < Mpilalao_list.Length ; i++){
                Mpilalao_list[i] = new ComboBox();
                // Initialize KeyValuePair that will contains the key as value of comboBox and its name as value displayed
                List<KeyValuePair<Mpilalao,string>> comboBoxItem = new List<KeyValuePair<Mpilalao, string>>();
                for(int j = 0 ; j < mpilalao.Count ; j++){
                    // Combobox accept an array as argument, so I transformed the name of the players into an array of srting
                    comboBoxItem.Add(new KeyValuePair<Mpilalao, string>(mpilalao[j], mpilalao[j].AnaranaMpilalao));
                }
                // Adding KeyValuePair List as item of the comboBox using key as value and name as display member
                Mpilalao_list[i].DataSource = comboBoxItem;
                Mpilalao_list[i].DisplayMember = "Value";
                Mpilalao_list[i].ValueMember = "Key";
                // Set comboBoxes location
                Mpilalao_list[i].Location = new System.Drawing.Point((Lavany/2)-50, Sakany/(i+2));
                //Adding the comboBox to the form
                Controls.Add(Mpilalao_list[i]);
            }

            // Text field that will retrieve the bet value
            BetValue = new TextBox(){Text = "Bet_amount_price"};
            BetValue.Location = new System.Drawing.Point((Lavany/2)-40, Sakany/(i+=2));
            Controls.Add(BetValue);

            // Manche, how much times (ball) do they wanna play
            Manche = new TextBox(){Text = "Manche"};
            Manche.Location = new System.Drawing.Point((Lavany/2)-40, Sakany/(i+=2));
            Controls.Add(Manche);

            // Validation button settings
            Submit = new Button(){Text = "Commencer"};
            Submit.Location = new System.Drawing.Point((Lavany/2)-40, Sakany-100);
            // Attribute a function when I click the button
            Submit.Click += Retrieve;
            Controls.Add(Submit);
        }

        //Function that will retrieve values from the form when button "Submit" is clicked
        public void Retrieve(object sender, EventArgs e){
            string bet_value = BetValue.Text;
            string manche_value = Manche.Text;
            Mpilalao mpilalao1 = (Mpilalao)Mpilalao_list[0].SelectedValue;
            Mpilalao mpilalao2 = (Mpilalao)Mpilalao_list[1].SelectedValue;
            int bet = 0;
            int manche = 0;

            // Controlling the value first
            if(mpilalao1.IdMpilalao == mpilalao2.IdMpilalao){
                MessageBox.Show("Tsy mety ny mampiady ireo mpilalao ireo", "Mpiady tsy mety", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Control the betvalue, not allowed if it is string
            if(int.TryParse(bet_value, out bet) == false || int.TryParse(manche_value, out manche) == false){
                MessageBox.Show("Tsy mety isa ampidirinao", "Impiry dia Aiza ny vola", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                // Call the function that create a new Match and open the Kianja window
                beginMatch(mpilalao1, mpilalao2, bet, manche);
            }
        
        }

        // Begin and initialize the match
        public void beginMatch(Mpilalao mpilalao1, Mpilalao mpilalao2, int bet, int manche){
            Lalao lalao = new Lalao(0, mpilalao1.IdMpilalao, mpilalao2.IdMpilalao, 0, 0, bet, manche);
            Kianja kianja = lalao.newMatch(mpilalao1, mpilalao2, manche, this);
            // Hide the form window
            this.Hide();
            // Call a function that customizes the GUI of the kianja window
            kianja.SetUpGUI();
            // Display the kianja window on the screen
            kianja.Show();
        }

        // Getters and Setters
        public int Lavany{get; set;}
        public int Sakany{get; set;}
        public ComboBox[] Mpilalao_list{get; set;}
        public TextBox BetValue{get; set;}
        public TextBox Manche{get; set;}
        public Button Submit{get; set;}
    }
}