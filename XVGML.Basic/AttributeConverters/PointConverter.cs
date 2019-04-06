using System;
using System.Drawing;
using XVGML.Core.Attributes;

namespace XVGML.Basic.AttributeConverters {
    public class PointConverter : IAttributeConverter {
        private SingleConverter singleConverter;

        public PointConverter() {
            singleConverter = new SingleConverter();
        }

        public object Convert(string value) {
            var values = value.Split(' ');
            if (values.Length == 1) {
                return FromOneNumber(values[0]);
            }
            if (values.Length == 2) {
                return FromTwoNumbers(values);
            }
            return new PointF();
        }

        private object FromOneNumber(string value) {
            var converted = (Single)singleConverter.Convert(value);
            return new PointF(converted, converted);
        }

        private object FromTwoNumbers(string[] values) {
            return new PointF((Single)singleConverter.Convert(values[0]),
                              (Single)singleConverter.Convert(values[1]));
        }
    }
}
