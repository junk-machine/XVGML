using System;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class DateTimeConverter : IAttributeConverter {
        public object Convert(string value) {
            DateTime result;
            if (DateTime.TryParse(value, out result)) {
                return result;
            }
            return default(DateTime);
        }
    }
}
