using ShortenerUrl.Core.Contracts.Interfaces.DAL;
using ShortenerUrl.Core.Domain.ShortenerUrl.Entities;
using ShortenerUrl.Infra.Data.Sql.Command.Common;
using System.Linq.Expressions;
using Zamin.Core.Domain.ValueObjects;
using Zamin.Infra.Data.Sql.Commands;

namespace ShortenerUrl.Infra.Data.Sql.Command.ShortenerUrl.Repositories
{
    public class ShortenerUrlCommandRepository : BaseCommandRepository<ShortUrl, ShortenerUrlSqlCommandDbContext>,
        IShortenerUrlCommandRepository
    {
        public ShortenerUrlCommandRepository(ShortenerUrlSqlCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
