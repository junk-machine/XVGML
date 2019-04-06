using System.Drawing;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class ColorConverter : IAttributeConverter {
        public object Convert(string value) {
            return ColorTranslator.FromHtml(value);
        }
    }
}
