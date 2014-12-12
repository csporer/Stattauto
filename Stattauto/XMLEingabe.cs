using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stattauto
{
    public partial class XMLEingabe : Form
    {
        public XMLEingabe()
        {
            InitializeComponent();
        }

        private void XMLEingabe_Load(object sender, EventArgs e)
        {
            LadeBuchung();
        }

        private void LadeBuchung()
        {
            DataSet daten = new DataSet();
            daten.ReadXml(Pfade.xmlPfad);
            dataGridView1.DataSource = daten.Tables["Buchung"];                          
        }

        private void BtnSpeichern_Click(object sender, EventArgs e)
        {
            List<Buchung> liste = new List<Buchung>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {  
                if (Convert.ToInt32(row.Cells[0].Value) != 0)
                {
                    try
                    {
                        CheckInput(Convert.ToInt32(row.Cells[1].Value), row.Cells[2].Value,
                            row.Cells[3].Value, Convert.ToInt32(row.Cells[4].Value),
                            Convert.ToBoolean(row.Cells[5].Value), Convert.ToInt32(row.Cells[6].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString() + " in Zeile " + row.Index.ToString(), "Eingabefehler");
                        return;
                    }

                    liste.Add(new Buchung(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[1].Value),
                    Convert.ToDateTime(row.Cells[2].Value), Convert.ToDateTime(row.Cells[3].Value), Convert.ToInt32(row.Cells[4].Value),
                    Convert.ToBoolean(row.Cells[5].Value), Convert.ToInt32(row.Cells[6].Value)));
                }
            }
            Buchungsliste speichern = new Buchungsliste(liste);
            XML.Save<Buchungsliste>(Pfade.xmlPfad, speichern);
            LadeBuchung();
        }


        public static void ErstelleStandardbuchungsliste()
        {
            Buchung buch1 = new Buchung(1000, 1111, DateTime.Now, DateTime.Now.AddDays(1), 1, false, 1);
            Buchung buch2 = new Buchung(2000, 2222, DateTime.Now, DateTime.Now.AddDays(1), 2, false, 2);

            List<Buchung> Buchungen = new List<Buchung>();
            Buchungen.Add(buch1);
            Buchungen.Add(buch2);

            Buchungsliste list = new Buchungsliste(Buchungen);

            XML.Save<Buchungsliste>(Pfade.xmlPfad, list);
        }

        private void BtnStandard_Click(object sender, EventArgs e)
        {
            ErstelleStandardbuchungsliste();
            LadeBuchung();
        }


        private void CheckInput(int pin, object anfang, object ende, int fahrzeug, bool gebrauch, int tresorid)
        {
            if (pin < 0 || pin > 9999)
            {
                throw new Exception("PIN muss vierstellig und positiv sein!");
            }

            try
            {
                Convert.ToDateTime(anfang);
            }
            catch (Exception)
            {
                throw new Exception("Format vom Buchungsanfang ist falsch!");
            }

            try
            {
                Convert.ToDateTime(ende);
            }
            catch (Exception)
            {
                throw new Exception("Format vom Buchungsende ist falsch!");
            }

            if (fahrzeug > 3 || fahrzeug < 1)
            {
                throw new Exception("Wert für Fahrzeugnummer muss zwischen 1 und 3 sein!");
            }

            if(tresorid != 1 && tresorid != 2)
            {
                throw new Exception("Nur 1 oder 2 gültig bei Tresor ID");
            }
        }

        public void UpdateListe()
        {            
            LadeBuchung();
        }
    }
}
