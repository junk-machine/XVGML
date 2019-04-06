using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class UInt32Converter : IAttributeConverter {
        public object Convert(string value) {
            UInt32 result;
            if (UInt32.TryParse(value, out result)) {
                return result;
            }
            return default(UInt32);
        }
    }
}
