using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class UInt64Converter : IAttributeConverter {
        public object Convert(string value) {
            UInt64 result;
            if (UInt64.TryParse(value, out result)) {
                return result;
            }
            return default(UInt64);
        }
    }
}
