using ShortenerUrl.Core.Contracts.ShortenerUrl.Queries;
using ShortenerUrl.Core.Domain.ResultDTO;
using ShortenerUrl.Core.Domain.ShortenerUrl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.Data.Queries;

namespace ShortenerUrl.Core.Contracts.Interfaces.DAL
{
    public interface IShortenerUrlRepository: IQueryRepository
    {
        CommandResult<UrlResultModel> Query(GetUrlModel getUrlModel);
    }
}
