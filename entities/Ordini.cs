using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities
{
    public class Ordini
    {
        public int Id { get; set; }
        public int IdUtente { get; set; }
        public int IdProdotto { get; set; }
        public Ordini() { }
        public Ordini(int id, int idutente, int idprodotto)
        {
            Id = id;
            IdUtente = idutente;
            IdProdotto = idprodotto;
        }
    }
}
