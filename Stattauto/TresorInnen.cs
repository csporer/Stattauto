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
        private bool _türreferenz;

        public TresorInnen()
        {
            InitializeComponent();
            LEDFarbe1 = LEDFarbe2 = LEDFarbe3 = Color.Red;
            Schluessel1 = Schluessel2 = Schluessel3 = StatusSchluessel.vorhanden;
        }

        public Color LEDFarbe1 { get; set; }
        public Color LEDFarbe2 { get; set; }
        public Color LEDFarbe3 { get; set; }

        public StatusSchluessel Schluessel1 { get; set; }
        public StatusSchluessel Schluessel2 { get; set; }
        public StatusSchluessel Schluessel3 { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int ledSize = 30;

            g.FillEllipse(new SolidBrush(LEDFarbe1), new Rectangle(new Point(btnSchlu1.Location.X + (btnSchlu1.Size.Width / 2) - ledSize / 2, btnSchlu1.Location.Y - 50), new Size(ledSize, ledSize)));
            g.FillEllipse(new SolidBrush(LEDFarbe2), new Rectangle(new Point(btnSchlu2.Location.X + (btnSchlu2.Size.Width / 2) - ledSize / 2, btnSchlu2.Location.Y - 50), new Size(ledSize, ledSize)));
            g.FillEllipse(new SolidBrush(LEDFarbe3), new Rectangle(new Point(btnSchlu3.Location.X + (btnSchlu3.Size.Width / 2) - ledSize / 2, btnSchlu3.Location.Y - 50), new Size(ledSize, ledSize)));

            lblSchlu1.Text = Schluessel1.ToString();
            lblSchlu2.Text = Schluessel2.ToString();
            lblSchlu3.Text = Schluessel3.ToString();
            base.OnPaint(e);
        }

        private void lblSchlu2_EnabledChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }



        private void btnSchlu1_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSchlu1.Checked)
            {
                Schluessel1 = StatusSchluessel.entnommen;
            }
            else
            {
                Schluessel1 = StatusSchluessel.vorhanden;
            }
        }

        private void btnSchlu2_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSchlu2.Checked)
            {
                Schluessel2 = StatusSchluessel.entnommen;
            }
            else
            {
                Schluessel2 = StatusSchluessel.vorhanden;
            }
        }

        private void btnSchlu3_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSchlu3.Checked)
            {
                Schluessel3 = StatusSchluessel.entnommen;
            }
            else
            {
                Schluessel3 = StatusSchluessel.vorhanden;
            }
        }

       
    }
    public enum StatusSchluessel
    {   
        vorhanden,
        entnommen        
    }
}
