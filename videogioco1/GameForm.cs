namespace videogioco1
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class GameForm : Form
    {
        

       
        // Timer per aggiornare lo schermo a intervalli regolari
        private Timer timer;

        // Coordinate e dimensioni del rettangolo
        private int x = 100, y = 100;
        private const int width = 20, height = 30;//width = 60, height = 20;//rettangolo
        private const int speed = 5;

        // Variabili booleane per il movimento
        private bool sinistra, destra, su, giu;

        private Image navicella;

        public GameForm()
        {
            InitializeComponent();

            navicella = Image.FromFile("img/navicella.png");

            // Migliora la qualità grafica evitando sfarfallii
            this.DoubleBuffered = true;

            // Imposta dimensioni e titolo della finestra
            this.Width = 800;
            this.Height = 600;
            this.Text = "Movimento con Tastiera";

            // Consente alla form di intercettare i tasti premuti
            this.KeyPreview = true;

            // Collegamento degli eventi
            this.Paint += new PaintEventHandler(Disegna);
            this.KeyDown += new KeyEventHandler(Premuto);
            this.KeyUp += new KeyEventHandler(Rilasciato);

            // Imposta e avvia il timer
            timer = new Timer();
            timer.Interval = 20; // 50 volte al secondo
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        // Disegna il rettangolo
        private void Disegna(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.FillRectangle(Brushes.Blue, x, y, width, height);
            g.DrawImage(navicella, x, y, width, height);
        }

        // Aggiorna la posizione in base ai tasti premuti
        private void Update(object sender, EventArgs e)
        {
            if (sinistra && x > 0) x -= speed;
            if (destra && x + width < ClientSize.Width) x += speed;
            if (su && y > 0) y -= speed;
            if (giu && y + height < ClientSize.Height) y += speed;

            // Chiede il ridisegno della finestra
            Invalidate();
        }

        // Imposta le variabili booleane quando si preme un tasto
        private void Premuto(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) sinistra = true;
            if (e.KeyCode == Keys.Right) destra = true;
            if (e.KeyCode == Keys.Up) su = true;
            if (e.KeyCode == Keys.Down) giu = true;
        }

        // Le reimposta a false quando il tasto viene rilasciato
        private void Rilasciato(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) sinistra = false;
            if (e.KeyCode == Keys.Right) destra = false;
            if (e.KeyCode == Keys.Up) su = false;
            if (e.KeyCode == Keys.Down) giu = false;
        }
    }
}
