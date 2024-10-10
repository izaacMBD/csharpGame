using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Atividade1
{
    public class Tiro : Personagem
    {
        public Timer timer;
        public static List<Tiro> tiros = new List<Tiro>(); // Lista para armazenar os tiros

        public Tiro()
        {
            Width = 40;
            Height = 40;
            Load("fireball2.gif");

            timer = new Timer();
            timer.Interval = 25; // Define o intervalo do timer
            timer.Tick += UpdateTiros; // Adiciona o evento Tick
            timer.Start(); // Inicia o timer

            tiros.Add(this); // Adiciona o tiro à lista
        }

        public void Update()
        {
            Left += 10; // Move o tiro para frente
            if (Left >= 1000) // Se o tiro ultrapassar a tela
            {
                Visible = false; // Faz o tiro desaparecer
                timer.Enabled = false; // Desativa o timer
            }
        }

        private void UpdateTiros(object sender, EventArgs e)
        {
            for (int i = tiros.Count - 1; i >= 0; i--)
            {
                var tiro = tiros[i];
                tiro.Update(); // Atualiza cada tiro

                // Remove tiros que saíram da tela
                if (!tiro.Visible)
                {
                    tiros.RemoveAt(i);
                }
            }
        }
    }
}
