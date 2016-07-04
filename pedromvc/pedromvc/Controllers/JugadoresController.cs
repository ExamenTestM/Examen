using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pedromvc.Controllers
{
    public class JugadoresController : Controller
    {
        BLL.Jugadores bll = new BLL.Jugadores();
        // GET: Jugadores
        public ActionResult Index()
        {

            return View(BLL.Jugadores.GetJugadores());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ET.Jugadores jugador)
        {
            
            BLL.Jugadores.Insert(jugador.nombre, jugador.Edad);
            return View("Index", BLL.Jugadores.GetJugadores());
        }

        
        public ActionResult Actualizar(int id)
        {
            ET.Jugadores j = BLL.Jugadores.GetConsultabyId(id)[0];
            return View(j);
        }
        [HttpPost]
        public ActionResult Actualizar(ET.Jugadores jugador)
        {
            BLL.Jugadores.Update(jugador.id, jugador.nombre, jugador.Edad);
            return View("Index", BLL.Jugadores.GetJugadores());
        }

        public ActionResult EstaSeguro(int id)
        {
            ET.Jugadores j =  BLL.Jugadores.GetConsultabyId(id)[0];
            return View(j);
        }
        [HttpPost]
        public ActionResult EstaSeguro(ET.Jugadores jugador)
        {
            BLL.Jugadores.Eliminar(jugador.id);
            return View("Index", BLL.Jugadores.GetJugadores());
        }
    }
}