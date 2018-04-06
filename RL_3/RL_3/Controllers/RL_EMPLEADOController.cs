using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RL_3.Models;

namespace RL_3.Controllers
{
    public class RL_EMPLEADOController : Controller
    {
        private MVCCHATEntities db = new MVCCHATEntities();

        // GET: RL_EMPLEADO
        public ActionResult Index()
        {
            var rL_EMPLEADO = db.RL_EMPLEADO.Include(r => r.RL_C_CORPORATIVOS).Include(r => r.RL_C_PUESTOS);
            return View(rL_EMPLEADO.ToList());
        }

        //GET:  RL_EMPLEADO/getDatosEmpleado
        //OBTIENE LOS DATOS DE UN EMPLEADO
        public JsonResult getDatosEmpleado(int NO_EMP)
        {
            string queryEmp = "SELECT A.ID_EMPLEADO, (A.NOMBRE  + ' ' + A.PATERNO + ' ' + A.MATERNO) AS NOMBRE_EMPLEADO, B.DESC_PUESTO, C.DESC_CORPORATIVO FROM RL_EMPLEADO A, RL_C_PUESTOS B,	RL_C_CORPORATIVOS C	WHERE A.PUESTO = B.ID_PUESTO AND A.CORPORATIVO = C.ID_CORPORATIVO AND A.NO_EMPLEADO = '" + NO_EMP + "';";
            var response = db.Database.SqlQuery<DatosEmpleado>(queryEmp);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        //GET:  RL_EMPLEADO/getChecadaEmpleado
        //OBTIENE LOS DATOS DE UN EMPLEADO
        public JsonResult getChecadaEmpleado(int ID_EMP)
        {
            string queryChecador = "SELECT A.ENTRADA  AS CHECADA,C.DESC_ACCESO FROM RL_EMPLEADO_ENTRADA A, RL_C_ACCESOS C WHERE A.ENTRADA_ACCESO = C.ID_ACCESO AND A.EMPLEADO_ID = '" + ID_EMP + "'  UNION ALL    SELECT A.SALIDA, B.DESC_ACCESO FROM RL_EMPLEADO_SALIDA A, RL_C_ACCESOS B WHERE A.SALIDA_ACCESO = B.ID_ACCESO AND A.EMPLEADO_ID = '" + ID_EMP + "' ";                                    
            var response = db.Database.SqlQuery<ChecadaEmpleado>(queryChecador);
            return Json(response, JsonRequestBehavior.AllowGet);
        }               
    }
}
