using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matomonial_management_system.Interfaces
{
    internal interface DatabaseInterface
    {
        void insert();
        void update();
        int delete(string tableName, int ID);
        int deleteAll();
        SqlDataReader select(string tableName);
    }
}
