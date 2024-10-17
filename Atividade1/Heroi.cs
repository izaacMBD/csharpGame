using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Atividade1
{
    public class Heroi : Personagem
    {

        public Heroi()
        {
            Left = 50;
            Top = 100;
            speed = 20;
            Load("Gargoyle.gif");
            direcao = 1;

        }

        // ============================= métodos de movimento =================================//

        public void MoveDir()
        {
            Left += speed;
            if (Left >= 1000)
            {
                Left = 0;
            }

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

        public void FireBall()
        {
            // Cria a fireball e deixa-a na posição inicial
            Tiro novoTiro = new Tiro();
            
            novoTiro.Parent = MainForm.fundo;
            
            novoTiro.Left = Left;
            novoTiro.Top = this.Top + (this.Height / 3);
            
            novoTiro.timer.Enabled = true;
            
            novoTiro.direcao = direcao;
        }
    }
}