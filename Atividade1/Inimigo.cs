/*
 * Created by SharpDevelop.
 * User: aluno
 * Date: 24/10/2024
 * Time: 19:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Atividade1
{
	
	public class Inimigo : Personagem
	{
		int direcaoVertical = 1;
		public Timer timerMovimento = new Timer();
		public int mortesInimigo = 0;
		
		
		
		public Inimigo()
		{
			Height = 200;
			Width = 220;
			Left = 600;
            Top = 100;
            speed = 20;
            hp = 500;
            Load("dragonEsq2.gif");
            direcao = -1;
            
            timerMovimento.Enabled = true;
            timerMovimento.Interval = 80;
            timerMovimento.Tick += Movimento;
            
		}
		
		private void Movimento(object sender, EventArgs e)
		{
			Top += speed * direcaoVertical;
			
			if(Top >= 340)
			{
				direcaoVertical = -1;
			}
			if(Top <= -40)
			{
				direcaoVertical = 1;
			}
		}
		
		
		
		public void ReceberDano(int dano)
		{
			hp -= dano; // Reduz a vida do inimigo
			if (hp <= 0)
			{
				hp = 0;
				Destruir();
				mortesInimigo += 1;
				
			}
		}
		
		public void Destruir()
		{
			timerMovimento.Enabled = false;
			Left = 5900;
			this.Dispose();
		}
		
		public void Resetar()
	    {
	        hp = 100;
	        Left = 600;
	        Top = 100;
	        Load("dragonEsq2.gif");
	        timerMovimento.Enabled = true;
	    }
	}
}
