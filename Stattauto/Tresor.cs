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
        private Buchungsliste _buchungen;
                
        public Tresor()
        {
            this.Height = 400;
            this.Width = 300;
            this.AllowDrop = true;            
            InitializeComponent();
            InitEigeneElemente();
            _innenleben.SetTresor(this);            
            SetDisplayText(Displaytext.Wilkommen);            
            if (!File.Exists(Pfade.xmlPfad))
	        {
		        XMLEingabe.ErstelleStandardbuchungsliste();
	        }
            for (int i = 0; i < 3; i++)
            {
                this._innenleben.Schluessel[i] = Stattauto.StatusSchluessel.vorhanden;
            }  
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
                                
                _innenleben.Enabled = true;
                btnschliessen.Show();
            }
        }

        #region Buttons

        void btnschliessen_Click(object sender, EventArgs e)
        {
            SchliesseTresor();
            _innenleben.Enabled = false;
            btnschliessen.Hide();            
            SetDisplayText(Displaytext.Wilkommen);
            //txteingabe.Enabled = false;
            //btnsubmit.Enabled = false;
            _innenleben.StopPiep();
            this.Refresh();

            _buchungen.Buchungen.Remove(AktiveBuchung);

            if (RichtigerSchluesselStatus == StatusSchluessel.entnommen)
            {               
                AktiveBuchung.FahrzeugInGebrauch = true;                
            }
            else
            {                
                AktiveBuchung.FahrzeugInGebrauch = false;              
            }
            
            _buchungen.Buchungen.Add(AktiveBuchung);
            XML.Save<Buchungsliste>(Pfade.xmlPfad, _buchungen);
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
                            _innenleben.LEDFarbe1 = Color.Green;
                            _innenleben.LEDFarbe2 = _innenleben.LEDFarbe3 = Color.Red;
                            break;
                        case 2:
                            _innenleben.LEDFarbe2 = Color.Green;
                            _innenleben.LEDFarbe1 = _innenleben.LEDFarbe3 = Color.Red;
                            break;
                        case 3:
                            _innenleben.LEDFarbe3 = Color.Green;
                            _innenleben.LEDFarbe2 = _innenleben.LEDFarbe1 = Color.Red;
                            break;
                        default:
                            break;
                    }

                    OeffneTresor();
                    EnablePin(false);
                    TimerPin.Stop();
                }
                else
                {
                    SetDisplayText(Displaytext.FalscherPin);
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

        private void EnablePin(bool enable)
        {
            txteingabe.Enabled = btnsubmit.Enabled = enable;
            if (!enable)
            {
                txteingabe.Text = string.Empty;
            }           
        }

        public void SetDisplayText(string text)
        { display.UpdateText(text); }

        private void OeffneTresor()
        {
            TimerPin.Stop();
            TimerKeineBuchung.Stop();
            TresorOffen = true;
            TimerTresoroffen.Start();
            _innenleben.TresorGeoeffnet();
        }

        private void SchliesseTresor()
        {
            TresorOffen = false;
            TimerTresoroffen.Stop();            
            _innenleben.StopPiep();
            _innenleben.TresorGeschlossen();
        }

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
                _buchungen = XML.Load<Buchungsliste>(Pfade.xmlPfad);
                TimerPin.Stop();
                TimerKeineBuchung.Stop();

                if (e.Data.GetDataPresent(typeof(Kundenkarte)))
                {
                    GeleseneID = ((Kundenkarte)e.Data.GetData(typeof(Kundenkarte))).KundenID;
                    GelesenePIN = ((Kundenkarte)e.Data.GetData(typeof(Kundenkarte))).PIN;

                    bool startZeit, endZeit;
                    foreach (Buchung buch in _buchungen.Buchungen)
                    {
                        endZeit = buch.EndeBuchung > Systemzeit;
                        startZeit = Systemzeit > buch.AnfangBuchung;
                        if (buch.FahrzeugInGebrauch)
                        {
                            endZeit = startZeit = true;
                        }

                        if (buch.NutzerID == GeleseneID && startZeit && endZeit && buch.TresorID == TresorID)
                        {
                            EnablePin(true);
                            AktiveBuchung = buch;
                            SetDisplayText(Displaytext.PINeingabe);
                            TimerPin.Start();
                            this.Refresh();
                            return;
                        }
                    }

                    TimerKeineBuchung.Start();
                    SetDisplayText(Displaytext.KeineBuchung);
                    EnablePin(false);
                }
            }
            catch (Exception exc)
            {
                _buchungen = null;                
                MessageBox.Show("XML Eingabe prüfen: \n" + exc.Message.ToString());
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            SetDisplayText(Displaytext.Wilkommen);
            EnablePin(false);
            if (((Timer)sender).Tag.ToString() == "Pin")
            {
                TimerPin.Stop();
            }
            else
	        {
                TimerKeineBuchung.Stop();
	        }
            
            this.Refresh();
        }

        private void TimerTresoroffen_Tick(object sender, EventArgs e)
        {
            _innenleben.StartPiep();
        }
    
    }
}
