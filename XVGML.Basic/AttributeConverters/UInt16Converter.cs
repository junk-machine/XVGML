using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class UInt16Converter : IAttributeConverter {
        public object Convert(string value) {
            UInt16 result;
            if (UInt16.TryParse(value, out result)) {
                return result;
            }
            return default(UInt16);
        }
    }
}
