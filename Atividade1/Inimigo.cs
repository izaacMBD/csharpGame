﻿/*
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
		
		public Inimigo()
		{
			Height = 130;
			Width = 150;
			Left = 600;
            Top = 100;
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
		
		public void Destruir()
		{
			timerMovimento.Enabled = false;
			Left = 5900;
			this.Dispose();
		}
	}
}