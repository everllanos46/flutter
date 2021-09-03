using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class PlanAsignaturaService
    {
        private AsignaturaContext _AsignaturaContext;

        public PlanAsignaturaService(AsignaturaContext asignaturaContext)
        {
            _AsignaturaContext = asignaturaContext;
        }

        public GuardarPlanResponse GuardarPlan(PlanAsignatura planAsignatura)
        {
            try
            {
                var Respuesta = _AsignaturaContext.PlanAsignaturas.Find(planAsignatura.CodigoPlan);
                if (Respuesta == null)
                {
                    _AsignaturaContext.PlanAsignaturas.Add(planAsignatura);
                    _AsignaturaContext.SaveChanges();
                    return new GuardarPlanResponse(planAsignatura);
                }
                else
                {
                    return new GuardarPlanResponse("Ya se encuentra este plan de asignatura", "EXISTE");
                }
            }
            catch (Exception e)
            {
                return new GuardarPlanResponse($"Error aplicación: {e.Message}", "ERROR");
            }
        }

        

        public ConsultarPlanResponse ConsultarPlan()
        {
            ConsultarPlanResponse consultarPlanResponse = new ConsultarPlanResponse();
            try
            {
                consultarPlanResponse.Error = false;
                consultarPlanResponse.Mensaje = "Consultado correctamente";
                consultarPlanResponse.PlanAsignaturas = _AsignaturaContext.PlanAsignaturas.Include(p => p.Asignatura).ToList();
            }
            catch (Exception e)
            {
                consultarPlanResponse.Error = true;
                consultarPlanResponse.Mensaje = $"Hubo un error al momento de consultar, {e.Message}";
                consultarPlanResponse.PlanAsignaturas =null;
            }
            return consultarPlanResponse;
        }

        public ConsultarPlanViejoResponse ConsultarPlanViejo(string codigo)
        {
            ConsultarPlanViejoResponse consultarPlanViejoResponse = new ConsultarPlanViejoResponse();
            try
            {
                var solicitud = _AsignaturaContext.Solicitudes.Find(codigo);
                //var plan = _AsignaturaContext.PlanSolicitud.Where(p => p.CodigoPlanSolicitud == solicitud.);
                consultarPlanViejoResponse.Error = false;
                consultarPlanViejoResponse.Mensaje = "Consultado correctamente";
                consultarPlanViejoResponse.PlanesViejos = _AsignaturaContext.PlanesViejos.Where(p=>p.CodigoPlan.Equals("plan.CodigoPlan")).ToList();
                foreach (var item in consultarPlanViejoResponse.PlanesViejos){
                    item.Asignatura=_AsignaturaContext.Asignaturas.Find(item.IdAsignatura);
                }
            }
            catch (Exception e)
            {
                consultarPlanViejoResponse.Error = true;
                consultarPlanViejoResponse.Mensaje = $"Hubo un error al momento de consultar, {e.Message}";
                consultarPlanViejoResponse.PlanesViejos =null;
            }
            return consultarPlanViejoResponse;
        }


        public EliminarPlanResponse EliminarPlan(string codigo){
            EliminarPlanResponse eliminarPlanResponse = new EliminarPlanResponse();
            try{
                eliminarPlanResponse.Error=false;
                eliminarPlanResponse.Mensaje="Docente eliminado correctamente";
                var resul= ConsultarPlan();
                PlanAsignatura a=resul.PlanAsignaturas.Where(p=>p.Asignatura.Codigo.Equals(codigo)).FirstOrDefault();
                _AsignaturaContext.Remove(a);
                _AsignaturaContext.SaveChanges();
            }catch(Exception e){
                eliminarPlanResponse.Error=true;
                eliminarPlanResponse.Mensaje=$"Hubo un error al momento de eliminar al plan de asignatura, {e.Message}";
            }

            return eliminarPlanResponse;
        }



        public EditarPlanResponse EditarPlan(PlanSolicitud planSolicitud){
            EditarPlanResponse editarPlanResponse = new EditarPlanResponse();
            try{
                editarPlanResponse.Error=false;
                editarPlanResponse.Mensaje="Plan editado correctamente";
                var planes =  ConsultarPlan();
                var resul=planes.PlanAsignaturas.Where(p=>p.CodigoPlan.Equals(planSolicitud.CodigoPlan)).FirstOrDefault();
                PlanViejo planViejo = AsignarDatos(resul);
                resul.Descripcion=planSolicitud.Descripcion;
                resul.Estrategias=planSolicitud.Estrategias;
                resul.ObjetivoGeneral=planSolicitud.ObjetivoGeneral;
                resul.ObjetivosEspecificos=planSolicitud.ObjetivosEspecificos;
                resul.CompetenciasEspecificas=planSolicitud.CompetenciasEspecificas;
                resul.CompetenciasGrales=planSolicitud.CompetenciasGrales;
                resul.Contenido=planSolicitud.Contenido;
                resul.Justificacion=planSolicitud.Justificacion;
                resul.Metodologias=planSolicitud.Metodologias;
                resul.Presentacion=planSolicitud.Presentacion;
                _AsignaturaContext.PlanAsignaturas.Update(resul);
                _AsignaturaContext.PlanesViejos.Add(planViejo);
                _AsignaturaContext.SaveChanges();
            } catch(Exception e){
                editarPlanResponse.Error=true;
                editarPlanResponse.Mensaje=$"Hubo un error al momento de editar al plan, {e.Message}";
            }
            return editarPlanResponse;
        }

        public PlanViejo AsignarDatos(PlanAsignatura planAsignatura){
            PlanViejo planViejo = new PlanViejo();
            planViejo.Asignatura=planAsignatura.Asignatura;
            planViejo.CodigoPlan=planAsignatura.CodigoPlan;;
            planViejo.CompetenciasEspecificas=planAsignatura.CompetenciasEspecificas;
            planViejo.CompetenciasGrales=planAsignatura.CompetenciasGrales;
            planViejo.Contenido=planAsignatura.Contenido;
            planViejo.Descripcion=planAsignatura.Descripcion;
            planViejo.Estrategias=planAsignatura.Estrategias;
            planViejo.IdAsignatura=planAsignatura.Asignatura.Codigo;
            planViejo.Justificacion=planAsignatura.Justificacion;
            planViejo.Metodologias=planAsignatura.Metodologias;
            planViejo.ObjetivoGeneral=planAsignatura.ObjetivoGeneral;
            planViejo.ObjetivosEspecificos=planAsignatura.ObjetivosEspecificos;
            planViejo.Presentacion=planAsignatura.Presentacion;
            return planViejo;

        }


        public class EditarPlanResponse{
             public bool Error { get; set; }
            public String Mensaje { get; set; }
        }

        public class EliminarPlanResponse
        {
            public bool Error { get; set; }
            public String Mensaje { get; set; }
        }



        public class EditarAsignaturaResponse{
            public String Mensaje { get; set; }
            public bool Error { get; set; }
        }

        public class ConsultarPlanResponse
        {
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<PlanAsignatura> PlanAsignaturas { get; set; }
        }

        public class ConsultarPlanViejoResponse
        {
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public List<PlanViejo> PlanesViejos { get; set; }
        }

        public class GuardarPlanResponse
        {
            public GuardarPlanResponse(PlanAsignatura planAsignatura)
            {
                Error = false;
                PlanAsignatura = planAsignatura;
            }

            public GuardarPlanResponse(String Message, String Estate)
            {
                Error = true;
                Mensaje = Message;
                Estado = Estate;
            }
            public bool Error { get; set; }
            public String Mensaje { get; set; }
            public PlanAsignatura PlanAsignatura { get; set; }
            public String Estado { get; set; }
        }
    }
}