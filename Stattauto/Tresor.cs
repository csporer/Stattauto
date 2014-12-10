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
        private TextBox txteingabe = new TextBox();
        private Button btnsubmit = new Button();
        private Button btnschliessen = new Button();
        private Schlüsselerkennung _schluesselerkennung;
        private Buchungsliste Buchungen;
                
        public Tresor()
        {
            this.Height = 400;
            this.Width = 300;
            this.AllowDrop = true;            
            InitializeComponent();
            InitEigeneElemente();
            innenleben.SetTresor(this);
            _schluesselerkennung = new Schlüsselerkennung(this);
            SetDisplayText("Willkommen bei Stattauto!");
            //ErstelleStandardbuchungsliste();

            //Buchungen = XML.Load<Buchungsliste>(xmlPfad);
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF(0, 5));
            g.DrawImage(Properties.Resources.Tresor, new Rectangle(0, 40, 150, 150));

            //g.DrawString("Displayausgabe:", this.Font, new SolidBrush(this.ForeColor), new PointF(0, 200));
            //g.DrawString(AusgabeDisplay, this.Font, new SolidBrush(this.ForeColor), new PointF(0, 230));

            if (!TresorOffen)
            {
                g.DrawString("Tresor ist geschlossen", this.Font, new SolidBrush(System.Drawing.Color.Red), new PointF(0, 20));
            }
            else
            {
                g.DrawString("Tresor ist geöffnet", this.Font, new SolidBrush(System.Drawing.Color.Green), new PointF(0, 20));
                                
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
            SetDisplayText("Willkommen bei Stattauto!");
            //txteingabe.Enabled = false;
            //btnsubmit.Enabled = false;
            innenleben.StopPiep();
            this.Refresh();

            Buchungen.Buchungen.Remove(AktiveBuchung);

            if (RichtigerSchluesselStatus == StatusSchluessel.entnommen)
            {               
                AktiveBuchung.FahrzeugInGebrauch = true;                
            }
            else
            {                
                AktiveBuchung.FahrzeugInGebrauch = false;              
            }
            
            Buchungen.Buchungen.Add(AktiveBuchung);
            XML.Save<Buchungsliste>(Pfade.xmlPfad, Buchungen);
            if(Eingabefenster != null)
                Eingabefenster.UpdateListe();
        }

        void btnsubmit_Click(object sender, EventArgs e)
        {
            int parsing;
            if (int.TryParse(txteingabe.Text, out parsing))
            {
                EingabePIN = parsing;                
                if (EingabePIN == AktiveBuchung.PIN)
                {
                    switch (AktiveBuchung.VorgesehenesFahrzeug)
                    {
                        case 1:
                            innenleben.LEDFarbe1 = Color.Green;
                            innenleben.LEDFarbe2 = innenleben.LEDFarbe3 = Color.Red;
                            break;
                        case 2:
                            innenleben.LEDFarbe2 = Color.Green;
                            innenleben.LEDFarbe1 = innenleben.LEDFarbe3 = Color.Red;
                            break;
                        case 3:
                            innenleben.LEDFarbe3 = Color.Green;
                            innenleben.LEDFarbe2 = innenleben.LEDFarbe1 = Color.Red;
                            break;
                        default:
                            break;
                    }

                    TresorOffen = true;
                    SetDisplayText("Schlüssel entnehmen");
                    txteingabe.Enabled = false;
                    btnsubmit.Enabled = false;
                    TimerPin.Stop();
                }
                else
                {
                    SetDisplayText("Falsche PIN eingegeben");
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            else
            {
                txteingabe.Text = "Falsche Eingabe!";
                System.Media.SystemSounds.Hand.Play();
            }
            txteingabe.Text = string.Empty;
            this.Refresh();
        }

        #endregion

        public void SetDisplayText(string text)
        { display.UpdateText(text); }

        void txteingabe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                btnsubmit.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        #region DragDrop

        private void Tresor_DragEnter(object sender, DragEventArgs e)
        {
            if (!TresorOffen)
            {
                e.Effect = DragDropEffects.Copy;                               
            }
        }        

        private void Tresor_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Buchungen = XML.Load<Buchungsliste>(Pfade.xmlPfad);


                if (e.Data.GetDataPresent(typeof(Kundenkarte)))
                {
                    GeleseneID = ((Kundenkarte)e.Data.GetData(typeof(Kundenkarte))).KundenID;
                    GelesenePIN = ((Kundenkarte)e.Data.GetData(typeof(Kundenkarte))).PIN;

                    bool vergleich1, vergleich2;
                    foreach (Buchung buch in Buchungen.Buchungen)
                    {
                        vergleich1 = buch.EndeBuchung > Systemzeit;
                        vergleich2 = Systemzeit > buch.AnfangBuchung;
                        if (buch.NutzerID == GeleseneID && vergleich1  && vergleich2 && buch.TresorID == TresorID)
                        {
                            btnsubmit.Enabled = true;
                            txteingabe.Enabled = true;
                            AktiveBuchung = buch;
                            SetDisplayText("Bitte geben Sie ihren PIN ein...");
                            TimerPin.Start();
                            this.Refresh();
                            return;
                        }
                    }

                    SetDisplayText("Keine Buchung vorhanden!");
                }
            }
            catch (Exception exc)
            {
                Buchungen = null;                
                MessageBox.Show("XML Eingabe prüfen: \n" + exc.InnerException.Message.ToString());
            }
            

        }
        #endregion

        #region Parameter
        
        public int EingabePIN { get; private set; }

        public int GeleseneID { get; private set; }

        public bool TresorOffen { get; private set; }

        public int GelesenePIN { get; private set; }

        public int TresorID { get; set; }

        public DateTime Systemzeit { get; set; }

        public Buchung AktiveBuchung { get; private set; }

        public StatusSchluessel RichtigerSchluesselStatus { get; set; }

        public XMLEingabe Eingabefenster { get; set; }

        #endregion Parameter       

        private void TimerPin_Tick(object sender, EventArgs e)
        {
            SetDisplayText("Willkommen bei Stattauto!");
            txteingabe.Enabled = false;
            btnsubmit.Enabled = false;
            
            TimerPin.Stop();
            this.Refresh();
        }
                
    }
}
