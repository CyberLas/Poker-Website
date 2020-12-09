using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Poker.Repository
{
    public interface IHomeRepository
    {
        public List<Carta>   GenerarCartas();
        public List<Carta>   OtraVezGenerarCartas();
        public List<Jugador> EstadoJugador(int id);

        public List<Jugador> JugadorGanador();
        public List<Jugador> JugadorPerdedor();
        public List<Jugador> JugadoresEmpate(int id);
        public List<Carta>   Ordenar(List<Carta> carta);

        public int Poker(List<Carta> carta);
        public int Escalera(List<Carta> carta);
        public int Trio(List<Carta> carta);
        public int Full(List<Carta> carta);
        public int EscaleraReal(List<Carta> carta);
        public int EscaleraDeColor(List<Carta> carta);
        public int Color(List<Carta> carta);
        public int DoblePar(List<Carta> carta);
        public int UnPar(List<Carta> carta);
        public string Gano();
        public string Perdio();
    }

    public class HomeRepository : IHomeRepository
    {
        Carta carta = new Carta();
        List<Carta> cartas = new List<Carta>();
        List<Jugador> jugadores = new List<Jugador>();

        public List<Carta> GenerarCartas()
        {
            for (int i = 0; i < 25; i++)
            {
                var numero = new Random().Next(1, 14);
                var tipo = new Random().Next(0, 4);
                cartas.Add(new Carta()
                {
                    numero = numero,
                    tipo = tipo
                });
            }

            return cartas;
        }

        public List<Carta> OtraVezGenerarCartas()
        {
            while (cartas.Count < 25)
            {
                int numeroAleatorio = new Random().Next(1, 14);
                var tipo = new Random().Next(0, 4);

                cartas.Add(new Carta() { tipo = tipo });

                if (!(carta.tipo).Equals(tipo) || !(carta.numero).Equals(numeroAleatorio))
                {
                    cartas.Add(new Carta() { numero = numeroAleatorio });
                }
            }
            return cartas;
        }


        public List<Jugador> EstadoJugador(int id)
        {
            for (int i = 0; i < 4; i++) { return jugadores; } return null;
        }

        public List<Jugador> JugadorGanador()
        {
            for (int i = 0; i<4; i++) { jugadores[i].estado = true; return jugadores; }
            return null;
        }

        public List<Jugador> JugadorPerdedor()
        {
            for (int i = 0; i < 4; i++) { jugadores[i].estado = false; return jugadores; }
            return null;
        }

        public List<Jugador> JugadoresEmpate(int id)
        {
            for (int i = 0; i < 4; i++)
            {
                if (jugadores[i].estado != true || jugadores[i].estado != false) { return jugadores; }
            }
            return null;
        }

        public List<Carta> Ordenar(List<Carta> carta) { return cartas.Skip(0).Take(5).OrderBy(o => o.numero).ToList(); }

        public int Poker(List<Carta> carta) {
            int numero = 0;
            for (int i = 0; i < 4; i++) { if (cartas[i].numero == cartas[i + 1].numero) { numero++; } }
            if (numero == 4) { return 1; }
            return 0;
        }

        public int Escalera(List<Carta> carta)
        {
            int numero = 1;
            for (int i = 0; i < 4; i++)
            {
                if (cartas[i].numero + 1 == cartas[i + 1].numero) { numero++; }
            }
            if (numero == 4) { return 1; }
            return 0;
        }

        public int Trio(List<Carta> carta)
        {
            int numero = 0;
            for (int i = 0; i < 3; i++)
            {
                if (cartas[i].numero == cartas[i + 1].numero && cartas[i].numero == cartas[i + 2].numero)
                {
                    numero++;
                }
            }
            if (numero == 1) { return 1; }
            return 0;
        }

        public int Full(List<Carta> carta)
        {
            int numero = 0;
            for (int i = 0; i < 3; i++)
            {
                if (cartas[i].numero == cartas[i + 1].numero && cartas[i].numero == cartas[i + 2].numero)
                {
                    numero++;
                }
            }
            for (int i = 0; i < 4; i++) { if (cartas[i].numero == cartas[i + 1].numero) { numero++; } }
            if (numero == 2) { return 1; }
            return 0;
        }

        public int EscaleraDeColor(List<Carta> carta)
        {
            int numero = 0;
            for (int i = 0; i < 4; i++)
            {
                if (cartas[i].numero + 1 == cartas[i + 1].numero && cartas[i].tipo == cartas[i + 1].tipo)
                {
                    numero++;
                }
            }
            if (numero == 4) { return 1; }
            return 0;
        }

        public int EscaleraReal(List<Carta> cart)
        {
            int numero = 0;
            var carta = 0;
            for (int i = 0; i < 4; i++)
            {
                if (cartas[0].numero == 1) { carta = cartas[0].tipo; numero++;
                }
                else { if ((cartas[i].numero + 1) == cartas[i + 1].numero && (cartas[i + 1].tipo == carta))
                    {
                        numero++;
                    }
                }
            }
            if (numero == 4) { return 1;}
            return 0;
        }

        public int Color(List<Carta> carta)
        {
            int numero = 0;
            for (int i = 0; i < 4; i++) { if (cartas[i].tipo == cartas[i + 1].tipo) { numero++; } }
            if (numero == 4) { return 1; }
            return 0;
        }

        public int DoblePar(List<Carta> carta)
        {
            int numero = 0;
            for (int i = 0; i <= 5; i++) { if (cartas[i].numero == cartas[i + 1].numero) { numero++; } } 
            if (numero == 2) { return 1; }
            return 0;
        }

        public int UnPar(List<Carta> carta)
        {
            int numero = 0;
            for (int i = 0; i <= 5; i++) { if (cartas[i].numero == cartas[i + 1].numero) { numero++; } }
            if (numero == 1) { return 1; }
            return 0;
        }

        public string Gano() { return "Gano"; }
        public string Perdio() { return "Perdio"; }
    }   
}
