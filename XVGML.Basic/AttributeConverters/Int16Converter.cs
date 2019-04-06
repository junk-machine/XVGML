using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class Int16Converter : IAttributeConverter {
        public object Convert(string value) {
            Int16 result;
            if (Int16.TryParse(value, out result)) {
                return result;
            }
            return default(Int16);
        }
    }
}
