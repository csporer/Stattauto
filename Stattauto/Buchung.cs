using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stattauto
{
    [Serializable]
   public class Buchung
    {
        public Buchung()
        { }

        public Buchung(int id, int pin, DateTime anfang, DateTime ende, int fahrzeug,bool gebrauch)
        {
            NutzerID = id;
            PIN = pin;
            AnfangBuchung = anfang;
            EndeBuchung = ende;
            VorgesehenesFahrzeug = fahrzeug;
            FahrzeugInGebrauch = gebrauch;
        }

        public int NutzerID { get; set; }
        public int PIN { get; set; }
        public DateTime AnfangBuchung { get; set; }
        public DateTime EndeBuchung { get; set; }
        public int VorgesehenesFahrzeug { get; set; }
        public bool FahrzeugInGebrauch { get; set; }
    }

    [Serializable]
   public class Buchungsliste
    {
        public Buchungsliste()
        { }
        
        public Buchungsliste(List<Buchung> liste)
        {
            Buchungen = liste;
        }

        public List<Buchung> Buchungen { get; set; }
    }
}
