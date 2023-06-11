using ShortenerUrl.Core.Domain.ShortenerUrl.Events;
using ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;

namespace ShortenerUrl.Core.Domain.ShortenerUrl.Entities
{
    public class ShortUrl : AggregateRoot
    {
        public ShUrl Url { get; set; }
        public ShortUrl()
        {
        }
        public ShortUrl(ShUrl url)
        {
            Url = url;
        }
        public void InsertUrl(ShortUrl url)
        {

            Url = Url;
            AddEvent(new ShortenerUrlInserted(BusinessId.Value, Url.value));
        }
    }
}
