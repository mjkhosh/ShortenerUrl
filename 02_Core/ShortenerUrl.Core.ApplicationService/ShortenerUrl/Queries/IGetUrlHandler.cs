using ShortenerUrl.Core.Contracts.ShortenerUrl.Queries;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace ShortenerUrl.Core.ApplicationService.ShortenerUrl.Queries
{
    public interface IGetUrlHandler
    {
        Task<QueryResult<CommandResult<UrlResultModel>>> Handle(GetUrlModel request);
    }
}