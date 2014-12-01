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
    public partial class Display : UserControl
    {
        public Display()
        {
            InitializeComponent();
        }

        public string AnzeigeText { get; private set; }

        public void UpdateText(string Text)
        {
            AnzeigeText = Text;
            this.Refresh();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(AnzeigeText, new Font(this.Font.FontFamily,13), new SolidBrush(Color.Red), new PointF(5, this.Height / 2 - 10));
            base.OnPaint(e);
        }
    }
}
