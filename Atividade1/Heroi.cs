using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Atividade1
{
    public class Heroi : Personagem
    {
        TiroInimigo tiroInimigo = new TiroInimigo();
        
        private bool heroiDerrotado = false;

        public Heroi()
        {
            Left = 50;
            Top = 100;
            speed = 20;
            Load("Gargoyle.gif");
            direcao = 1;
            hp = 100;
        }

        // ============================= métodos de movimento =================================//

        public void MoveDir()
        {
            Left += speed;

            if (direcao == -1)
            {
                direcao = 1;
                Load("Gargoyle.gif");
            }
        }

        public void MoveEsq()
        {
            Left -= speed;
            if (Left <= 0)
            {
                Left = 1000;
            }

            if (direcao == 1)
            {
                direcao = -1;
                Load("GargoyleEsq.gif");
            }
        }

        public void MoveCima()
        {
            Top -= speed;
            if (Top <= 0)
            {
                Top = 0;
            }
        }

        public void MoveBaixo()
        {
            Top += speed;
            if (Top >= 360)
            {
                Top = 360;
            }
        }

        // Método que recebe o dano do inimigo
        public void heroiRecebeDano(int dano)
        {
            // Reduz o HP do herói quando o inimigo atira
            hp -= dano;
            if (hp <= 0 && !heroiDerrotado)
            {
                hp = 0;
                heroiDerrotado = true; // Marca que o herói foi derrotado
                MessageBox.Show("O herói foi derrotado!");
                
                // Chama o método ResetarJogo da instância de MainForm
                MainForm mainForm = (MainForm)Application.OpenForms[0]; // Obtém a instância do MainForm
                mainForm.ResetarJogo(); // Chama o método para resetar o jogo
            }
        }
        
        // Método que reseta o estado do herói
        public void Resetar()
        {
            heroiDerrotado = false;
            hp = 100;
            Left = 50;
            Top = 100;
            Load("Gargoyle.gif");
        }
    }
}
