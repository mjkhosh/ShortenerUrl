using ShortenerUrl.Core.Contracts.Interfaces.DAL;
using ShortenerUrl.Core.Contracts.ShortenerUrl.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;

namespace ShortenerUrl.Core.ApplicationService.ShortenerUrl.Queries
{
    public class GetUrlHandler : QueryHandler<GetUrlModel, CommandResult<UrlResultModel>>, IGetUrlHandler
    {
        private readonly IShortenerUrlRepository iShortenerUrlRepository;

        public GetUrlHandler(ZaminServices zaminServices, IShortenerUrlRepository iShortenerUrlRepository) : base(zaminServices)
        {
            this.iShortenerUrlRepository = iShortenerUrlRepository;
        }



        public override async Task<QueryResult<CommandResult<UrlResultModel>>> Handle(GetUrlModel request)
        {
            QueryResult<CommandResult<UrlResultModel>> queryResult = new();
            await Task.Run(() =>
             {
                 var result = iShortenerUrlRepository.Query(request);
                 queryResult = new() { _data = result, Status = result.Status };
             });

            return queryResult;
        }

       
    }
}
