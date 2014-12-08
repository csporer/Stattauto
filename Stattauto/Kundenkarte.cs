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
    public partial class Kundenkarte : Control
    {       
        public Kundenkarte()
        {
            this.Height = 60;
            this.Width = 107;
            InitializeComponent();         
        }

       
        protected override void OnPaint(PaintEventArgs pe)
        {           
            base.OnPaint(pe);
           
            Graphics g = pe.Graphics;
            g.DrawImage(Properties.Resources.Karte, new Rectangle(0, 0, this.Width, this.Height));
            g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new PointF(10, 5));
            g.DrawString("ID : " + KundenID.ToString(),this.Font,new SolidBrush(this.ForeColor),new PointF(10,20));
            //g.DrawString("PIN: " + PIN.ToString(), this.Font, new SolidBrush(this.ForeColor), new PointF(10, 35));
        
        }

        public int KundenID { get;  set; }
        public int PIN { get;  set; }

        private void Kundenkarte_MouseDown(object sender, MouseEventArgs e)
        {
           this.DoDragDrop(this, DragDropEffects.Copy);
        }
    }
}
