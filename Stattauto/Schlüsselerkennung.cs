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
        public void PruefeEntnahme()
        {           
                if (_innen.ZuletztEntnommen == 2)
                {
                    _tresor.AusgabeDisplay = "Bitte Türe schließen";
                }
                else
                {
                    _tresor.AusgabeDisplay = "Falschen Schlüssel entnommen!";                    
                    
                }
                _tresor.Refresh();
            }
        }
    }

