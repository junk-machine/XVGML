using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class BooleanConverter : IAttributeConverter {
        public object Convert(string value) {
            Boolean result;
            if (Boolean.TryParse(value, out result)) {
                return result;
            }
            return default(Boolean);
        }
    }
}
