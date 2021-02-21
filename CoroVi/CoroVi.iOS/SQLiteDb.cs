
using System;
using CoroVi;
using Xamarin.Forms;
using SQLite;
using System.IO;
using CoroVi.iOS;

[assembly: Dependency(typeof(SQLiteDb))]

namespace CoroVi.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}