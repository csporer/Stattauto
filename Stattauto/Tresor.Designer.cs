using System.Drawing;
namespace Stattauto
{
    partial class Tresor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Tresor
            // 
            innenleben = new TresorInnen();
            this.Controls.Add(innenleben);
            this.innenleben.Location = new System.Drawing.Point(0, 250);
            this.innenleben.Enabled = false;
           
           
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Tresor_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Tresor_DragEnter);
            this.ResumeLayout(false);
            InitEigeneElemente();
        }

        
        private void InitEigeneElemente()
        {
            //Eingabetextbox
            txteingabe.Parent = this;
            txteingabe.Location = new Point(this.Width / 2 + 20, 20);
            txteingabe.Visible = true;
            txteingabe.Enabled = false;
            txteingabe.UseSystemPasswordChar = true;
            txteingabe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txteingabe.Width = btnsubmit.Width;
            txteingabe.MaxLength = 4;
            txteingabe.Font = new System.Drawing.Font(this.Font.FontFamily, 12f);

            //Button bestätigung PIN
            btnsubmit.Parent = this;
            btnsubmit.Location = new Point(this.Width / 2 + 20, 50);
            btnsubmit.Visible = true;
            btnsubmit.Text = "Bestätigen";
            btnsubmit.Enabled = false;
            btnsubmit.Click += btnsubmit_Click;

            //Button Türe schließen
            btnschliessen.Parent = this;
            btnschliessen.Location = new Point(this.Width / 2 + 10, 100);
            btnschliessen.Visible = false;
            btnschliessen.Text = "Tresor schließen";
            btnschliessen.Width = 100;
            btnschliessen.Click += btnschliessen_Click;
        }


        private TresorInnen innenleben;

    }
}
