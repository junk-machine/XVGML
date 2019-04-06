using System;
using XVGML.Core.Attributes;
using XVGML.Core.Packaging;

namespace XVGML.Basic.AttributeConverters {
    public class ByteConverter : IAttributeConverter {
        public object Convert(string value) {
            Byte result;
            if (Byte.TryParse(value, out result)) {
                return result;
            }
            return default(Byte);
        }
    }
}
