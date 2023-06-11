using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Infra.Data.Sql.Commands;

namespace ShortenerUrl.Infra.Data.Sql.Command.Common
{
    public class ShortenerUrlSqlCommandDbContext: BaseCommandDbContext
    {
        public ShortenerUrlSqlCommandDbContext(DbContextOptions<ShortenerUrlSqlCommandDbContext> options) : base(options)
        {

        }
    }
}
