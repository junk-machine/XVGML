using System;
using XVGML.Core.Attributes;
using XVGML.Basic.Types;

namespace XVGML.Basic.AttributeConverters {
    class LocationConverter : IAttributeConverter {
        private SingleConverter singleConverter;

        public LocationConverter() {
            singleConverter = new SingleConverter();
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
            var converted = (Single)singleConverter.Convert(value);
            return new Location { Top = converted, Left = converted };
        }

        private object FromTwoValues(string[] values) {
            return new Location {
                Top = (Single)singleConverter.Convert(values[0]),
                Left = (Single)singleConverter.Convert(values[1])
            };
        }
    }
}
