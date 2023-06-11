using ShortenerUrl.Core.Contracts.ShortenerUrl.Commands.InsertedUrl;
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
        public InsertedUrlHandler(ZaminServices zaminServices) : base(zaminServices)
        {

        }

        public override async Task<CommandResult> Handle(InsertedUrl request)
        {
            return Ok();
        }
    }
}
