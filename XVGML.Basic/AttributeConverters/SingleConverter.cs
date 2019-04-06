using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class SingleConverter : IAttributeConverter {
        public object Convert(string value) {
            Single result;
            if (Single.TryParse(value, out result)) {
                return result;
            }
            return default(Single);
        }
    }
}
