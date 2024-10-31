using System;
using System.Windows.Forms;
using System.Drawing;

namespace Atividade1
{
    public class TiroInimigo : Personagem
    {
    	public TiroInimigo()
    	{
    		Width = 30;
    		Height = 30;
    		Load("forceball.gif");

    		timerTiroInimigo = new Timer();
    		timerTiroInimigo.Interval = 25; // Define o intervalo do timer
    		timerTiroInimigo.Tick += Forceball; // Liga o evento Tick ao método Update
    		timerTiroInimigo.Start(); // Inicia o timer
    	}
    	
		public int direcao = 0;
    	public int speed = 55;
    	public int dano = 100;
    	public Personagem personagemAlvo; // O alvo que o tiro pode acertar
    	public Timer timerTiroInimigo = new Timer();
    	
    	public void Forceball(object sender, EventArgs e)
		{
    		Left += 5 * direcao;
    		
    		// Verifica se o tiro saiu da tela
    		if (Left >= MainForm.fundo.Width || Left <= 0)
    		{
    			Destruir();
    		}
    		
    		// Teste de colisão entre o tiro e o inimigo
    		if (personagemAlvo != null && personagemAlvo.Bounds.IntersectsWith(this.Bounds))
    		{
    			// Se colidir, reduz a vida do inimigo
    			(personagemAlvo as Heroi).heroiRecebeDano(dano);
    			Destruir(); // Destrói o tiro
    		}
		}

        private void Destruir()
        {
            timerTiroInimigo.Stop(); // Para o timer
            timerTiroInimigo.Dispose(); // Libera o timer da memória
            MainForm.listaTiros.Items.Remove(this); // Remove o tiro da lista
            this.Dispose(); // Destrói o objeto tiro
        }
    }
}
