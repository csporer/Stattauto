namespace Stattauto
{
    partial class TresorInnen
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSchlu1 = new System.Windows.Forms.Label();
            this.lblSchlu2 = new System.Windows.Forms.Label();
            this.lblSchlu3 = new System.Windows.Forms.Label();
            this.btnSchlu1 = new System.Windows.Forms.CheckBox();
            this.btnSchlu2 = new System.Windows.Forms.CheckBox();
            this.btnSchlu3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSchlu1
            // 
            this.lblSchlu1.AutoSize = true;
            this.lblSchlu1.Location = new System.Drawing.Point(3, 87);
            this.lblSchlu1.Name = "lblSchlu1";
            this.lblSchlu1.Size = new System.Drawing.Size(35, 13);
            this.lblSchlu1.TabIndex = 3;
            this.lblSchlu1.Text = "label1";
            // 
            // lblSchlu2
            // 
            this.lblSchlu2.AutoSize = true;
            this.lblSchlu2.Location = new System.Drawing.Point(81, 87);
            this.lblSchlu2.Name = "lblSchlu2";
            this.lblSchlu2.Size = new System.Drawing.Size(35, 13);
            this.lblSchlu2.TabIndex = 4;
            this.lblSchlu2.Text = "label2";
            this.lblSchlu2.EnabledChanged += new System.EventHandler(this.lblSchlu2_EnabledChanged);
            // 
            // lblSchlu3
            // 
            this.lblSchlu3.AutoSize = true;
            this.lblSchlu3.Location = new System.Drawing.Point(162, 87);
            this.lblSchlu3.Name = "lblSchlu3";
            this.lblSchlu3.Size = new System.Drawing.Size(35, 13);
            this.lblSchlu3.TabIndex = 5;
            this.lblSchlu3.Text = "label3";
            // 
            // btnSchlu1
            // 
            this.btnSchlu1.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSchlu1.AutoSize = true;
            this.btnSchlu1.Location = new System.Drawing.Point(6, 61);
            this.btnSchlu1.Name = "btnSchlu1";
            this.btnSchlu1.Size = new System.Drawing.Size(71, 23);
            this.btnSchlu1.TabIndex = 7;
            this.btnSchlu1.Text = "Schlüssel 1";
            this.btnSchlu1.UseVisualStyleBackColor = true;
            this.btnSchlu1.CheckedChanged += new System.EventHandler(this.btnSchlu1_CheckedChanged);
            // 
            // btnSchlu2
            // 
            this.btnSchlu2.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSchlu2.AutoSize = true;
            this.btnSchlu2.Location = new System.Drawing.Point(83, 61);
            this.btnSchlu2.Name = "btnSchlu2";
            this.btnSchlu2.Size = new System.Drawing.Size(71, 23);
            this.btnSchlu2.TabIndex = 8;
            this.btnSchlu2.Text = "Schlüssel 2";
            this.btnSchlu2.UseVisualStyleBackColor = true;
            this.btnSchlu2.CheckedChanged += new System.EventHandler(this.btnSchlu2_CheckedChanged);
            // 
            // btnSchlu3
            // 
            this.btnSchlu3.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSchlu3.AutoSize = true;
            this.btnSchlu3.Location = new System.Drawing.Point(160, 61);
            this.btnSchlu3.Name = "btnSchlu3";
            this.btnSchlu3.Size = new System.Drawing.Size(71, 23);
            this.btnSchlu3.TabIndex = 9;
            this.btnSchlu3.Text = "Schlüssel 3";
            this.btnSchlu3.UseVisualStyleBackColor = true;
            this.btnSchlu3.CheckedChanged += new System.EventHandler(this.btnSchlu3_CheckedChanged);
            // 
            // TresorInnen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSchlu3);
            this.Controls.Add(this.btnSchlu2);
            this.Controls.Add(this.btnSchlu1);
            this.Controls.Add(this.lblSchlu3);
            this.Controls.Add(this.lblSchlu2);
            this.Controls.Add(this.lblSchlu1);
            this.Name = "TresorInnen";
            this.Size = new System.Drawing.Size(248, 119);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSchlu1;
        private System.Windows.Forms.Label lblSchlu2;
        private System.Windows.Forms.Label lblSchlu3;
        private System.Windows.Forms.CheckBox btnSchlu1;
        private System.Windows.Forms.CheckBox btnSchlu2;
        private System.Windows.Forms.CheckBox btnSchlu3;
    }
}
