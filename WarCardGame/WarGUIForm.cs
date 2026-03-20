using System;
using System.Resources;
using System.Collections;
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
    //Micah Spencer
    //RCET 3371
    //Spring 2026
    //War Card Game Simulator
    //https://github.com/micahspencer-png/WarCardGame.git
    public partial class WarGUIForm : Form
    {
        
        List<Card> PlayerHand = new List<Card>();
        List<Card> ComputerHand = new List<Card>();
        Image[] images = new Image[54];
        bool back = false;
        bool war = false;
        int ComHand = 0;
        int PlyHand = 0;
        int cWar = 0;
        int pWar = 0;
        int WarCount = 0;
        int Discard = 0;
        public WarGUIForm()
        {
            InitializeComponent();
            CardImageLoad();
            Defaults();
        }
        //Program Logic---------------------------------------------------------------------------------------------------------------------

        void Defaults() 
        {
            back = true;
            war = false;
            ComHand = 0;
            PlyHand = 0;
            cWar = 0;
            pWar = 0;
            WarCount = 0;
            Discard = 0;
            StartButton.Enabled = true;
            PlayButton.Enabled = false;
            ComputerTextBox.BackColor = Color.White;
            PlayerTextBox.BackColor = Color.White;
            ComputerTextBox.Text = ComHand.ToString();
            PlayerTextBox.Text = PlyHand.ToString();
            DiscardTextBox.Text = Discard.ToString();
            Image img = null;
            PlayerPictureBox2.Image = img;
            ComputerPictureBox2.Image = img;
            PlayerPictureBox3.Image = img;
            ComputerPictureBox3.Image = img;
            PlayerPictureBox4.Image = img;
            ComputerPictureBox4.Image = img;
        }
        void CardImageLoad()
        {
            images[0] = Image.FromFile("..\\..\\Resources\\KC.jpg");
            images[1] = Image.FromFile("..\\..\\Resources\\KD.jpg");
            images[2] = Image.FromFile("..\\..\\Resources\\KH.jpg");
            images[3] = Image.FromFile("..\\..\\Resources\\KS.jpg");
            images[4] = Image.FromFile("..\\..\\Resources\\AC.jpg");
            images[5] = Image.FromFile("..\\..\\Resources\\AD.jpg");
            images[6] = Image.FromFile("..\\..\\Resources\\AH.jpg");
            images[7] = Image.FromFile("..\\..\\Resources\\AS.jpg");
            images[8] = Image.FromFile("..\\..\\Resources\\2C.jpg");
            images[9] = Image.FromFile("..\\..\\Resources\\2D.jpg");
            images[10] = Image.FromFile("..\\..\\Resources\\2H.jpg");
            images[11] = Image.FromFile("..\\..\\Resources\\2S.jpg");
            images[12] = Image.FromFile("..\\..\\Resources\\3C.jpg");
            images[13] = Image.FromFile("..\\..\\Resources\\3D.jpg");
            images[14] = Image.FromFile("..\\..\\Resources\\3H.jpg");
            images[15] = Image.FromFile("..\\..\\Resources\\3S.jpg");
            images[16] = Image.FromFile("..\\..\\Resources\\4C.jpg");
            images[17] = Image.FromFile("..\\..\\Resources\\4D.jpg");
            images[18] = Image.FromFile("..\\..\\Resources\\4H.jpg");
            images[19] = Image.FromFile("..\\..\\Resources\\4S.jpg");
            images[20] = Image.FromFile("..\\..\\Resources\\5C.jpg");
            images[21] = Image.FromFile("..\\..\\Resources\\5D.jpg");
            images[22] = Image.FromFile("..\\..\\Resources\\5H.jpg");
            images[23] = Image.FromFile("..\\..\\Resources\\5S.jpg");
            images[24] = Image.FromFile("..\\..\\Resources\\6C.jpg");
            images[25] = Image.FromFile("..\\..\\Resources\\6D.jpg");
            images[26] = Image.FromFile("..\\..\\Resources\\6H.jpg");
            images[27] = Image.FromFile("..\\..\\Resources\\6S.jpg");
            images[28] = Image.FromFile("..\\..\\Resources\\7C.jpg");
            images[29] = Image.FromFile("..\\..\\Resources\\7D.jpg");
            images[30] = Image.FromFile("..\\..\\Resources\\7H.jpg");
            images[31] = Image.FromFile("..\\..\\Resources\\7S.jpg");
            images[32] = Image.FromFile("..\\..\\Resources\\8C.jpg");
            images[33] = Image.FromFile("..\\..\\Resources\\8D.jpg");
            images[34] = Image.FromFile("..\\..\\Resources\\8H.jpg");
            images[35] = Image.FromFile("..\\..\\Resources\\8S.jpg");
            images[36] = Image.FromFile("..\\..\\Resources\\9C.jpg");
            images[37] = Image.FromFile("..\\..\\Resources\\9D.jpg");
            images[38] = Image.FromFile("..\\..\\Resources\\9H.jpg");
            images[39] = Image.FromFile("..\\..\\Resources\\9S.jpg");
            images[40] = Image.FromFile("..\\..\\Resources\\10C.jpg");
            images[41] = Image.FromFile("..\\..\\Resources\\10D.jpg");
            images[42] = Image.FromFile("..\\..\\Resources\\10H.jpg");
            images[43] = Image.FromFile("..\\..\\Resources\\10S.jpg");
            images[44] = Image.FromFile("..\\..\\Resources\\JC.jpg");
            images[45] = Image.FromFile("..\\..\\Resources\\JD.jpg");
            images[46] = Image.FromFile("..\\..\\Resources\\JH.jpg");
            images[47] = Image.FromFile("..\\..\\Resources\\JS.jpg");
            images[48] = Image.FromFile("..\\..\\Resources\\QC.jpg");
            images[49] = Image.FromFile("..\\..\\Resources\\QD.jpg");
            images[50] = Image.FromFile("..\\..\\Resources\\QH.jpg");
            images[51] = Image.FromFile("..\\..\\Resources\\QS.jpg");
            images[52] = Image.FromFile("..\\..\\Resources\\CardBack.jpeg");
        }

        void DefaultBack() 
        {
            Image img = images[52];
            PlayerPictureBox1.Image = img;
            ComputerPictureBox1.Image = img;
        }
        void Round() 
        {
            try
            {
                int cHand = ComputerHand.ElementAt(0).RankIndex;
                int pHand = PlayerHand.ElementAt(0).RankIndex;
                int cSuit = ComputerHand.ElementAt(0).SuitIndex;
                int pSuit = PlayerHand.ElementAt(0).SuitIndex;
                int cIndex = (cHand * 4) + cSuit;
                int pIndex = (pHand * 4) + pSuit;
                Image player = images[pIndex];
                Image computer = images[cIndex];
                PlayerPictureBox1.Image = player;
                ComputerPictureBox1.Image = computer;

                if (pHand == 0)
                {
                    pHand = 13;
                }
                if (pHand == 1)
                {
                    pHand = 14;
                }
                if (cHand == 0)
                {
                    cHand = 13;
                }
                if (cHand == 1)
                {
                    cHand = 14;
                }
                if (cHand > pHand)
                {
                    ComHand++;
                    ComHand++;
                    ComputerTextBox.Text = ComHand.ToString();
                }
                else if (cHand < pHand)
                {
                    PlyHand++;
                    PlyHand++;
                    PlayerTextBox.Text = PlyHand.ToString();
                }
                else
                {
                    war = true;
                    WarSetup();
                }
                PlayerHand.RemoveAt(0);
                ComputerHand.RemoveAt(0);
            }
            catch 
            {
                Winner();
            }
        }

        void WarSetup() 
        {
            Image img = images[52];
            PlayerPictureBox2.Image = img;
            ComputerPictureBox2.Image = img;
            PlayerPictureBox3.Image = img;
            ComputerPictureBox3.Image = img;
            PlayerPictureBox4.Image = img;
            ComputerPictureBox4.Image = img;
        }

        void WarCycle() 
        {
            try
            {
                int cHand = ComputerHand.ElementAt(0).RankIndex;
                int pHand = PlayerHand.ElementAt(0).RankIndex;
                int cSuit = ComputerHand.ElementAt(0).SuitIndex;
                int pSuit = PlayerHand.ElementAt(0).SuitIndex;
                int cIndex = (cHand * 4) + cSuit;
                int pIndex = (pHand * 4) + pSuit;
                Image player = images[pIndex];
                Image computer = images[cIndex];
                PlayerHand.RemoveAt(0);
                ComputerHand.RemoveAt(0);
                if (WarCount == 0)
                {
                    PlayerPictureBox4.Image = player;
                    ComputerPictureBox4.Image = computer;
                }
                if (WarCount == 1)
                {
                    PlayerPictureBox3.Image = player;
                    ComputerPictureBox3.Image = computer;
                }
                if (WarCount == 2)
                {
                    PlayerPictureBox2.Image = player;
                    ComputerPictureBox2.Image = computer;
                }
                if (pHand == 0)
                {
                    pHand = 13;
                }
                if (pHand == 1)
                {
                    pHand = 14;
                }
                if (cHand == 0)
                {
                    cHand = 13;
                }
                if (cHand == 1)
                {
                    cHand = 14;
                }
                if (cHand > pHand)
                {
                    cWar++;
                }
                else if (cHand < pHand)
                {
                    pWar++;
                }
                WarCount++;

                if (WarCount == 3)
                {
                    if (pWar > cWar) 
                    {
                        int buffer = PlyHand + 8;
                        PlyHand = buffer;
                    }
                    else if (cWar > pWar) 
                    {
                        int buffer = ComHand + 8;
                        ComHand = buffer;
                    }
                    else if (cWar == pWar)
                    {
                        int buffer = Discard + 8;
                        Discard = buffer;
                        MessageBox.Show("Match Ended in Draw. Cards are Discarded");
                    }
                    WarCount = 0;
                    war = false;
                    back = false;
                    cWar = 0;
                    pWar = 0;
                    ComputerTextBox.Text = ComHand.ToString();
                    PlayerTextBox.Text = PlyHand.ToString();
                    DiscardTextBox.Text = Discard.ToString();
                }
            }
            catch 
            {
                Winner();
            }
        }

        void Winner() 
        {
            if (ComHand > PlyHand) 
            {
                MessageBox.Show("Opponent Won");
                ComputerTextBox.BackColor = Color.Green;
                PlayerTextBox.BackColor = Color.Red;
            }
            else if (ComHand < PlyHand)
            {
                MessageBox.Show("You Won");
                ComputerTextBox.BackColor = Color.Red;
                PlayerTextBox.BackColor = Color.Green;
            }
            else if (ComHand == PlyHand)
            {
                MessageBox.Show("Tie Game");
            }
            PlayButton.Enabled = false;
            StartButton.Enabled = true;
            StartButton.Focus();
        }

        //Event Handlers--------------------------------------------------------------------------------------------------------------------
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Deck cardDeck = new Deck();
            for (int i = 0; i < 52; i++)
            {
                Card currentCard = cardDeck.Deal();
                if (i % 2 == 0 && i < 52)
                {
                    PlayerHand.Add(currentCard);
                }
                else
                {
                    ComputerHand.Add(currentCard);
                }
            }
            DefaultBack();
            Defaults();
            StartButton.Enabled = false;
            PlayButton.Enabled = true;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (back == true && war == false)
            {   
                Round();
                back = false;
            }
            else if (back == false && war == false)
            { 
                Image img = null;
                PlayerPictureBox2.Image = img;
                ComputerPictureBox2.Image = img;
                PlayerPictureBox3.Image = img;
                ComputerPictureBox3.Image = img;
                PlayerPictureBox4.Image = img;
                ComputerPictureBox4.Image = img;
                DefaultBack();
                back = true;
            }
            else
            {
                WarCycle();
            }
        }
    }
}
