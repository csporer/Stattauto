using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stattauto
{
    public partial class TresorInnen : UserControl
    {
        private Tresor _tresor = null;
        private Schlüsselerkennung _schluesselerkennung;
        private bool _entnahme = true;
    
       
        public TresorInnen()
        {
            InitializeComponent();
            LEDFarbe1 = LEDFarbe2 = LEDFarbe3 = Color.Red;
            Schluessel = new StatusSchluessel[3];        
        }

        public Color LEDFarbe1 { get; set; }
        public Color LEDFarbe2 { get; set; }
        public Color LEDFarbe3 { get; set; }

        public StatusSchluessel[] Schluessel { get; set; }       

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int ledSize = 30;

            g.FillEllipse(new SolidBrush(LEDFarbe1), new Rectangle(new Point(btnSchlu1.Location.X + (btnSchlu1.Size.Width / 2) - ledSize / 2, btnSchlu1.Location.Y - 50), new Size(ledSize, ledSize)));
            g.FillEllipse(new SolidBrush(LEDFarbe2), new Rectangle(new Point(btnSchlu2.Location.X + (btnSchlu2.Size.Width / 2) - ledSize / 2, btnSchlu2.Location.Y - 50), new Size(ledSize, ledSize)));
            g.FillEllipse(new SolidBrush(LEDFarbe3), new Rectangle(new Point(btnSchlu3.Location.X + (btnSchlu3.Size.Width / 2) - ledSize / 2, btnSchlu3.Location.Y - 50), new Size(ledSize, ledSize)));

            lblSchlu1.Text = Schluessel[0].ToString();
            lblSchlu2.Text = Schluessel[1].ToString();
            lblSchlu3.Text = Schluessel[2].ToString();
            base.OnPaint(e);
        }

        private void lblSchlu2_EnabledChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }


        public void SetTresor(Tresor tres)
        {
            _tresor = tres;
            _schluesselerkennung = new Schlüsselerkennung(_tresor);
        }

        public void TresorGeoeffnet()
        {
            if (Schluessel[_tresor.AktiveBuchung.VorgesehenesFahrzeug-1] == StatusSchluessel.vorhanden )
            {
                _tresor.SetDisplayText(Displaytext.Entnahme);
                _entnahme = true;
            }
            else
            {
                _tresor.SetDisplayText(Displaytext.Rueckgabe);
                _entnahme = false;
            }
            
        }

        public void TresorGeschlossen()
        {
            _schluesselerkennung.MerkeSchluesselStatus();
        }

        private void btnSchlu_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox _sender = (CheckBox)sender;
            StatusSchluessel status;
            

            if (_sender.Checked)
            {
                status = StatusSchluessel.entnommen; 
            }
            else
	        {
                status = StatusSchluessel.vorhanden;
	        }

            Schluessel[Convert.ToInt16(_sender.Tag)-1] = status;

            if(!_schluesselerkennung.RichtigeEntnahme())
            {
                _tresor.SetDisplayText(Displaytext.FalschEntnommen);
                StartPiep();
            }
            else
            {
                StopPiep();
                if (_tresor.AktiveBuchung.FahrzeugInGebrauch && Schluessel[_tresor.AktiveBuchung.VorgesehenesFahrzeug-1] == StatusSchluessel.entnommen)
                {
                    if(!_entnahme)
                        _tresor.SetDisplayText(Displaytext.Rueckgabe);
                }
                else if (!_tresor.AktiveBuchung.FahrzeugInGebrauch && Schluessel[_tresor.AktiveBuchung.VorgesehenesFahrzeug - 1] == StatusSchluessel.vorhanden)
                {
                    if (_entnahme)
                    {
                        _tresor.SetDisplayText(Displaytext.Entnahme);
                    }
                    
                }
                else
                    _tresor.SetDisplayText(Displaytext.Schließen);
            }
        }

        private void TimerEntnahme_Tick(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();           
        } 

        public void StartPiep()
        { 
            TimerEntnahme.Start(); 
        }

        public void StopPiep()
        {
            TimerEntnahme.Stop();
        }
    }

    public enum StatusSchluessel
    {   
        vorhanden,
        entnommen        
    }
}
