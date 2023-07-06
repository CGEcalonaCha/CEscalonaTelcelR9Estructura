using BL;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            Empleado empleado = new Empleado();
            Result result = Empleado.GetAll(null);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error en la consulta" + result.ErrorMessage;
                return View("");
            }

        }
        [HttpPost]
        public ActionResult GetAll(string nombre)
        {
            Empleado empleado = new Empleado();
            Result result = Empleado.GetAll(nombre);
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View("");
            }

        }
        public ActionResult Delete(int idEmpleado)
        {
            Empleado empleado = new Empleado();
            Result result = Empleado.Delete(idEmpleado);

            if (result.Correct)
            {
                //ViewBag.Message = "El Empleado a sido Eliminado con exito";
                return RedirectToAction("GetAll", "Empleado");
            }
            else
            {
                //ViewBag.Message = "Ocurrio un error al eliminar al Empleado: " + result.ErrorMessage;
            }
            return RedirectToAction("GetAll", "Empleado");
        }
    }
}
