using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class DoubleConverter : IAttributeConverter {
        public object Convert(string value) {
            Double result;
            if (Double.TryParse(value, out result)) {
                return result;
            }
            return default(Double);
        }
    }
}
