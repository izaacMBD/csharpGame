using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Atividade1
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		public static PictureBox fundo = new PictureBox();
		Heroi heroi = new Heroi();
		
		void MainFormLoad(object sender, EventArgs e)
		{
			fundo.Parent = this;
			fundo.Height = this.Height - 80;
			fundo.Width = this.Width;
			fundo.Load("cenario0.gif");
			fundo.SizeMode = PictureBoxSizeMode.StretchImage;
		}
		
		void MainFormKeyDown(Object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) 
			{
				heroi.MoveDir();
			}
			if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) 
			{
				heroi.MoveEsq();
			}
			if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) 
			{
				heroi.MoveBaixo();
			}
			if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) 
			{
				heroi.MoveCima();
			}
			
			
		}
	}
}
