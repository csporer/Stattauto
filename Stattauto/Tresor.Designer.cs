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

        #region Vom Komponenten-Designer generierter Code

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

        }

        #endregion

        private TresorInnen innenleben;

    }
}
