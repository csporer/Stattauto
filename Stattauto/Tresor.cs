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
        
        public Tresor()
        {
            this.Height = 200;
            this.Width = 300;
            this.AllowDrop = true;
            InitializeComponent();
            InitEigeneElemente();            
        }

        private void InitEigeneElemente()
        {
            //Eingabetextbox
            txteingabe.Parent = this;
            txteingabe.Location = new Point(this.Width / 2 - 10, 5);
            txteingabe.Visible = true;
            txteingabe.Enabled = false;

            //Button bestätigung PIN
            btnsubmit.Parent = this;
            btnsubmit.Location = new Point(this.Width / 2 - 2, 30);
            btnsubmit.Visible = true;
            btnsubmit.Text = "Bestätigen";
            btnsubmit.Enabled = false;
            btnsubmit.Click += btnsubmit_Click;
        
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
            g.DrawImage(Properties.Resources.Tresor, new Rectangle(0, 20, this.Width/2, this.Height / 2));
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF(0, 5));
            g.DrawString("Displayausgabe:" , this.Font, new SolidBrush(this.ForeColor), new PointF(0 , this.Height / 2 + 25));
            g.DrawString(AusgabeDisplay, this.Font, new SolidBrush(this.ForeColor), new PointF(0, this.Height / 2 + 40));
            g.DrawString("Debug: Gel. ID : " + GeleseneID, this.Font, new SolidBrush(this.ForeColor), new PointF(0, this.Height / 2 + 55));
            g.DrawString("Debug: Gel. PIN: " + GelesenePIN, this.Font, new SolidBrush(this.ForeColor), new PointF(0, this.Height / 2 + 70));
            
            if (TresorOffen)
            { 
                
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
