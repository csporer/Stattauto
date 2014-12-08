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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUhrAn = new System.Windows.Forms.CheckBox();
            this.dtpUhrzeit = new System.Windows.Forms.DateTimePicker();
            this.Uhrzeit = new System.Windows.Forms.Timer(this.components);
            this.tresor1 = new Stattauto.Tresor();
            this.kundenkarte1 = new Stattauto.Kundenkarte();
            this.BtnXML = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnXML);
            this.groupBox1.Controls.Add(this.dtpUhrzeit);
            this.groupBox1.Controls.Add(this.cbUhrAn);
            this.groupBox1.Location = new System.Drawing.Point(231, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lokale Systemzeit";
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
            // Uhrzeit
            // 
            this.Uhrzeit.Interval = 1000;
            this.Uhrzeit.Tick += new System.EventHandler(this.Uhrzeit_Tick);
            // 
            // tresor1
            // 
            this.tresor1.AllowDrop = true;
            this.tresor1.Location = new System.Drawing.Point(37, 99);
            this.tresor1.Name = "tresor1";
            this.tresor1.Size = new System.Drawing.Size(273, 358);
            this.tresor1.Systemzeit = new System.DateTime(((long)(0)));
            this.tresor1.TabIndex = 1;
            this.tresor1.Text = "Tresor 1";
            // 
            // kundenkarte1
            // 
            this.kundenkarte1.KundenID = 1234;
            this.kundenkarte1.Location = new System.Drawing.Point(37, 12);
            this.kundenkarte1.Name = "kundenkarte1";
            this.kundenkarte1.PIN = 1111;
            this.kundenkarte1.Size = new System.Drawing.Size(107, 60);
            this.kundenkarte1.TabIndex = 0;
            this.kundenkarte1.Text = "Karte 1";
            // 
            // BtnXML
            // 
            this.BtnXML.Location = new System.Drawing.Point(141, 45);
            this.BtnXML.Name = "BtnXML";
            this.BtnXML.Size = new System.Drawing.Size(75, 23);
            this.BtnXML.TabIndex = 3;
            this.BtnXML.Text = "XML öffnen";
            this.BtnXML.UseVisualStyleBackColor = true;
            this.BtnXML.Click += new System.EventHandler(this.BtnXML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 518);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tresor1);
            this.Controls.Add(this.kundenkarte1);
            this.Name = "Form1";
            this.Text = "Demo Stattauto";
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
    }
}

