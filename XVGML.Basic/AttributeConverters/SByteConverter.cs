using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class SByteConverter : IAttributeConverter {
        public object Convert(string value) {
            SByte result;
            if (SByte.TryParse(value, out result)) {
                return result;
            }
            return default(SByte);
        }
    }
}
