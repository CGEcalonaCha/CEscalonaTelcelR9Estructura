using System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        //ATRIBUTOS
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public List<object> Departamentos { get; set; }
        //METODOS
        public static Result GetAll()
        {
            Result result = new Result();
            try
            {
                using (DL.CescalonaEstructuraContext context = new DL.CescalonaEstructuraContext())
                {
                    var query = context.Departamentos.FromSqlRaw("DepartamentoGetAll").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Departamento departamento = new Departamento();
                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Descripcion;
                            result.Objects.Add(departamento);
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
