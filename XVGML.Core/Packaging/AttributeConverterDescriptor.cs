using System;
using XVGML.Core.Attributes;

namespace XVGML.Core.Packaging {
    public class AttributeConverterDescriptor {
        public Type Type { get; set; }
        public IAttributeConverter Converter { get; set; }

        public AttributeConverterDescriptor() { }

        public AttributeConverterDescriptor(Type type, IAttributeConverter converter) {
            Type = type;
            Converter = converter;
        }
    }
}
