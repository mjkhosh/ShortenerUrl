using ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;

namespace ShortenerUrl.Core.Domain.ShortenerUrl.Entities
{
    public class ShortenerUrl : AggregateRoot
    {
        public ShUrl Url { get; set; }
        public ShGeneratedCode shGeneratedCode { get; set; }
        public ShortenerUrl()
        {
        }
        public ShortenerUrl(ShUrl url)
        {
            Url = url;
        }
    }
}
