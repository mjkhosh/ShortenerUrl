using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Contracts.ApplicationServices.Commands;

namespace ShortenerUrl.Core.Contracts.ShortenerUrl.Commands.InsertedUrl
{
    public class InsertedUrl:ICommand
    {
        public string Url { get; set; }
    }
}
