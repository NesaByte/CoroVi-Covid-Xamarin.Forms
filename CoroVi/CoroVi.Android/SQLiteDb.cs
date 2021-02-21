
using System;
using System.IO;
using SQLite;
using CoroVi.Droid;
using CoroVi;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]

namespace CoroVi.Droid
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