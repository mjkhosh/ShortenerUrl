using Microsoft.EntityFrameworkCore;
using ShortenerUrl.Core.Domain.ShortenerUrl.Entities;
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
        public DbSet<ShortUrl> ShortUrl { get; set; }
        public ShortenerUrlSqlQueryDbContext(DbContextOptions<ShortenerUrlSqlQueryDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
