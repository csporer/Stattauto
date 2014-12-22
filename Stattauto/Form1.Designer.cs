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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnXML = new System.Windows.Forms.Button();
            this.dtpUhrzeit = new System.Windows.Forms.DateTimePicker();
            this.cbUhrAn = new System.Windows.Forms.CheckBox();
            this.Uhrzeit = new System.Windows.Forms.Timer(this.components);
            this.tresor2 = new Stattauto.Tresor();
            this.kundenkarte3 = new Stattauto.Kundenkarte();
            this.kundenkarte2 = new Stattauto.Kundenkarte();
            this.tresor1 = new Stattauto.Tresor();
            this.kundenkarte1 = new Stattauto.Kundenkarte();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnXML);
            this.groupBox1.Controls.Add(this.dtpUhrzeit);
            this.groupBox1.Controls.Add(this.cbUhrAn);
            this.groupBox1.Location = new System.Drawing.Point(427, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lokale Systemzeit";
            // 
            // BtnXML
            // 
            this.BtnXML.Location = new System.Drawing.Point(131, 45);
            this.BtnXML.Name = "BtnXML";
            this.BtnXML.Size = new System.Drawing.Size(85, 23);
            this.BtnXML.TabIndex = 3;
            this.BtnXML.Text = "Buchungsliste";
            this.BtnXML.UseVisualStyleBackColor = true;
            this.BtnXML.Click += new System.EventHandler(this.BtnXML_Click);
            // 
            // dtpUhrzeit
            // 
            this.dtpUhrzeit.CustomFormat = "dd.MM.yyyy  HH:mm:ss";
            this.dtpUhrzeit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUhrzeit.Location = new System.Drawing.Point(7, 20);
            this.dtpUhrzeit.Name = "dtpUhrzeit";
            this.dtpUhrzeit.Size = new System.Drawing.Size(144, 20);
            this.dtpUhrzeit.TabIndex = 1;
            this.dtpUhrzeit.ValueChanged += new System.EventHandler(this.dtpUhrzeit_ValueChanged);
            // 
            // cbUhrAn
            // 
            this.cbUhrAn.AutoSize = true;
            this.cbUhrAn.Checked = true;
            this.cbUhrAn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUhrAn.Location = new System.Drawing.Point(7, 46);
            this.cbUhrAn.Name = "cbUhrAn";
            this.cbUhrAn.Size = new System.Drawing.Size(103, 17);
            this.cbUhrAn.TabIndex = 0;
            this.cbUhrAn.Text = "Uhr weiterlaufen";
            this.cbUhrAn.UseVisualStyleBackColor = true;
            this.cbUhrAn.CheckedChanged += new System.EventHandler(this.cbUhrAn_CheckedChanged);
            // 
            // Uhrzeit
            // 
            this.Uhrzeit.Interval = 1000;
            this.Uhrzeit.Tick += new System.EventHandler(this.Uhrzeit_Tick);
            // 
            // tresor2
            // 
            this.tresor2.AllowDrop = true;
            this.tresor2.Eingabefenster = null;
            this.tresor2.Location = new System.Drawing.Point(407, 99);
            this.tresor2.Name = "tresor2";
            this.tresor2.RichtigerSchluesselStatus = Stattauto.StatusSchluessel.vorhanden;
            this.tresor2.Size = new System.Drawing.Size(300, 400);
            this.tresor2.Systemzeit = new System.DateTime(((long)(0)));
            this.tresor2.TabIndex = 5;
            this.tresor2.Text = "Tresor 2";
            this.tresor2.TresorID = 2;
            // 
            // kundenkarte3
            // 
            this.kundenkarte3.KundenID = 3000;
            this.kundenkarte3.Location = new System.Drawing.Point(294, 12);
            this.kundenkarte3.Name = "kundenkarte3";
            this.kundenkarte3.PIN = 0;
            this.kundenkarte3.Size = new System.Drawing.Size(107, 60);
            this.kundenkarte3.TabIndex = 4;
            this.kundenkarte3.Text = "Karte 3";
            // 
            // kundenkarte2
            // 
            this.kundenkarte2.KundenID = 2000;
            this.kundenkarte2.Location = new System.Drawing.Point(167, 12);
            this.kundenkarte2.Name = "kundenkarte2";
            this.kundenkarte2.PIN = 0;
            this.kundenkarte2.Size = new System.Drawing.Size(107, 60);
            this.kundenkarte2.TabIndex = 3;
            this.kundenkarte2.Text = "Karte 2";
            // 
            // tresor1
            // 
            this.tresor1.AllowDrop = true;
            this.tresor1.Eingabefenster = null;
            this.tresor1.Location = new System.Drawing.Point(37, 99);
            this.tresor1.Name = "tresor1";
            this.tresor1.RichtigerSchluesselStatus = Stattauto.StatusSchluessel.vorhanden;
            this.tresor1.Size = new System.Drawing.Size(300, 400);
            this.tresor1.Systemzeit = new System.DateTime(((long)(0)));
            this.tresor1.TabIndex = 1;
            this.tresor1.Text = "Tresor 1";
            this.tresor1.TresorID = 1;
            // 
            // kundenkarte1
            // 
            this.kundenkarte1.KundenID = 1000;
            this.kundenkarte1.Location = new System.Drawing.Point(37, 12);
            this.kundenkarte1.Name = "kundenkarte1";
            this.kundenkarte1.PIN = 1000;
            this.kundenkarte1.Size = new System.Drawing.Size(107, 60);
            this.kundenkarte1.TabIndex = 0;
            this.kundenkarte1.Text = "Karte 1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(736, 518);
            this.Controls.Add(this.tresor2);
            this.Controls.Add(this.kundenkarte3);
            this.Controls.Add(this.kundenkarte2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tresor1);
            this.Controls.Add(this.kundenkarte1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "C-Technology Stattauto";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Kundenkarte kundenkarte1;
        private Tresor tresor1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpUhrzeit;
        private System.Windows.Forms.CheckBox cbUhrAn;
        private System.Windows.Forms.Timer Uhrzeit;
        private System.Windows.Forms.Button BtnXML;
        private Kundenkarte kundenkarte2;
        private Kundenkarte kundenkarte3;
        private Tresor tresor2;
    }
}

