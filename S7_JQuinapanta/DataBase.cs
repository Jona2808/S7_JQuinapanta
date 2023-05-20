using System;
using System.Collections.Generic;
using System.Text;
using SQLite; // utilizar los metodos del gestor de la bdd

namespace S7_JQuinapanta
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection(); //defino el metodo de conexion
    }
}
