using System;
using System.Windows.Forms;
using System.Drawing;

namespace Atividade1
{
    public class Tiro : Personagem
    {
        public Timer timer = new Timer();
        public int direcao = 0;
        public int speed = 55;
        public int dano = 10;
        public Personagem personagemAlvo; // O alvo que o tiro pode acertar

        public Tiro()
        {
            Width = 40;
            Height = 40;
            Load("fireball2.gif");

            timer = new Timer();
            timer.Interval = 25; // Define o intervalo do timer
            timer.Tick += (s, e) => Update(); // Liga o evento Tick ao método Update
            timer.Start(); // Inicia o timer
        }

        public void Update()
        {
            // Movimento do tiro baseado na direção
            Left += 10 * direcao;

            // Verifica se o tiro saiu da tela
            if (Left >= MainForm.fundo.Width || Left <= 0)
            {
                Destruir();
            }

            // Teste de colisão entre o tiro e o inimigo
            if (personagemAlvo.Bounds.IntersectsWith(this.Bounds))
            {
                // Se colidir, destrói o inimigo e o tiro
                (personagemAlvo as Inimigo).Destruir();
                Destruir();
            }
        }

        private void Destruir()
        {
            timer.Stop(); // Para o timer
            timer.Dispose(); // Libera o timer da memória
            MainForm.listaTiros.Items.Remove(this); // Remove o tiro da lista
            this.Dispose(); // Destrói o objeto tiro
        }
    }
}
