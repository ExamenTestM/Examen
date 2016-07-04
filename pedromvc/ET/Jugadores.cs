using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ET
{
    public class Jugadores
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El Campo Edad es Requerido")]
        public int Edad { get; set; }

        public Jugadores()
        {

        }
        public Jugadores(string nombre, int edad)
        {

        }

        public Jugadores(int id, string nombre, int edad)
        {
            this.id = id;
            this.nombre = nombre;
            this.Edad = edad;
        }
        
    }
}
