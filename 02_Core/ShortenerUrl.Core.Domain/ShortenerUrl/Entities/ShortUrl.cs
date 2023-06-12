using ShortenerUrl.Core.Domain.ShortenerUrl.Events;
using ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;

namespace ShortenerUrl.Core.Domain.ShortenerUrl.Entities
{
    public class ShortUrl : AggregateRoot
    {
        public ShUrl Url { get; private set; }
       
        public ShortUrl(ShUrl url)
        {
            if(url == null) throw new InvalidValueObjectStateException($" مقدار فیلد  خالی می باشد.", nameof(ShortUrl));
            InsertUrl(url);
        }
        public ShortUrl()
        {

        }
        public void InsertUrl(ShUrl url)
        {

            Url = url;
            AddEvent(new ShortenerUrlInserted(BusinessId.Value, url.value));
        }
       

    }
}
