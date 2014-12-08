using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Stattauto
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {            
            
            InitializeComponent();
        }

        private void Uhrzeit_Tick(object sender, EventArgs e)
        {  
            tresor1.Systemzeit = dtpUhrzeit.Value = dtpUhrzeit.Value.AddSeconds(1);
            dtpUhrzeit.Refresh();
        }

       
        private void cbUhrAn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUhrAn.Checked)
            {
                Uhrzeit.Start();
            }
            else
            {
                Uhrzeit.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpUhrzeit.Value = DateTime.Now;
            Uhrzeit.Start();
        }

        private void dtpUhrzeit_ValueChanged(object sender, EventArgs e)
        {
            tresor1.Systemzeit = dtpUhrzeit.Value;
        }

        private void BtnXML_Click(object sender, EventArgs e)
        {
            Process editor = new Process();
            editor.StartInfo.FileName = Tresor.xmlPfad;
            editor.Start();
        }

      
              
    }
}
