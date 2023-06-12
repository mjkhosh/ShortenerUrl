using ShortenerUrl.Core.Contracts.Interfaces.DAL;
using ShortenerUrl.Core.Contracts.ShortenerUrl.Commands.InsertedUrl;
using ShortenerUrl.Core.Domain.ShortenerUrl.Entities;
using ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Utilities;

namespace ShortenerUrl.Core.ApplicationService.ShortenerUrl.Commands
{
    public class InsertedUrlHandler : CommandHandler<InsertedUrl>
    {
        private readonly IShortenerUrlCommandRepository _repository;
        public InsertedUrlHandler(ZaminServices zaminServices, IShortenerUrlCommandRepository repository) : base(zaminServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult> Handle(InsertedUrl request)
        {
            try
            {
                await _repository.InsertAsync(new(request.Url));
                await _repository.CommitAsync();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
