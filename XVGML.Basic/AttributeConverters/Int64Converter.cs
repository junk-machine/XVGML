using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class Int64Converter : IAttributeConverter {
        public object Convert(string value) {
            Int64 result;
            if (Int64.TryParse(value, out result)) {
                return result;
            }
            return default(Int64);
        }
    }
}
