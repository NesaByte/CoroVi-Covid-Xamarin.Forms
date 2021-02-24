using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoroVi 
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
