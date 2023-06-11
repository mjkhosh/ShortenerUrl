using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects;

namespace ShortenerUrl.Infra.Data.Sql.Command.ShortenerUrl.Conversions
{
    public class UrlConversion : ValueConverter<ShUrl, string>
    {
        public UrlConversion() : base(c => c.value, c => ShUrl.FromString(c))
        {

        }

    }
}
