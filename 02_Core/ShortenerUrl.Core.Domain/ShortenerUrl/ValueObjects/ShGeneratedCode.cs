using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects
{
    public class ShGeneratedCode : BaseValueObject<ShGeneratedCode>
    {
        #region properties
        public string value { get; private set; }
        #endregion
        #region Constructors

        public ShGeneratedCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new InvalidValueObjectStateException("مقدار فیلد اجباری می باشد.", nameof(ShGeneratedCode));

        }
        #endregion
        #region Factories
        public static ShGeneratedCode FromString(string value) => new ShGeneratedCode(value);
        #endregion
        #region EqualityCheck
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
        #endregion
        #region Methods
        public override string ToString() => value;
        #endregion
        #region overLoading
        public static explicit operator string(ShGeneratedCode shGeneratedCode) => shGeneratedCode.value;
        public static implicit operator ShGeneratedCode(string value) => new(value);
        #endregion
    }
}
