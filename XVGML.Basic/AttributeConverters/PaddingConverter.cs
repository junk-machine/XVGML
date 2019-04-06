using System;
using XVGML.Core.Attributes;
using XVGML.Basic.Types;

namespace XVGML.Basic.AttributeConverters {
    public class PaddingConverter : IAttributeConverter {
        private SingleConverter singleConverter;

        public PaddingConverter() {
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
            if (values.Length == 4) {
                return FromFourNumbers(values);
            }
            return new Padding();
        }

        private Padding FromOneNumber(string value) {
            return new Padding() {
                Top = ToSingle(value),
                Right = ToSingle(value),
                Bottom = ToSingle(value),
                Left = ToSingle(value)
            };
        }

        private Padding FromTwoNumbers(string[] values) {
            return new Padding() {
                Top = ToSingle(values[0]),
                Right = ToSingle(values[1]),
                Bottom = ToSingle(values[0]),
                Left = ToSingle(values[1])
            };
        }

        private Padding FromFourNumbers(string[] values) {
            return new Padding() {
                Top = ToSingle(values[0]),
                Right = ToSingle(values[1]),
                Bottom = ToSingle(values[2]),
                Left = ToSingle(values[3])
            };
        }

        private Single ToSingle(string value) {
            return (Single)singleConverter.Convert(value);
        }
    }
}
