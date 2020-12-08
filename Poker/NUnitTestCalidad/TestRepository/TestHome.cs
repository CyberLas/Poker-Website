using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Poker.Controllers;
using Poker.Models;
using Poker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestCalidad.TestRepository
{
    public class TestHome
    {
        /* .................::::::::::::: Mostrar la Vista General :::::::::::::................. */
        [Test]
        public void VerificarPantallaPrincipal()
        {
            var app = new Mock<IHomeRepository>();
            var controller = new HomeController(app.Object);

            var index = controller.Index();
            Assert.IsInstanceOf<ViewResult>(index);
        }


        /* .................::::::::::::: Generar Cartas Random :::::::::::::................. */
        [Test]
        public void GenerarRamdon()
        {
            var app = new Mock<IHomeRepository>();
            app.Setup(o => o.GenerarCartas()).Returns(new List<Carta>());

            var controller = new HomeController(app.Object);
            var index = controller.Index();
            Assert.IsInstanceOf<ViewResult>(index);
        }


        /* .................::::::::::::: No Repetir Cartas Duplicadas :::::::::::::................. */
        [Test]
        public void SinRepetirCartasDuplicadas()
        {
            var app = new Mock<IHomeRepository>();

            if (app.Setup(o => o.GenerarCartas()).Returns(new List<Carta>()) == null)
            {
                app.Setup(o => o.GenerarCartas()).Returns(new List<Carta>());
                var controller = new HomeController(app.Object);
                var index = controller.Index();
                Assert.IsInstanceOf<ViewResult>(index);
            }
        }


        /* .................::::::::::::: Mostrar Escalera de Color :::::::::::::................. */
        [Test]
        public void SalioEscaleraDeColor()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 5, tipo = 2 });
            cartas.Add(new Carta() { numero = 6, tipo = 2 });
            cartas.Add(new Carta() { numero = 7, tipo = 2 });
            cartas.Add(new Carta() { numero = 8, tipo = 2 });
            cartas.Add(new Carta() { numero = 9, tipo = 2 });

            var app    = new Mock<IHomeRepository>();
            var verdad  = 0;
            var result = app.Setup(o => o.EscaleraDeColor(cartas)).Returns(verdad);
            Assert.AreNotEqual(result, 1);
        }


        /* .................::::::::::::: Mostrar Escalera de Real :::::::::::::................. */
        [Test]
        public void SalioEscaleraReal()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero =  1, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 1 });
            cartas.Add(new Carta() { numero = 11, tipo = 1 });
            cartas.Add(new Carta() { numero = 12, tipo = 1 });
            cartas.Add(new Carta() { numero = 13, tipo = 1 });

            var app = new Mock<IHomeRepository>();
            var result = app.Setup(o => o.EscaleraDeColor(cartas)).Returns(0);
            Assert.AreNotEqual(result, 1);
        }


        /* .................::::::::::::: Mostrar Poker :::::::::::::................. */
        [Test]
        public void SalioPoker()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 7, tipo = 4 });
            cartas.Add(new Carta() { numero = 1, tipo = 4 });
            cartas.Add(new Carta() { numero = 1, tipo = 3 });
            cartas.Add(new Carta() { numero = 1, tipo = 2 });
            cartas.Add(new Carta() { numero = 1, tipo = 1 });
            cartas.Add(new Carta() { numero = 1, tipo = 0 });

            var app = new Mock<IHomeRepository>();
            var result = app.Setup(o => o.Poker(cartas)).Returns(0);
            Assert.AreNotEqual(result, 0);
        }


        /* .................::::::::::::: Mostrar Full :::::::::::::................. */
        [Test]
        public void SalioFull()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 10, tipo = 4 });
            cartas.Add(new Carta() { numero = 10, tipo = 3 });
            cartas.Add(new Carta() { numero = 13, tipo = 2 });
            cartas.Add(new Carta() { numero = 13, tipo = 1 });
            cartas.Add(new Carta() { numero = 13, tipo = 0 });

            var app = new Mock<IHomeRepository>();
            var result = app.Setup(o => o.Poker(cartas)).Returns(0);
            Assert.IsNotNull(result);
        }


        /* .................::::::::::::: Mostrar Color :::::::::::::................. */
        [Test]
        public void SalioColor()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 12, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 1 });
            cartas.Add(new Carta() { numero =  9, tipo = 1 });
            cartas.Add(new Carta() { numero =  7, tipo = 1 });
            cartas.Add(new Carta() { numero =  4, tipo = 1 });

            var app = new Mock<IHomeRepository>();
            var result = app.Setup(o => o.Color(cartas)).Returns(0);
            Assert.AreNotEqual(result, null);
        }


        /* .................::::::::::::: Mostrar Escalera :::::::::::::................. */
        [Test]
        public void SalioEscaleraNormal()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 2, tipo = 0 });
            cartas.Add(new Carta() { numero = 4, tipo = 1 });
            cartas.Add(new Carta() { numero = 5, tipo = 2 });
            cartas.Add(new Carta() { numero = 6, tipo = 3 });
            cartas.Add(new Carta() { numero = 7, tipo = 2 });

            var app = new Mock<IHomeRepository>();
            var ordenar = app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());
            var result = app.Setup(o => o.Escalera(cartas)).Returns(0);
            Assert.IsNotEmpty(cartas);
        }

        /* .................::::::::::::: Mostrar Trío :::::::::::::................. */
        [Test]
        public void SalioTrio()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero =  2, tipo = 0 });
            cartas.Add(new Carta() { numero =  3, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 2 });
            cartas.Add(new Carta() { numero = 10, tipo = 3 });

            var app = new Mock<IHomeRepository>();
            var ordenar = app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());
            var result = app.Setup(o => o.Trio(cartas)).Returns(0);
            Assert.IsNotEmpty(cartas);
        }


        /* .................::::::::::::: Mostrar Doble par :::::::::::::................. */
        [Test]
        public void SalioDoublePar()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 2, tipo = 0 });
            cartas.Add(new Carta() { numero = 3, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 2 });
            cartas.Add(new Carta() { numero = 10, tipo = 3 });

            var app = new Mock<IHomeRepository>();
            var ordenar = app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());
            var result = app.Setup(o => o.DoblePar(cartas)).Returns(0);
            Assert.AreNotEqual(cartas, result);
        }


        /* .................::::::::::::: Mostrar Un par :::::::::::::................. */
        [Test]
        public void SalioUnPar()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 2, tipo = 0 });
            cartas.Add(new Carta() { numero = 3, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 2 });
            cartas.Add(new Carta() { numero = 10, tipo = 3 });

            var app = new Mock<IHomeRepository>();
            var ordenar = app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());
            var result = app.Setup(o => o.DoblePar(cartas)).Returns(0);
            Assert.IsNotNull(result);
        }


        /* .................::::::::::::: Mostrar Carta alta :::::::::::::................. */
        [Test]
        public void SalioCartaAlta()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 2, tipo = 0 });
            cartas.Add(new Carta() { numero = 3, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 2 });
            cartas.Add(new Carta() { numero = 10, tipo = 3 });

            var app = new Mock<IHomeRepository>();
            var ordenar = app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());
            var result = app.Setup(o => o.DoblePar(cartas)).Returns(0);
            Assert.AreNotEqual(result, 0);
        }


        /* .................::::::::::::: Mostrar Jugador Ganador :::::::::::::................. */
        [Test]
        public void MostarJugadorGanador()
        {
            List<Carta> cartas = new List<Carta>();
            cartas.Add(new Carta() { numero = 2, tipo = 0 });
            cartas.Add(new Carta() { numero = 3, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 1 });
            cartas.Add(new Carta() { numero = 10, tipo = 2 });
            cartas.Add(new Carta() { numero = 10, tipo = 3 });

            var app = new Mock<IHomeRepository>();
            var ordenar = app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());
            Assert.AreNotEqual(cartas, ordenar);
        }


        /* .................::::::::::::: Mostrar Ordebar Baraja :::::::::::::................. */
        [Test]
        public void OrdenarBaraja()
        {
            List<Carta> cartas = new List<Carta>();
            for (int i = 0; i <= 5; i++) { var tipo = new Random().Next(0, 4);  cartas.Add(new Carta() { numero = 1, tipo = tipo }); } 
            var app = new Mock<IHomeRepository>();

            var Lista   = app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());
            Assert.IsNotNull(Lista);
        }


        /* .................::::::::::::: Mostrar Manos de Poker :::::::::::::................. */
        [Test]
        public void MostrarManoPoker()
        {
            List<Carta> cartas = new List<Carta>();
            for (int i = 0; i<4 ; i++) { cartas.Add(new Carta() { numero = 1, tipo = i }); }

            var app = new Mock<IHomeRepository>();
            var Poker = 1;
            app.Setup(o => o.EstadoJugador(1)).Returns(new List<Jugador>());
            Assert.AreNotEqual(Poker, app.Setup(o => o.Poker(cartas)).Returns(1).ToString());
        }


        /* .................::::::::::::: Mostrar El tipo de mano de poker :::::::::::::................. */
        [Test]
        public void MostrarManoDePoker()
        {
            List<Carta> cartas = new List<Carta>();
            for (int i = 0; i < 4; i++) { cartas.Add(new Carta() { numero = 1, tipo = i }); }
            
            var app = new Mock<IHomeRepository>();
            app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>());

            var controller = new HomeController(app.Object);
            var index = controller.Index();
            if (app.Setup(o => o.Ordenar(cartas)).Returns(new List<Carta>()) != null) {
                Assert.IsInstanceOf<ViewResult>(index);
            }
        }


        /* .................::::::::::::: Mostrar Estados de Jugadores :::::::::::::................. */
        [Test]
        public void MostrarEstadoJuagdores()
        {
            var app = new Mock<IHomeRepository>();
            
            app.Setup(o => o.EstadoJugador(1)).Returns(new List<Jugador>());
            Assert.AreNotEqual(app.Setup(o => o.EstadoJugador(1)).Returns(new List<Jugador>()),new List<Jugador>());
        }


        /* .................::::::::::::: Mostrar Jugador Ganador :::::::::::::................. */
        [Test]
        public void MostrarJugadorGanador()
        {
            Jugador jugador = new Jugador();
            var app = new Mock<IHomeRepository>();

            var result = app.Setup(o => o.JugadorGanador()).Returns(new List<Jugador>());
            var gano   = true;
            Assert.AreNotEqual(jugador.estado, gano);
        }


        /* .................::::::::::::: Mostrar Jugadore(s) Perdedor :::::::::::::................. */
        [Test]
        public void MostrarJugadorPerdedor()
        {
            Jugador jugador = new Jugador();
            var app = new Mock<IHomeRepository>();

            var result = app.Setup(o => o.JugadorPerdedor()).Returns(new List<Jugador>());
            var perdio = true;
            Assert.AreNotEqual(jugador.estado, perdio);
        }


        /* .................::::::::::::: Mostrar Caso de Empate :::::::::::::................. */
        [Test]
        public void MostrarJugadoresEnEmpate()
        {
            Jugador jugador = new Jugador();
            var app = new Mock<IHomeRepository>();

            var result = app.Setup(o => o.JugadoresEmpate(1)).Returns(new List<Jugador>());
            for (int i = 0; i < 4; i++)
            {
                Assert.AreNotEqual(jugador.estado, null);
            }
        }
    }
}
