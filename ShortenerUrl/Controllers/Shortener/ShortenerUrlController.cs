using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortenerUrl.Core.Contracts.ShortenerUrl.Commands.InsertedUrl;
using ShortenerUrl.Core.Contracts.ShortenerUrl.Queries;
using ShortenerUrl.Core.Domain.ResultDTO;
using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.EndPoints.Web.Controllers;

namespace ShortenerUrl.Endpoints.ShortenerUrl.Controllers.Shortener
{
    [ApiVersion("1", Deprecated = false)]
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenerUrlController : BaseController
    {
        public ShortenerUrlController()
        {

        }
        [HttpPost("GenerateShortnerUrl")]
        public async Task<CommandResult> GenerateShortnerUrl(InsertedUrl insertedUrl)
        {
            return await CommandDispatcher.Send<InsertedUrl>(insertedUrl);
        }
        [HttpPost("RedirectUrl")]
        public async Task<CommandResult> RedirectUrl(GetUrlModel Generatedcode)
        {
            var result = await QueryDispatcher.Execute<GetUrlModel, CommandResult<UrlResultModel>>(Generatedcode);
            if (result.Status == Zamin.Core.Contracts.ApplicationServices.Common.ApplicationServiceStatus.Ok) { 
                Redirect(result.Data.Data.Url);
            }
            return result.Data;
        }
    }
}
