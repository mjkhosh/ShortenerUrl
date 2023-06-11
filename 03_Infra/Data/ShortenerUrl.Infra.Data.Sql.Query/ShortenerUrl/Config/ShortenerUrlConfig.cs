using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShortenerUrl.Core.Domain.ShortenerUrl.Entities;
using ShortenerUrl.Infra.Data.Sql.Query.ShortenerUrl.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerUrl.Infra.Data.Sql.Query.ShortenerUrl.Config
{
    public class ShortenerUrlConfig : IEntityTypeConfiguration<ShortUrl>
    {
        public void Configure(EntityTypeBuilder<ShortUrl> builder)
        {
            builder.Property(x => x.Url).HasConversion<UrlConversion>();
        }
    }
}
