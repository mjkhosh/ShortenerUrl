using ShortenerUrl.Core.Domain.ShortenerUrl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.Data.Commands;

namespace ShortenerUrl.Core.Contracts.Interfaces.DAL
{
    public interface IShortenerUrlCommandRepository:ICommandRepository<ShortUrl>
    {
    }
}
