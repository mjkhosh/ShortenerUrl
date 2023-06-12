using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortenerUrl.Core.Contracts.ShortenerUrl.Commands.InsertedUrl;
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
        [HttpPost("ShortnerUrl")]
        public async Task<ResultDTO<string>> ShortnerUrl(InsertedUrl insertedUrl)
        {
            var result = await CommandDispatcher.Send<InsertedUrl>(insertedUrl);
            if (result.Status == Zamin.Core.Contracts.ApplicationServices.Common.ApplicationServiceStatus.Ok)
            {
                return new() { IsSuccess = true, ResultAction = Enums.ResultAction.SuccessfulyCommand };
            }
            return new() { IsSuccess = false, ResultAction = Enums.ResultAction.SuccessfulyCommand };

        }
    }
}
