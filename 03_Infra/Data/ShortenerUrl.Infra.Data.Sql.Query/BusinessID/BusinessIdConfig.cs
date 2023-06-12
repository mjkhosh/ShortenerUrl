using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.ValueObjects;

namespace ShortenerUrl.Infra.Data.Sql.Query.BusinessID
{
    public class BusinessIdConversion : ValueConverter<BusinessId, Guid>
    {
        public BusinessIdConversion()
            : base((Expression<Func<BusinessId, Guid>>)((BusinessId c) => c.Value), (Expression<Func<Guid, BusinessId>>)((Guid c) => BusinessId.FromGuid(c)), (ConverterMappingHints?)null)
        {
        }
    }
}
