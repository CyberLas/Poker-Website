using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class Jugador
    {
        public int numero   { get; set; }

        public bool estado  { get; set; }

        List<Carta> cartas  { get; set; }
    }

}
