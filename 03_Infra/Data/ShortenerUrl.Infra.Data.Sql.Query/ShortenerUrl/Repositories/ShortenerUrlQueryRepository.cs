using Microsoft.EntityFrameworkCore;
using ShortenerUrl.Core.Contracts.Interfaces.DAL;
using ShortenerUrl.Core.Contracts.ShortenerUrl.Queries;
using ShortenerUrl.Infra.Data.Sql.Query.Common;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Infra.Data.Sql.Queries;

namespace ShortenerUrl.Infra.Data.Sql.Command.ShortenerUrl.Repositories
{
    public class ShortenerUrlQueryRepository : BaseQueryRepository<ShortenerUrlSqlQueryDbContext>,
        IShortenerUrlRepository
    {
        public ShortenerUrlQueryRepository(ShortenerUrlSqlQueryDbContext dbContext) : base(dbContext)
        {

        }

        public CommandResult<UrlResultModel> Query(GetUrlModel getUrlModel)
        {
            try
            {
                CommandResult<UrlResultModel> commandResult = new();

                var result = _dbContext.ShortUrl.Where(x => x.Id == getUrlModel.GeneratedCode).SingleOrDefault();

                if (result == null)
                {
                    commandResult.Status = Zamin.Core.Contracts.ApplicationServices.Common.ApplicationServiceStatus.NotFound;
                    commandResult.AddMessage("کد وارد شده صحیح نمی باشد");
                    return commandResult;
                }
                commandResult.Status = Zamin.Core.Contracts.ApplicationServices.Common.ApplicationServiceStatus.Ok;
                commandResult._data = new() { Url = result.Url.value };
                return commandResult;
            }
            catch (Exception)
            {
                CommandResult<UrlResultModel> commandResult = new()
                { Status = Zamin.Core.Contracts.ApplicationServices.Common.ApplicationServiceStatus.Exception };
                commandResult.AddMessage("خطایی رخ داده است ");
                return commandResult;
            }
        }
    }
}
