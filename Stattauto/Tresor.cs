using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stattauto
{
    public partial class Tresor : Control
    {
        private TextBox txteingabe = new TextBox();
        private Button btnsubmit = new Button();
        private Button btnschliessen = new Button();
        
        
        public Tresor()
        {
            this.Height = 500;
            this.Width = 300;
            this.AllowDrop = true;
            AusgabeDisplay = "Willkommen bei Stattauto!";
            InitializeComponent();
            InitEigeneElemente();            
        }

        private void InitEigeneElemente()
        {
            //Eingabetextbox
            txteingabe.Parent = this;
            txteingabe.Location = new Point(this.Width / 2 +10,20);
            txteingabe.Visible = true;
            txteingabe.Enabled = false;

            //Button bestätigung PIN
            btnsubmit.Parent = this;
            btnsubmit.Location = new Point(this.Width / 2 +20, 50);
            btnsubmit.Visible = true;
            btnsubmit.Text = "Bestätigen";
            btnsubmit.Enabled = false;
            btnsubmit.Click += btnsubmit_Click;

            //Button Türe schließen
            btnschliessen.Parent = this;
            btnschliessen.Location = new Point(this.Width / 2 + 10,100);
            btnschliessen.Visible = false;
            btnschliessen.Text = "Tresor schließen";
            btnschliessen.Width = 100;            
            btnschliessen.Click += btnschliessen_Click;
        }

        void btnschliessen_Click(object sender, EventArgs e)
        {
            TresorOffen = false;
            innenleben.Enabled = false;
            btnschliessen.Hide();
            AusgabeDisplay = "Willkommen bei Stattauto!";
            this.Refresh();
        }

        void btnsubmit_Click(object sender, EventArgs e)
        {
            int parsing;
            if (int.TryParse(txteingabe.Text, out parsing))
            {
                EingabePIN = parsing;
                if (EingabePIN == GelesenePIN)
                {
                    TresorOffen = true;
                    AusgabeDisplay = "Schlüssel entnehmen";
                }
                else
                {
                    AusgabeDisplay = "Falsche PIN eingegeben";
                }
            }
            else
            {
                txteingabe.Text = "Falsche Eingabe!";
            }
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF(0, 5));
            g.DrawImage(Properties.Resources.Tresor, new Rectangle(0, 40, 150, 150));
            
            g.DrawString("Displayausgabe:" , this.Font, new SolidBrush(this.ForeColor), new PointF(0 , 200));
            g.DrawString(AusgabeDisplay, this.Font, new SolidBrush(this.ForeColor), new PointF(0, 230));
          
            if (!TresorOffen)
            {
                g.DrawString("Tresor ist geschlossen", this.Font, new SolidBrush(System.Drawing.Color.Red), new PointF(0, 20));
            }
            else
            {
                g.DrawString("Tresor ist geöffnet", this.Font, new SolidBrush(System.Drawing.Color.Green), new PointF(0, 20));
                
                innenleben.LEDFarbe2 = Color.Green;
                innenleben.Enabled = true;
                btnschliessen.Show();
            }
        }

        private void Tresor_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
           
        }

        public string AusgabeDisplay { get; private set; }

        public int EingabePIN { get; private set; }

        public int GeleseneID { get; private set; }

        public bool TresorOffen { get; private set; }

        public int GelesenePIN { get; private set; }

        private void Tresor_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Kundenkarte)))
            {
                btnsubmit.Enabled = true;
                txteingabe.Enabled = true;
                GeleseneID = ((Kundenkarte)e.Data.GetData(typeof(Kundenkarte))).KundenID;
                GelesenePIN = ((Kundenkarte)e.Data.GetData(typeof(Kundenkarte))).PIN;
                AusgabeDisplay = "Bitte geben Sie ihren PIN ein...";
                this.Refresh();
            }
        }
    }
}
