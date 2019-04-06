using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class StringConverter : IAttributeConverter {
        public object Convert(string value) {
            return value;
        }
    }
}
