using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia
{
    internal class Agente : Persona
    {        
        public string AreaGeografica { get; set; }
        public int AnnoDiInizioAttivita { get; set; }

        public Agente()
        {

        }
        public Agente(string nome, string cognome, string codiceFiscale, string areaGeografica, int annoDiInizioAttivita) 
            : base(nome, cognome, codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoDiInizioAttivita = annoDiInizioAttivita;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Servizio {CalcolaAnniDiServizio()} ";
        }
                
        public int CalcolaAnniDiServizio()
        {
            int anniDiServizio;
            anniDiServizio = 2022 - AnnoDiInizioAttivita;
            return anniDiServizio;
        }
    }
}
