using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DepartamentoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            BL.Departamento departamento = new BL.Departamento();
            BL.Result result = BL.Departamento.GetAll();
            if (result.Correct)
            {
                departamento.Departamentos = result.Objects;

                return View(departamento);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error en la consulta" + result.ErrorMessage;
                return View("");
            }

        }
    }
}
