using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Solicitud
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        public String CodigoSolicitud { get; set; }
        public String CodigoPlanSolicitud{get; set;}
        public PlanSolicitud PlanSolicitud{get; set;}
        public String Solicitante{get; set;}
        public String Estado{get; set;}
        
    }
}