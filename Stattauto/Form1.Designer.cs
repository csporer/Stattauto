namespace Stattauto
{
    partial class Form1
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tresor1 = new Stattauto.Tresor();
            this.kundenkarte1 = new Stattauto.Kundenkarte();
            this.SuspendLayout();
            // 
            // tresor1
            // 
            this.tresor1.AllowDrop = true;
            this.tresor1.Location = new System.Drawing.Point(37, 99);
            this.tresor1.Name = "tresor1";
            this.tresor1.Size = new System.Drawing.Size(273, 358);
            this.tresor1.TabIndex = 1;
            this.tresor1.Text = "Tresor 1";
            // 
            // kundenkarte1
            // 
            this.kundenkarte1.KundenID = 1234;
            this.kundenkarte1.Location = new System.Drawing.Point(37, 24);
            this.kundenkarte1.Name = "kundenkarte1";
            this.kundenkarte1.PIN = 1111;
            this.kundenkarte1.Size = new System.Drawing.Size(107, 60);
            this.kundenkarte1.TabIndex = 0;
            this.kundenkarte1.Text = "Karte 1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 518);
            this.Controls.Add(this.tresor1);
            this.Controls.Add(this.kundenkarte1);
            this.Name = "Form1";
            this.Text = "Demo Stattauto";
            this.ResumeLayout(false);

        }

        #endregion

        private Kundenkarte kundenkarte1;
        private Tresor tresor1;





    }
}

