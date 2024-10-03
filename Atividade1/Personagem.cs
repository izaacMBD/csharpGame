using System;
using System.Windows.Forms;
using System.Drawing;

namespace Atividade1
{
	public class Personagem : PictureBox
	{
		public Personagem()
		{
			Width =80;
			Height =80;
			SizeMode =PictureBoxSizeMode.StretchImage;
			BackColor =Color.Transparent;
			Parent = MainForm.fundo;
		}
		
		public int defesa = 15;
		public int ataque = 15;
//		public int xp = 0;
		public int hp = 100;
		public int speed = 20;
		public int direcao = 1;
			 
		
	}
}
