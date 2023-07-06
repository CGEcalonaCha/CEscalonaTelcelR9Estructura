using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class PuestoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.Puesto puesto = new BL.Puesto();
            BL.Result result = BL.Puesto.GetAll();
            if (result.Correct)
            {
                puesto.Puestos = result.Objects;
                return View(puesto);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error en la consulta" + result.ErrorMessage;
                return View("");
            }
        }
    }
}
