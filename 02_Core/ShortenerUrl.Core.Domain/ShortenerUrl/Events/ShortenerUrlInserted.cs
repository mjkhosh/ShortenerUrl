using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Events;

namespace ShortenerUrl.Core.Domain.ShortenerUrl.Events
{
    public class ShortenerUrlInserted:IDomainEvent
    {
        public Guid BusinessId { get; set; }
        public string Url { get; set; }

        public ShortenerUrlInserted(Guid businessId, string url)
        {
            BusinessId = businessId;
            Url = url;
        }
    }

}
