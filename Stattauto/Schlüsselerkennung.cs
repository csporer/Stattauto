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
        private StatusSchluessel[] _alt;        
        
        public Schlüsselerkennung(Tresor tresor)
        {
            _tresor = tresor;
            SetInnenleben();
            _alt = new StatusSchluessel[3];
            MerkeSchluesselStatus();
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

        public bool RichtigeEntnahme()
        {
            bool value = true;
            for (int i = 0; i < 3; i++)
            {
                if (i+1 != _tresor.AktiveBuchung.VorgesehenesFahrzeug)
                {
                    if (_alt[i] != _innen.Schluessel[i])
                    {                        
                        value = false;
                    }
                }  
            }            
            return value;
        }

        public void MerkeSchluesselStatus()
        {
            for (int i = 0; i < 3; i++)
            {
                _alt[i] = _innen.Schluessel[i];
            }
        }
    }
}

