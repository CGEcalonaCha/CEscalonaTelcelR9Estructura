using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Puesto
    {
        //ATRIBUTOS
        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
        public List<object> Puestos { get; set; }
        //METODOS
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DL.CescalonaEstructuraContext context = new DL.CescalonaEstructuraContext())
                {
                    var query = context.Puestos.FromSqlRaw("PuestoGetAll").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Puesto puesto = new Puesto();
                            puesto.IdPuesto = obj.IdPuesto;
                            puesto.Nombre = obj.Descripcion;
                            result.Objects.Add(puesto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error: " + ex.Message;
            }
            return result;
        }
    }
}
