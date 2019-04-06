using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class Int32Converter : IAttributeConverter {
        public object Convert(string value) {
            Int32 result;
            if (Int32.TryParse(value, out result)) {
                return result;
            }
            return default(Int32);
        }
    }
}
