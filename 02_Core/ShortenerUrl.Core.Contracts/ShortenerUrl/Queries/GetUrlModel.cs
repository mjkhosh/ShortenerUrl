using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Queries;

namespace ShortenerUrl.Core.Contracts.ShortenerUrl.Queries
{
    public class GetUrlModel: IQuery<CommandResult<UrlResultModel>>
    {
        public int GeneratedCode { get; set; }
    }
}
