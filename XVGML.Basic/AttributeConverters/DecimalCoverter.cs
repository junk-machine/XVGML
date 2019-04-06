using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class DecimalConverter : IAttributeConverter {
        public object Convert(string value) {
            Decimal result;
            if (Decimal.TryParse(value, out result)) {
                return result;
            }
            return default(Decimal);
        }
    }
}
