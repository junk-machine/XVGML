using System;
using System.Drawing;
using XVGML.Core.Attributes;
using XVGML.Basic.Types;

namespace XVGML.Basic.AttributeConverters {
    public class LineStyleConverter : IAttributeConverter {
        private SingleConverter singleConverter;
        private ColorConverter colorConverter;

        public LineStyleConverter() {
            singleConverter = new SingleConverter();
            colorConverter = new ColorConverter();
        }

        public object Convert(string value) {
            var values = value.Split(' ');
            if (values.Length == 1) {
                return FromOneValue(values[0]);
            }
            if (values.Length == 2) {
                return FromTwoValues(values);
            }
            return null;
        }

        private object FromOneValue(string value) {
            return new LineStyle { Color = (Color)colorConverter.Convert(value), Width = 1 };
        }

        private object FromTwoValues(string[] values) {
            return new LineStyle {
                Width = (Single)singleConverter.Convert(values[0]),
                Color = (Color)colorConverter.Convert(values[1])
            };
        }
    }
}
