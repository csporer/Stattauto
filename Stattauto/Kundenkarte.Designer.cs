namespace Stattauto
{
    partial class Kundenkarte
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
            this.SuspendLayout();
            // 
            // Kundenkarte
            // 
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Kundenkarte_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Kundenkarte_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Kundenkarte_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
