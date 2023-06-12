using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace ShortenerUrl.Core.Domain.ShortenerUrl.ValueObjects
{
    public class ShUrl : BaseValueObject<ShUrl>
    {
        #region Const Field
        private const int MaxValueLengh = 190_000;
        private const int MinValueLengh = 5;
        #endregion
        #region properties
        public string value { get; private set; }
        #endregion

        #region Constructor

        public ShUrl(string Value)
        {
            if (string.IsNullOrWhiteSpace(Value)) throw new InvalidValueObjectStateException("مقدار فیلد اجباری می باشد.", nameof(ShUrl));
            if (Value.Length > MaxValueLengh) throw new InvalidValueObjectStateException($"تعداد کاراکتر فیلد بیشتر از{MaxValueLengh.ToString()} می باشد.", nameof(ShUrl));
            if (Value.Length < MinValueLengh) throw new InvalidValueObjectStateException($"تعداد کاراکتر فیلد کمتر از{MinValueLengh.ToString()} می باشد.", nameof(ShUrl));
            value = Value;
        }
       
        #endregion
       
        #region overLoading
        public static implicit operator ShUrl(string value) => new(value);
        public static explicit operator string(ShUrl shUrl) => shUrl.value;
        #endregion
        #region Methods

        public static ShUrl FromString(string value) => new ShUrl(value);
        override public string ToString() => value;

    

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return value;
        }
        #endregion
    }
}
