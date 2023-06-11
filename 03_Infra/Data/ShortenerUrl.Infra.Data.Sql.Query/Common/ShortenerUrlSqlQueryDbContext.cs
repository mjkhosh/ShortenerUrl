using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Infra.Data.Sql.Queries;

namespace ShortenerUrl.Infra.Data.Sql.Query.Common
{
    public class ShortenerUrlSqlQueryDbContext : BaseQueryDbContext
    {
        public ShortenerUrlSqlQueryDbContext(DbContextOptions<ShortenerUrlSqlQueryDbContext> options) : base(options)
        {
        }
    }
}
