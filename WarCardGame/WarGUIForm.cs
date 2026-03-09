using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarCardGame
{
    public partial class WarGUIForm : Form
    {
        Deck cardDeck = new Deck();
        
        public WarGUIForm()
        {
            InitializeComponent();
            
            //Card shuffle = cardDeck.Shuffle();
            //TestBox.Text = $"{cardDeck.Deal()}";
        }
        string[,] CardPics = new string[5,12];


        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cardDeck.Clear();
            Card currentCard = cardDeck.Deal();
            try
            {
                TestBox.Items.Add($"{currentCard.Rank()} of {currentCard.Suit()}");
            }
            catch(Exception) { }
        }
    }
}
