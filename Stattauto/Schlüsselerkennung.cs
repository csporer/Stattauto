using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stattauto
{
    class Schlüsselerkennung
    {
        private Tresor _tresor;
        private TresorInnen _innen;        
        
        public Schlüsselerkennung(Tresor tresor)
        {
            _tresor = tresor;
            SetInnenleben();
        }

        private void SetInnenleben()
        {
            foreach(Object innen in _tresor.Controls)
            {
                if(innen is TresorInnen)
                {
                    _innen = (TresorInnen)innen;
                }
            }
        }
        public void PruefeEntnahme(StatusSchluessel status)
        {
            if (_innen.ZuletztEntnommen == _tresor.AktiveBuchung.VorgesehenesFahrzeug && status == StatusSchluessel.vorhanden)
            {
                _tresor.RichtigerSchluesselStatus = StatusSchluessel.vorhanden;
            }

            if (_innen.ZuletztZurueck == _innen.ZuletztEntnommen && status == StatusSchluessel.vorhanden)
            {
                _innen.StopPiep();                
                return;
            }


            if (_innen.ZuletztEntnommen == _tresor.AktiveBuchung.VorgesehenesFahrzeug && status == StatusSchluessel.entnommen)
            {
                _tresor.SetDisplayText("Bitte Türe schließen");
                _tresor.RichtigerSchluesselStatus = StatusSchluessel.entnommen;
            }
            else
            {
                _tresor.SetDisplayText("Falschen Schlüssel entnommen!");
                _innen.StartPiep();                    
            }
            _tresor.Refresh(); 
            }           
    }
}

