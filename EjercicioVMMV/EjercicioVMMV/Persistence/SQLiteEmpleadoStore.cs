using EjercicioVMMV.Model;
using EjercicioVMMV.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioVMMV.Persistence
{
    public class SQLiteEmpleadoStore : IEmpleadoStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteEmpleadoStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Empleados>();
        }
        public async Task<IEnumerable<Empleados>> GetEmpleadosAsync()
        {
            return await _connection.Table<Empleados>().ToListAsync();
        }
        public async Task DeleteEmpleados(Empleados empleados)
        {
            await _connection.DeleteAsync(empleados);
        }
        public async Task AddEmpleados(Empleados empleados)
        {
            await _connection.InsertAsync(empleados);
        }
        public async Task UpdateEmpleados(Empleados empleados)
        {
            await _connection.UpdateAsync(empleados);
        }
        public async Task<Empleados> GetEmpleados(int id)
        {
            return await _connection.FindAsync<Empleados>(id);
        }
    }
}
