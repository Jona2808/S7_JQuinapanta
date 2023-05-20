using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace S7_JQuinapanta
{
    public class Estudiante
    {
        //agregar esta tabla dento de la bd creada anteriormente
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }

        [MaxLength(50)]
        public string Contrasena { get; set; }
    }
}
