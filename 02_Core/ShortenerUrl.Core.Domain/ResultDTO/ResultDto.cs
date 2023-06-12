using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShortenerUrl.Core.Domain.ResultDTO.Enums;

namespace ShortenerUrl.Core.Domain.ResultDTO
{
    public class ResultDTO
    {
        public bool IsSuccess { get; set; }
        public ResultAction ResultAction { get; set; }
        public Exception exception { get; set; }
    }
    public class ResultDTO<T> : ResultDTO
    {
        public T Data { get; set; }
    }
}
