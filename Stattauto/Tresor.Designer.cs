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
            this._innenleben = new Stattauto.TresorInnen();
            this.display = new Stattauto.Display();
            this.TimerKeineBuchung = new System.Windows.Forms.Timer(this.components);
            this.TimerTresoroffen = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimerPin
            // 
            this.TimerPin.Interval = 10000;
            this.TimerPin.Tag = "Pin";
            this.TimerPin.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // _innenleben
            // 
            this._innenleben.Enabled = false;
            this._innenleben.LEDFarbe1 = System.Drawing.Color.Red;
            this._innenleben.LEDFarbe2 = System.Drawing.Color.Red;
            this._innenleben.LEDFarbe3 = System.Drawing.Color.Red;
            this._innenleben.Location = new System.Drawing.Point(0, 250);
            this._innenleben.Name = "_innenleben";
            this._innenleben.Schluessel = new Stattauto.StatusSchluessel[] {
        Stattauto.StatusSchluessel.vorhanden,
        Stattauto.StatusSchluessel.vorhanden,
        Stattauto.StatusSchluessel.vorhanden};
            this._innenleben.Size = new System.Drawing.Size(248, 119);
            this._innenleben.TabIndex = 0;
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
            // TimerKeineBuchung
            // 
            this.TimerKeineBuchung.Interval = 10000;
            this.TimerKeineBuchung.Tag = "KeineBuchung";
            this.TimerKeineBuchung.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // TimerTresoroffen
            // 
            this.TimerTresoroffen.Interval = 30000;
            this.TimerTresoroffen.Tick += new System.EventHandler(this.TimerTresoroffen_Tick);
            // 
            // Tresor
            // 
            this.Controls.Add(this._innenleben);
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

       
        private TresorInnen _innenleben;
        private Display display;
        private System.Windows.Forms.Timer TimerPin;
        private System.Windows.Forms.Timer TimerKeineBuchung;
        private System.Windows.Forms.Timer TimerTresoroffen;

    }
}
