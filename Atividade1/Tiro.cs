﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace Atividade1
{
    public class Tiro : Personagem
    {
    	public Tiro()
    	{
    		Width = 30;
    		Height = 30;
    		Load("fireball2.gif");

    		timerTiro = new Timer();
    		timerTiro.Interval = 25; // Define o intervalo do timer
    		timerTiro.Tick += Update; // Liga o evento Tick ao método Update
    		timerTiro.Start(); // Inicia o timer
    	}
    	
		public int direcao = 0;
    	public int speed = 55;
    	public int dano = 20;
    	public Personagem personagemAlvo; // O alvo que o tiro pode acertar
    	public Timer timerTiro = new Timer();
    	
    	public void Update(object sender, EventArgs e)
    	{
    		// Movimento do tiro baseado na direção
    		Left += speed * direcao;
    		
    		// Verifica se o tiro saiu da tela
    		if (Left >= MainForm.fundo.Width || Left <= 0)
    		{
    			Destruir();
    		}
    		
    		// Teste de colisão entre o tiro e o inimigo
    		if (personagemAlvo != null && personagemAlvo.Bounds.IntersectsWith(this.Bounds))
    		{
    			// Se colidir, reduz a vida do inimigo
    			(personagemAlvo as Inimigo).ReceberDano(dano);
    			Destruir(); // Destrói o tiro
    		}
    	}

        private void Destruir()
        {
            timerTiro.Stop(); // Para o timer
            timerTiro.Dispose(); // Libera o timer da memória
            MainForm.listaTiros.Items.Remove(this); // Remove o tiro da lista
            this.Dispose(); // Destrói o objeto tiro
        }
    }
}
