using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia
{
    internal interface IRepositoryAgenti
    {
        List<Agente> GetAll();
        bool Aggiungi(Agente item);
        List<Agente> GetByArea(string area);
        List<Agente> GetByAnniDiServizio(int anniDiServizio);
        Agente GetByCodiceFiscale(string codiceFiscale);
    }
}
