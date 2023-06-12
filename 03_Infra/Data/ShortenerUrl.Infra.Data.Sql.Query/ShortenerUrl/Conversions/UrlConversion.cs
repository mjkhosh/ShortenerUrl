using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects;

namespace ShortenerUrl.Infra.Data.Sql.Query.ShortenerUrl.Conventions
{
    public class UrlConversion : ValueConverter<ShUrl ,string>
    {
        public UrlConversion() : base(c => c.value, c =>  ShUrl.FromString(c))
        {

        }

    }
}
