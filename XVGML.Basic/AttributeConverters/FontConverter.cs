using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class FontConverter : IAttributeConverter {
        public object Convert(string value) {
            return new System.Drawing.FontConverter().ConvertFromInvariantString(value);
        }
    }
}
