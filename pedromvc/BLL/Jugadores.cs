using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Jugadores
    {
        public static void Insert(string nombre, int edad)
        {
            DA.Jugadores.Insert(nombre, edad);
        }

        public static void Eliminar(int id)
        {
            DA.Jugadores.Delete(id);
        } 

        public static void Update(int id,string nombre,int edad)
        {
            DA.Jugadores.Update(id, nombre, edad);
        }

        public static List<ET.Jugadores> GetJugadores()
        {
             return DA.Jugadores.GetConsulta();
        }

        public static List<ET.Jugadores> GetConsultabyId(int id)
        {
            return DA.Jugadores.GetConsultabyId(id);
        }


    }
}
