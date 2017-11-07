using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext;
using System.Data.SqlClient;
using System.Data.Entity;
using WA_UNAM_NB_PR.DbContextUnam;

namespace DbContext
{
    public class DBUploadFileContext : DbContextUnam
    {
        public IEnumerable<Archivo> SearchMetaData(string search)
        {
            return Database.SqlQuery<Archivo>("FILES.SearchMetaData @search", new SqlParameter("@search", search));
        }

        public IEnumerable<Archivo> SearchMetaDataByName(string search, string name)
        {
            return Database.SqlQuery<Archivo>(
                "FILES.SearchMetaDataByName @serach, @name",
                new SqlParameter("@search", search),
                new SqlParameter("@name", name)
                );
        }
    }
}
