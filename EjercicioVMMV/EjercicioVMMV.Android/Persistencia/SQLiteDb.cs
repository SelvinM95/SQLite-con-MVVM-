
using EjercicioVMMV.Droid.Persistencia;
using EjercicioVMMV.Persistence;
using SQLite; 
using System.IO;
using System.Runtime.CompilerServices;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDb))]
namespace EjercicioVMMV.Droid.Persistencia
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}