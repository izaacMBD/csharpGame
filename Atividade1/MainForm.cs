using System;
using System.Drawing;
using System.Windows.Forms;

namespace Atividade1
{
    public partial class MainForm : Form
    {
        int cenario = 0;
    	const int MaxTiros = 6;
        int tirosDisponiveis = MaxTiros;
        Timer timerRecarga;
        
        public Timer timerAtaque = new Timer(); // Timer para o ataque do inimigo
        
        public Heroi heroi = new Heroi();
        public Inimigo inimigo = new Inimigo();

        
        public static PictureBox fundo = new PictureBox();
        public static ListBox listaTiros = new ListBox();
        
        public MainForm()
        {
            InitializeComponent();
            InitializeProgressBar();
            
            timerAtaque.Enabled = true;
            timerAtaque.Interval = 2000;
            timerAtaque.Tick += AtaqueInimigo_Tick;
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
                
                if (heroi.Left >= 1000 && cenario == 0)
	            {
	            	MainForm.fundo.Load("cenario1.gif");
	            	heroi.Left = 0;
	            	cenario += 1;
	            }
	            
	            if (heroi.Left >= 1000 && cenario == 1)
	            {
	            	MainForm.fundo.Load("cenario2.gif");
	            	heroi.Left = 0;
	            	cenario += 2;
	            }
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
                novoTiro.timerTiro.Enabled = true;
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

        // Método para resetar o jogo
        public void ResetarJogo()
        {
            // Resetar herói e inimigo
            heroi.Resetar();
            inimigo.Resetar();
        
            // Resetar o número de tiros disponíveis
            tirosDisponiveis = MaxTiros;
            ProgressBar progressBar = (ProgressBar)this.Controls["progressBar"];
            progressBar.Value = tirosDisponiveis;
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
            timerRecarga.Interval = 2000; // 2 segundos de recarga para cada tiro
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
        
        private void AtaqueInimigo_Tick(object sender, EventArgs e)
        {
            TiroInimigo tiroInimigo = new TiroInimigo();
            tiroInimigo.Parent = MainForm.fundo;
            tiroInimigo.Left = inimigo.Left;
            tiroInimigo.Top = inimigo.Top + (inimigo.Height / 2);
            tiroInimigo.timerTiroInimigo.Enabled = true;
            tiroInimigo.direcao = inimigo.direcao;
            tiroInimigo.personagemAlvo = heroi;
        }
    }
}
