using EjercicioVMMV.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioVMMV.ViewModel
{
    public interface IEmpleadoStore
    {
        Task<IEnumerable<Empleados>> GetEmpleadosAsync();
        Task<Empleados> GetEmpleados(int id);
        Task AddEmpleados(Empleados empleados);
        Task UpdateEmpleados(Empleados empleados);
        Task DeleteEmpleados(Empleados empleados);
    }
}
