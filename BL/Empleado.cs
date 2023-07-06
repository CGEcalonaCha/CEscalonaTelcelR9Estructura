using System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        //ATRIBUTOS
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public Puesto Puesto { get; set; }
        public Departamento Departamento { get; set; }
        public List<object> Empleados { get; set; }
        //METODOS
        public static Result GetAll(string? Nombre)
        {
            Result result = new Result();
            try
            {
                using (DL.CescalonaEstructuraContext context = new DL.CescalonaEstructuraContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetAllNombre '{Nombre}'").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Empleado empleado = new Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.Puesto = new Puesto();
                            empleado.Puesto.IdPuesto = obj.IdPuesto.Value;
                            empleado.Puesto.Nombre = obj.DescripcionPuesto;
                            empleado.Departamento = new Departamento();
                            empleado.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                            empleado.Departamento.Nombre = obj.DescripcionDepartamento;
                            result.Objects.Add(empleado);

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
        public static Result Delete(int IdEmpleado)
        {
            Result result = new Result();
            try
            {
                using (DL.CescalonaEstructuraContext context = new DL.CescalonaEstructuraContext())
                {
                    int rowAffected = context.Database.ExecuteSqlRaw($"EmpleadoDelete {IdEmpleado}");

                    if (rowAffected >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al eliminar al Empleado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error :  " + ex.Message;
            }
            return result;
        }
    }
}
