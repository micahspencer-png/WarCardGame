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
        public WarGUIForm()
        {
            InitializeComponent();
        }

        private void CardInitialize() 
        { 
            Deck cardDeck = new Deck();
            Card currentCard = cardDeck.Deal();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
