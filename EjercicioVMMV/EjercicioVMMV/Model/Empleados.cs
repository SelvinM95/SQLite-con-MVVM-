using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioVMMV.Model
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nombre{ get; set; }

        [MaxLength(255)]
        public string Apellido { get; set; }

        [MaxLength(255)]
        public string Edad { get; set; }

        [MaxLength(255)]
        public string Direccion { get; set; }
        [MaxLength(255)]
        public string Puesto { get; set; }
    }
}
