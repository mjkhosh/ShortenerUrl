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
        public ShUrl Url { get; private set; }
       
        public ShortUrl(ShUrl url)
        {
            InsertUrl(url);
        }
        public void InsertUrl(ShUrl url)
        {

            Url = url;
            AddEvent(new ShortenerUrlInserted(BusinessId.Value, url.value));
        }
      
    }
}
