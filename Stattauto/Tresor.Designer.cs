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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tresor));
            this.TimerPin = new System.Windows.Forms.Timer(this.components);
            this.innenleben = new Stattauto.TresorInnen();
            this.display = new Stattauto.Display();
            this.SuspendLayout();
            // 
            // TimerPin
            // 
            this.TimerPin.Interval = 5000;
            this.TimerPin.Tick += new System.EventHandler(this.TimerPin_Tick);
            // 
            // innenleben
            // 
            this.innenleben.Enabled = false;
            this.innenleben.LEDFarbe1 = System.Drawing.Color.Red;
            this.innenleben.LEDFarbe2 = System.Drawing.Color.Red;
            this.innenleben.LEDFarbe3 = System.Drawing.Color.Red;
            this.innenleben.Location = new System.Drawing.Point(0, 250);
            this.innenleben.Name = "innenleben";
            this.innenleben.Schluessel1 = Stattauto.StatusSchluessel.vorhanden;
            this.innenleben.Schluessel2 = Stattauto.StatusSchluessel.vorhanden;
            this.innenleben.Schluessel3 = Stattauto.StatusSchluessel.vorhanden;
            this.innenleben.Size = new System.Drawing.Size(248, 119);
            this.innenleben.TabIndex = 0;
            // 
            // display
            // 
            this.display.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("display.BackgroundImage")));
            this.display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.display.Location = new System.Drawing.Point(0, 0);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(352, 39);
            this.display.TabIndex = 0;
            this.display.Textfarbe = System.Drawing.Color.Empty;
            // 
            // Tresor
            // 
            this.Controls.Add(this.innenleben);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Tresor_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Tresor_DragEnter);
            this.ResumeLayout(false);

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
            txteingabe.KeyDown += txteingabe_KeyDown;

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

            //Display
            display.Parent = this;
            display.Location = new Point(0, 200);
            display.Visible = true;
            display.Textfarbe = Color.White;
        }

       
        private TresorInnen innenleben;
        private Display display;
        private System.Windows.Forms.Timer TimerPin;

    }
}
