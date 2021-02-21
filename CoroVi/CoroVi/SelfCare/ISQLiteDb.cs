using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoroVi//.SelfCare
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
