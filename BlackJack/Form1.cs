using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form_jogo : Form
    {
        public Form_jogo(string jogador1, string jogador2)
        {
            InitializeComponent();
            btn_jogar_1.Enabled = true;
            btn_jogar_2.Enabled = false;
            btn_parar_1.Enabled = true;
            btn_parar_2.Enabled = false;
            nomeJogador1.Text = jogador1;
            nomeJogador2.Text = jogador2;
            pictureBoxResultado.Visible = false;
        }

        int Pontos_A = 0;
        int Pontos_B = 0;

        public void resultado()
        {
            if (Pontos_A <= 21 && Pontos_B <= 21)
            {
                if (Pontos_A == Pontos_B)
                {
                    lbl_Resultado.Text = "Empate!";
                    pictureBoxResultado.Image = Properties.Resources.Empate;
                    pictureBoxResultado.Visible = true;
                }
                else if (Pontos_A > Pontos_B)
                {
                    // Jogador que tiver mais pontos vence.
                    lbl_Resultado.Text = nomeJogador1.Text + " ganhou!";
                    pictureBoxResultado.Image = Properties.Resources.Ganhador;
                    pictureBoxResultado.Visible = true;
                }
                else
                {
                    lbl_Resultado.Text = nomeJogador2.Text + " ganhou!";
                    pictureBoxResultado.Image = Properties.Resources.Ganhador;
                    pictureBoxResultado.Visible = true;
                }
            }
            else
            {
                // Jogador que tiver menos ou igual a 21 pontos ganha.
                if (Pontos_A > 21 && Pontos_B <= 21)
                {
                    lbl_Resultado.Text = nomeJogador2.Text + " ganhou!";
                    pictureBoxResultado.Image = Properties.Resources.Ganhador;
                    pictureBoxResultado.Visible = true;
                }
                else if (Pontos_A <= 21 && Pontos_B > 21)
                {
                    lbl_Resultado.Text = nomeJogador1.Text + " ganhou!";
                    pictureBoxResultado.Image = Properties.Resources.Ganhador;
                    pictureBoxResultado.Visible = true;
                }
                else
                {
                    lbl_Resultado.Text = "Sem vencedor!";
                    pictureBoxResultado.Image = Properties.Resources.Perdedor;
                    pictureBoxResultado.Visible = true;
                }
            }

        }

        public void Jogada(PictureBox A, int jogador)
        {
            int x, total_pontos=0;
            Random sorteio = new Random();
            x = sorteio.Next(1, 14);


            switch (x)
            {
                case 1:     A.Image = Properties.Resources.ImagemA;    total_pontos += 1;     break;
                case 2:     A.Image = Properties.Resources.Imagem2;   total_pontos += 2;     break;
                case 3:     A.Image = Properties.Resources.Imagem3;   total_pontos += 3;     break;
                case 4:     A.Image = Properties.Resources.Imagem4;   total_pontos += 4;     break;
                case 5:     A.Image = Properties.Resources.Imagem5;   total_pontos += 5;     break;
                case 6:     A.Image = Properties.Resources.Imagem6;   total_pontos += 6;     break;
                case 7:     A.Image = Properties.Resources.Imagem7;   total_pontos += 7;     break;
                case 8:     A.Image = Properties.Resources.Imagem8;   total_pontos += 8;     break;
                case 9:     A.Image = Properties.Resources.Imagem9;   total_pontos += 9;     break;
                case 10:    A.Image = Properties.Resources.Imagem10;  total_pontos += 10;    break;
                case 11:    A.Image = Properties.Resources.ImagemJ;    total_pontos += 11;    break;
                case 12:    A.Image = Properties.Resources.ImagemQ;    total_pontos += 12;    break;
                case 13:    A.Image = Properties.Resources.ImagemK;    total_pontos += 13;    break;
            }

            if (jogador == 1)
                Pontos_A += total_pontos;
            else
                Pontos_B += total_pontos;
        }

            private void button1_Click(object sender, EventArgs e)
        {
            

            Jogada(pictureBox1, 1);
           

            if(Pontos_A <= 21)
            {   // JOGANDO
                lbl_Pontos_A.Text = Convert.ToString(Pontos_A);
                if(Pontos_A == 21)
                {
                    btn_jogar_1.Enabled = false;
                    btn_reiniciar.Enabled = true;
                }
            }
            else
            {   // PARTIDA PERDIDA
                lbl_Pontos_A.Text = Convert.ToString(Pontos_A);
                
                btn_jogar_1.Enabled = false;
                btn_parar_1.Enabled = false;

                btn_jogar_2.Enabled = true;
                btn_parar_2.Enabled = true;

                btn_reiniciar.Enabled = true;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Pontos_A = 0;
            Pontos_B = 0;
            btn_jogar_1.Enabled = true;
            btn_jogar_2.Enabled = false;
            btn_parar_1.Enabled = true;
            btn_parar_2.Enabled = false;

            btn_reiniciar.Enabled = false;
            lbl_Pontos_A.Text = "0";
            lbl_Pontos_B.Text = "0";
            lbl_Resultado.Text = "";
            pictureBoxResultado.Visible = false;

            pictureBox1.Image = Properties.Resources.BlackJack;
            pictureBox2.Image = Properties.Resources.BlackJack;

        }

        private void btn_jogar_2_Click(object sender, EventArgs e)
        {
            //  ESCOLHER AS CARTAS
            Jogada(pictureBox2, 2);

            if (Pontos_B <= 21)
            {   // JOGANDO
                lbl_Pontos_B.Text = Convert.ToString(Pontos_B);
                if (Pontos_B == 21)
                {
                    //lbl_Resultado.Text = "GANHOU!!!";
                    btn_jogar_2.Enabled = false;
                    btn_reiniciar.Enabled = true;
                    resultado();
                }
            }
            else
            {   // PARTIDA PERDIDA
                lbl_Pontos_B.Text = Convert.ToString(Pontos_B);

                btn_jogar_2.Enabled = false;
                btn_parar_2.Enabled = false;

                btn_jogar_2.Enabled = false;
                btn_parar_2.Enabled = false;

                resultado();
                btn_reiniciar.Enabled = true;


               
            }
        }

        private void btn_parar_1_Click(object sender, EventArgs e)
        {
            btn_jogar_1.Enabled = false;
            btn_parar_1.Enabled = false;
            btn_jogar_2.Enabled = true;
            btn_parar_2.Enabled = true;
        }

        private void btn_parar_2_Click(object sender, EventArgs e)
        {
            btn_jogar_2.Enabled = false;
            btn_parar_2.Enabled = false;
            btn_reiniciar.Enabled = true;
            resultado();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnMudarJog_Click(object sender, EventArgs e)
        {
            form_apresentacao novoJogo = new form_apresentacao();
            novoJogo.Show();
            this.Visible = false;
        }

        private void Form_jogo_Load(object sender, EventArgs e)
        {

        }
    }

}


