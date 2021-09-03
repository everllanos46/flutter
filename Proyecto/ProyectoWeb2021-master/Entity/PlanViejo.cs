using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PlanViejo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        public String CodigoPlanViejo{get; set;}
        public String CodigoPlan{get; set;}
        [NotMapped] 
        public Asignatura Asignatura{get; set;}
        public String IdAsignatura{get; set;}
        public String Descripcion { get; set; }
        public String Presentacion { get; set; }
        public String Justificacion { get; set; }
        public String CompetenciasGrales { get; set; }
        public String CompetenciasEspecificas { get; set; }
        public String Metodologias { get; set; }
        public String  Contenido { get; set; }
        public String ObjetivoGeneral { get; set; }
        public String ObjetivosEspecificos {get; set;}
        public String Estrategias { get; set; }
    }
}