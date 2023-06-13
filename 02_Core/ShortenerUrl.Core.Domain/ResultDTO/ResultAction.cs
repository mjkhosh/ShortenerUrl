using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortenerUrl.Core.Domain.ResultDTO
{
    public class Enums
    {
        public enum ResultAction
        {
            UnknownError=0,
            ExceptionFaild=1,
            SuccessfulyCommand=2000,
        }
    }
}
