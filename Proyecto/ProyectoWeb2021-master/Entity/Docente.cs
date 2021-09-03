using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Docente
    {
        [Key] 
        public String Identificacion { get; set; }
        public String Correo { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public String Ciudad { get; set; }
        public String Pais { get; set; }
        public String SobreDocente {get; set;}
        public String Foto {get; set;}
        public String Usuario {get; set;}
        public String Password {get; set;}
    }
}
