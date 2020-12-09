using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Poker.Models;
using Poker.Repository;

namespace Poker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository app;

        public HomeController(IHomeRepository app)
        {
            this.app = app;
        }

        public IActionResult Index()
        {
            ViewBag.Numero   = app.GenerarCartas();
            ViewBag.Ordenar  = app.Ordenar(null);

            if (app.EscaleraDeColor(null) == 1) { ViewBag.EscaleraDeColor = app.Gano(); } ;
            if (app.Escalera(null) == 1)        { ViewBag.EscaleraEstado = app.Gano(); };
            if (app.EscaleraReal(null) == 1)    { ViewBag.EscaleraReal = app.Gano(); };
            if (app.Poker(null) == 1)           { ViewBag.PokerEstado = app.Gano(); };
            if (app.Trio(null) == 1)            { ViewBag.TrioEstado = app.Gano(); };
            if (app.Color(null) == 1)           { ViewBag.EscaleraReal = app.Gano(); };
            if (app.DoblePar(null) == 1)        { ViewBag.DoblePar = app.Gano(); };
            if (app.UnPar(null) == 1)           { ViewBag.UnPar = app.Gano(); };
            if (app.Full(null) == 1)            { ViewBag.Full = app.Gano(); };
            return View();
        }

    }
}
