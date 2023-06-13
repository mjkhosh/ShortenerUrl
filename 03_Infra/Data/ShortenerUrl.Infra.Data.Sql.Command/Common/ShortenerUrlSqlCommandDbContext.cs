using Microsoft.EntityFrameworkCore;
using ShortenerUrl.Core.Domain.ShortenerUrl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Core.Domain.ValueObjects;
using Zamin.Infra.Data.Sql.Commands;
using Zamin.Infra.Data.Sql.Commands.OutBoxEventItems;
using Zamin.Infra.Data.Sql.Commands.ValueConversions;

namespace ShortenerUrl.Infra.Data.Sql.Command.Common
{
    public class ShortenerUrlSqlCommandDbContext : BaseCommandDbContext
    {
        public DbSet<ShortUrl> ShortUrl { get; set; }
        public DbSet<OutBoxEventItem> OutBoxEventItems
        {
            get;
            set;
        }
        public ShortenerUrlSqlCommandDbContext(DbContextOptions<ShortenerUrlSqlCommandDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
            configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
            configurationBuilder.Properties<BusinessId>().HaveConversion<BusinessIdConversion>();
        }
    }
}
