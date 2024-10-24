﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Atividade1
{
    public partial class MainForm : Form
    {
        const int MaxTiros = 6;
        int tirosDisponiveis = MaxTiros;
        Timer timerRecarga;
        Heroi heroi = new Heroi();
        public Inimigo inimigo = new Inimigo();
        
        public static PictureBox fundo = new PictureBox();        
		public static ListBox listaTiros = new ListBox();
		
        public MainForm()
        {
            InitializeComponent();
            InitializeProgressBar();
        }

		
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

            if (e.KeyCode == Keys.Space && tirosDisponiveis > 0)
            {
                // Cria a fireball e deixa-a na posição inicial
	            Tiro novoTiro = new Tiro();
	            novoTiro.Parent = MainForm.fundo;
	            novoTiro.Left = heroi.Left;
	            novoTiro.Top = heroi.Top + (heroi.Height / 3);
	            novoTiro.timer.Enabled = true;
	            novoTiro.direcao = heroi.direcao;
	            novoTiro.personagemAlvo = inimigo;
	            
                tirosDisponiveis--;
                
                UpdateProgressBar();
                
                if (tirosDisponiveis == 0)
                {
                    StartReload();
                }
            }
        }

        private void InitializeProgressBar()
        {
            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = "progressBar";
            progressBar.Maximum = MaxTiros;
            progressBar.Minimum = 0;
            progressBar.Value = tirosDisponiveis;
            progressBar.Location = new Point(10, this.Height - 60);
            progressBar.Width = 200;
            this.Controls.Add(progressBar);
        }

        private void UpdateProgressBar()
        {
            ProgressBar progressBar = (ProgressBar)this.Controls["progressBar"];
            progressBar.Value = tirosDisponiveis;
        }

        private void StartReload()
        {
            timerRecarga = new Timer();
            timerRecarga.Interval = 2000; // 1 segundo de recarga para cada tiro
            timerRecarga.Tick += TimerRecarga_Tick;
            timerRecarga.Start();
        }

        private void TimerRecarga_Tick(object sender, EventArgs e)
        {
            if (tirosDisponiveis < MaxTiros)
            {
                tirosDisponiveis++;
                UpdateProgressBar();
            }

            if (tirosDisponiveis == MaxTiros)
            {
                timerRecarga.Stop();
                timerRecarga.Dispose();
            }
        }
    }
}
