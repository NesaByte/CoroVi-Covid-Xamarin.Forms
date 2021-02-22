using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace CoroVi//.SelfCare
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;
        public DBManager()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async Task<ObservableCollection<Assessment>> CreateTable()
        {
            await _connection.CreateTableAsync<Assessment>();
            var todoTaskFromDB = await _connection.Table<Assessment>().ToListAsync();
            var allAssesments = new ObservableCollection<Assessment>(todoTaskFromDB);
            return allAssesments;
        }

        public void insertNewToDo(Assessment task)
        {
            _connection.InsertAsync(task);
        }

        public void deleteTask(Assessment toDelete)
        {
            _connection.DeleteAsync(toDelete);
        }
        public void updateTask(Assessment toUpdate)
        {
            _connection.UpdateAsync(toUpdate);

        }
    }
}