using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stattauto
{
    public partial class Tresor : Control
    {
        private string xmlPfad = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Buchungen.xml");
        private TextBox txteingabe = new TextBox();
        private Button btnsubmit = new Button();
        private Button btnschliessen = new Button();
        private Schlüsselerkennung _schluesselerkennung;
        private Buchungsliste Buchungen;
        
        
        public Tresor()
        {
            this.Height = 500;
            this.Width = 300;
            this.AllowDrop = true;
            AusgabeDisplay = "Willkommen bei Stattauto!";
            InitializeComponent();
            innenleben.SetTresor(this);
            _schluesselerkennung = new Schlüsselerkennung(this);
            //ErstelleStandardbuchungsliste();

            Buchungen = XML.Load<Buchungsliste>(xmlPfad);
        }

        private void ErstelleStandardbuchungsliste()
        {
            Buchung buch1 = new Buchung(1000, 1111, new DateTime(2014, 11, 30, 15, 00, 00), new DateTime(2014, 11, 30, 20, 00, 00), 1, false);
            Buchung buch2 = new Buchung(2000, 2222, new DateTime(2014, 11, 30, 18, 00, 00), new DateTime(2014, 11, 30, 19, 00, 00), 2, false);

            List<Buchung> Buchungen = new List<Buchung>();
            Buchungen.Add(buch1);
            Buchungen.Add(buch2);

            Buchungsliste list = new Buchungsliste(Buchungen);

            XML.Save<Buchungsliste>(xmlPfad, list);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF(0, 5));
            g.DrawImage(Properties.Resources.Tresor, new Rectangle(0, 40, 150, 150));

            g.DrawString("Displayausgabe:", this.Font, new SolidBrush(this.ForeColor), new PointF(0, 200));
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

        #region Buttons

        void btnschliessen_Click(object sender, EventArgs e)
        {
            TresorOffen = false;
            innenleben.Enabled = false;
            btnschliessen.Hide();
            AusgabeDisplay = "Willkommen bei Stattauto!";
            txteingabe.Enabled = false;
            btnsubmit.Enabled = false;
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
            txteingabe.Text = string.Empty;
            this.Refresh();
        }

        #endregion

        #region DragDrop

        private void Tresor_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }        

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
        #endregion

        #region Parameter
        public string AusgabeDisplay { get; set; }

        public int EingabePIN { get; private set; }

        public int GeleseneID { get; private set; }

        public bool TresorOffen { get; private set; }

        public int GelesenePIN { get; private set; }
        #endregion Parameter       
    }
}
