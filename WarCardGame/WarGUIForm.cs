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
        List<Card> playerCards = new List<Card>();
        List<Card> computerCards = new List<Card>();
        int cardNum = 0;
        
        public WarGUIForm()
        {
            InitializeComponent();
        }
        string[,] CardPics = new string[5,12];


        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Card currentCard = cardDeck.Deal();
            if (cardNum % 2 == 0)
            {
                playerCards.Add(currentCard);
            }
            else 
            { 
                computerCards.Add(currentCard);
            }
        }
    }
}
